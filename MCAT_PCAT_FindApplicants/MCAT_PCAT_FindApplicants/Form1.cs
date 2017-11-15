using MCAT_PCAT_FindApplicants.Reports;
using Microsoft.Reporting.WinForms;
using LECOM;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net.Mime;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCAT_PCAT_FindApplicants
{
    public partial class Form1 : Form
    {

        public ReportDataSource reportDataSource = new ReportDataSource();
        public LECOM.SqlConnection cn = new LECOM.SqlConnection("SIS", "Sarah");
        System.Data.SqlClient.SqlConnection conn;
        ToolTip toolTip1 = new ToolTip();
        

        public Form1()
        {
            InitializeComponent();
        }

        private void sqlConnectButton_Click(object sender, EventArgs e)
        {                      
            //define datasets and tables
            DataSet candidacy = new DataSet();
            Reports.DataSet1.CandidacyDataTable candidacyCopy = new Reports.DataSet1.CandidacyDataTable();            
            DataTable candidacyStandard = new DataTable();

            if (maskedTextBox1.Text != null)
            {
                //update UI
                label1.Text = "Fetching candidacy information, please wait."; 
                label2.Text = "";
                label1.Refresh();
                label2.Refresh();
                maskedTextBox1.Visible = false;
                sqlConnectButton.Visible = false;

                string dbName = "tmsEPly", server = "SIS";
                string connectionString = System.String.Format("Server={0};Database={1};Connection Timeout=90;Max Pool Size=2048;Pooling=true;Trusted_Connection=True;", server, dbName);
                // TODO catch error when user clicks without entering a year
                string yr_code = maskedTextBox1.Text;

                string strSQLTemplate = "SELECT DISTINCT NAME_AND_ADDRESS.EMAIL_ADDRESS AS Email FROM CANDIDACY INNER JOIN NAME_AND_ADDRESS ON CANDIDACY.ID_NUM = NAME_AND_ADDRESS.ID_NUM WHERE yr_cde = {0}";
                string strSQL = string.Format(strSQLTemplate, yr_code);

                try
                {
                    //PASS IN AS CONNECTION
                    conn = new System.Data.SqlClient.SqlConnection(connectionString);
                    conn.Open();

                    //Check if the SQL Connection is open
                    if(conn.State == System.Data.ConnectionState.Open)
                    {
                        
                        //configure the sql query
                        //PASS IN AS CMD
                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(strSQL, conn);
                        //define a new dataset and populate it with the query's results
                    
                        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);

                        da.Fill(candidacyStandard);
                        candidacyCopy.Fill(conn, strSQL);

                        //make a table of candidates with values as strings
                        DataTable candidacyStrings = new DataTable();
                        candidacyStrings.Columns.Add("Email", typeof(string));
                                                                           
                        cmd = null;
                    
                        if(candidacyStandard.Rows.Count > 0)
                        {
                            for (int r = 0; r < candidacyStandard.Rows.Count; r++)
                            {
                                string email = "";
                                email = candidacyStandard.Rows[r][0].ToString().Trim();
                                candidacyStrings.Rows.Add(email);
                            }

                            if (cn.IsOpen)
                            {
                                //delete any previously imported data
                                string deleteSQL = "DELETE FROM LECOM_CURRENT_YEAR_CANDIDACY";
                                cn.Execute(deleteSQL, SQLTypes.Text);

                                //populate a separate table in Sarah db with this year's candidates  
                                SqlParameters CParm = new SqlParameters();
                                CParm.Add("exampleDT", candidacyStrings, SqlDbType.Structured);
                                CParm.List[0].TypeName = "dbo.LecomCurrentYearCandidacyTableType";
                                cn.Execute("dbo.LecomCurrentYearCandidacy", SQLTypes.StoredProcedure, CParm);

                                label1.Text = "Candidacy import complete! Please click 'Browse' and choose the excel spreadsheet you want to import.";
                                browseButton.Visible = true;
                            
                            }                            
                        }
                        else
                        {
                            MessageBox.Show("Error: no candidacy results returned!");
                        }                                            
                        conn.Close();
                    }
                    else
                    {
                        //tell the user the connection is not open and provide the current connection state
                        MessageBox.Show("Error: connection state not open. Current state is '" + conn.State.ToString() + "'");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected error " + ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Year code not valid. Please enter a valid year code.");
            }

        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            Reports.DataSet1.McatPcatDataTable McatPcat = new Reports.DataSet1.McatPcatDataTable();
            DataTable mcatPcat = new DataTable();

            if (cn.IsOpen)
            {
                OpenFileDialog openSheetDialog = new OpenFileDialog();

                openSheetDialog.FileName = "";
                openSheetDialog.Filter = "Excel 2007 Workbook (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                openSheetDialog.FilterIndex = 1;

                if (openSheetDialog.ShowDialog() == DialogResult.OK && Path.GetExtension(openSheetDialog.FileName) == ".xlsx")
                {
                    label1.Text = "Importing spreadsheet data, this may take a moment.";
                    label1.Refresh();
                    
                    browseButton.Visible = false;

                    //Declare the table that will hold the sheet's data
                    //this will be passed to SQL Server
                    mcatPcat.Columns.Add("LECOM", typeof(string));
                    mcatPcat.Columns.Add("aamc_id", typeof(string));
                    mcatPcat.Columns.Add("lname", typeof(string));
                    mcatPcat.Columns.Add("fname", typeof(string));
                    mcatPcat.Columns.Add("city", typeof(string));
                    mcatPcat.Columns.Add("state_cd", typeof(string));
                    mcatPcat.Columns.Add("email", typeof(string));

                    //open the file as a Spreadsheet Light document
                    SLDocument ss = new SLDocument(openSheetDialog.FileName);
                    SLWorksheetStatistics stats = ss.GetWorksheetStatistics();

                    //iterate through rows until the final row is reached
                    for (int r = 2; r <= stats.EndRowIndex; r++)
                    {
                        //Get the string values from the table
                        string aamc = ss.GetCellValueAsString(r, 2).Trim();
                        string lname = ss.GetCellValueAsString(r, 4).Trim();
                        string fname = ss.GetCellValueAsString(r, 5).Trim();
                        string city = ss.GetCellValueAsString(r, 9).Trim();
                        string state = ss.GetCellValueAsString(r, 10).Trim();
                        string email = ss.GetCellValueAsString(r, 13).Trim();

                        //Console.WriteLine(aamc + " " + lname + " " + fname + " " + city + " " + state + " " + email);

                        //add each row to the datatable
                        mcatPcat.Rows.Add("", aamc, lname, fname, city, state, email);
                    }                   
                    //close the SLDocument as the data is now in a datatable
                    ss.CloseWithoutSaving();

                    //pass the data to an import procedure and save to Sarah database
                    SqlParameters dtParm = new SqlParameters();
                    dtParm.Add("exampleDT", mcatPcat, SqlDbType.Structured);
                    dtParm.List[0].TypeName = "dbo.LecomMcatPcatTableType";
                    cn.Execute("dbo.LecomImportMcatPcat", SQLTypes.StoredProcedure, dtParm);
                    label1.Text = "Excel Data Entered into Database!";
                    reportViewButton.Visible = true;                    
                }
                else
                {
                    MessageBox.Show("Please select a valid Excel 2007 file!");
                    openSheetDialog.ShowDialog();
                }
            }
        }

        private void reportViewButton_Click(object sender, EventArgs e)
        {
            var report = new MCAT_PCAT_FindApplicants.Reports.ReportForm1("MCAT/PCAT Results and LECOM Candidate Matching", true, new Margins(25, 25, 25, 25));
            report.Show();
        }       
    }
}

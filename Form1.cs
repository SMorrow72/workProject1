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
        //Define a standard data table
        DataTable pcatTable = new DataTable();
        DataTable mcatTable = new DataTable();
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void sqlConnectButton_Click(object sender, EventArgs e)
        {                      
            //define datasets and tables
            DataTable candidacyStandard = new DataTable();

            if (maskedTextBox1.Text.Length == 4)
            {               
                using(new CursorWait())
                {
                    //update UI
                    label1.Text = "Fetching LECOM candidates. Please wait.";
                    label2.Text = "";
                    label1.Refresh();
                    label2.Refresh();
                    maskedTextBox1.Visible = false;
                    sqlConnectButton.Visible = false;

                    string dbName = "tmsEPrd", server = "SIS";
                    string connectionString = System.String.Format("Server={0};Database={1};Connection Timeout=90;Max Pool Size=2048;Pooling=true;Trusted_Connection=True;", server, dbName);
                    
                    string strSQLTemplate = "SELECT DISTINCT NAME_AND_ADDRESS.EMAIL_ADDRESS AS Email, DIV_CDE FROM CANDIDACY INNER JOIN NAME_AND_ADDRESS ON CANDIDACY.ID_NUM = NAME_AND_ADDRESS.ID_NUM WHERE yr_cde = {0}";
                    string yr_code = maskedTextBox1.Text;
                    string strSQL = string.Format(strSQLTemplate, yr_code);

                    try
                    {
                        conn = new System.Data.SqlClient.SqlConnection(connectionString);
                        conn.Open();

                        //Check if the SQL Connection is open
                        if (conn.State == System.Data.ConnectionState.Open)
                        {
                            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(strSQL, conn);
                            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);

                            da.Fill(candidacyStandard);

                            //make a table of candidates with values as strings
                            DataTable candidacyStrings = new DataTable();
                            candidacyStrings.Columns.Add("Email", typeof(string));
                            candidacyStrings.Columns.Add("DIV_CDE", typeof(string));

                            cmd = null;

                            if (candidacyStandard.Rows.Count > 0)
                            {
                                for (int r = 0; r < candidacyStandard.Rows.Count; r++)
                                {
                                    string email = "";
                                    string div_cde = "";
                                    email = candidacyStandard.Rows[r][0].ToString().Trim();
                                    div_cde = candidacyStandard.Rows[r][1].ToString().Trim();
                                    candidacyStrings.Rows.Add(email, div_cde);
                                }

                                if (cn.IsOpen)
                                {
                                    //delete any previously imported candidates
                                    string deleteSQL = "DELETE FROM LECOM_CURRENT_YEAR_CANDIDACY";
                                    cn.Execute(deleteSQL, SQLTypes.Text);

                                    //populate a separate table in Sarah db with this year's candidates  
                                    SqlParameters CParm = new SqlParameters();
                                    CParm.Add("exampleDT", candidacyStrings, SqlDbType.Structured);
                                    CParm.List[0].TypeName = "dbo.LecomCurrentYearCandidacyTableType2";
                                    cn.Execute("dbo.LecomCurrentYearCandidacy", SQLTypes.StoredProcedure, CParm);

                                    label1.Text = "Candidate import complete! Please click 'Browse' and choose the excel spreadsheet you want to import.";
                                    mcatBrowseButton.Visible = true;
                                    pcatBrowseButton.Visible = true;

                                    //prep for excel import
                                    
                                    //Declare the standard data table's columns
                                    mcatTable.Columns.Add("LECOM", typeof(string));
                                    mcatTable.Columns.Add("aamc_id", typeof(string));
                                    mcatTable.Columns.Add("lname", typeof(string));
                                    mcatTable.Columns.Add("fname", typeof(string));
                                    mcatTable.Columns.Add("city", typeof(string));
                                    mcatTable.Columns.Add("state_cd", typeof(string));
                                    mcatTable.Columns.Add("email", typeof(string));

                                    pcatTable.Columns.Add("LECOM", typeof(string));
                                    pcatTable.Columns.Add("lname", typeof(string));
                                    pcatTable.Columns.Add("fname", typeof(string));
                                    pcatTable.Columns.Add("city", typeof(string));
                                    pcatTable.Columns.Add("state_cd", typeof(string));
                                    pcatTable.Columns.Add("email", typeof(string));


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
                            MessageBox.Show("Error: connection state not open. Current state is '" + conn.State.ToString() + "'");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unexpected error " + ex.ToString());
                    }
                }                
            }
            else
            {
                MessageBox.Show("Year code not valid. Please enter a valid year code.");
            }

        }

        private void mcatBrowseButton_Click(object sender, EventArgs e)
        {
            if (cn.IsOpen)
            {
                //Open the dialog for the user to choose a spreadsheet
                OpenFileDialog openSheetDialog = new OpenFileDialog();
                openSheetDialog.FileName = "";
                openSheetDialog.Filter = "Excel 2007 Workbook (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                openSheetDialog.FilterIndex = 1;

                if (openSheetDialog.ShowDialog() == DialogResult.OK && Path.GetExtension(openSheetDialog.FileName) == ".xlsx")
                {
                    using (new CursorWait())
                    {
                        
                        label1.Text = "Importing spreadsheet data. This may take a moment.";
                        label1.Refresh();
                        mcatBrowseButton.Visible = false;
                        pcatBrowseButton.Visible = false;
                                           
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

                            //add each row to the standard data table
                            mcatTable.Rows.Add("", aamc, lname, fname, city, state, email);
                        }
                        //close the SLDocument, as the data is now in a datatable
                        ss.CloseWithoutSaving();

                        if (cn.IsOpen)
                        {
                            //clear any old results from the table
                            cn.Execute("TRUNCATE TABLE LECOM_MCAT_TABLE", SQLTypes.Text);

                            SqlParameters dtParm = new SqlParameters();
                            dtParm.Add("exampleDT", mcatTable, SqlDbType.Structured);
                            dtParm.List[0].TypeName = "dbo.LecomMcatTableType";
                            cn.Execute("dbo.LecomImportMcat", SQLTypes.StoredProcedure, dtParm);
                            label1.Text = "Excel data import complete! Click below to view the match report.";
                            mcatReportViewButton.Visible = true;
                            //emailButton.Visible = true;
                        }

                    }
                    
                }
                else
                {
                    MessageBox.Show("Please select a valid Excel 2007 file!");
                    openSheetDialog.ShowDialog();
                }
            }
        }

        private void pcatBrowseButton_Click(object sender, EventArgs e)
        {
            if (cn.IsOpen)
            {
                //Open the dialog for the user to choose a spreadsheet
                OpenFileDialog openSheetDialog = new OpenFileDialog();
                openSheetDialog.FileName = "";
                openSheetDialog.Filter = "Excel 2007 Workbook (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                openSheetDialog.FilterIndex = 1;

                if (openSheetDialog.ShowDialog() == DialogResult.OK && Path.GetExtension(openSheetDialog.FileName) == ".xlsx")
                {
                    using (new CursorWait())
                    {
                        label1.Text = "Importing spreadsheet data. This may take a moment.";
                        label1.Refresh();
                        mcatBrowseButton.Visible = false;
                        pcatBrowseButton.Visible = false;

                        //open the file as a Spreadsheet Light document
                        SLDocument ss = new SLDocument(openSheetDialog.FileName);
                        SLWorksheetStatistics stats = ss.GetWorksheetStatistics();

                        //iterate through rows until the final row is reached
                        for (int r = 2; r <= stats.EndRowIndex; r++)
                        {
                            //Get the string values from the table
                            string lname = ss.GetCellValueAsString(r, 1).Trim();
                            string fname = ss.GetCellValueAsString(r, 2).Trim();
                            string city = ss.GetCellValueAsString(r, 8).Trim();
                            string state = ss.GetCellValueAsString(r, 9).Trim();
                            string email = ss.GetCellValueAsString(r, 4).Trim();

                            //add each row to the standard data table
                            pcatTable.Rows.Add("", lname, fname, city, state, email);
                        }
                        //close the SLDocument, as the data is now in a datatable
                        ss.CloseWithoutSaving();

                        if (cn.IsOpen)
                        {
                            //clear any old results from the table
                            cn.Execute("TRUNCATE TABLE LECOM_PCAT_TABLE", SQLTypes.Text);

                            SqlParameters dtParm = new SqlParameters();
                            dtParm.Add("exampleDT", pcatTable, SqlDbType.Structured);
                            dtParm.List[0].TypeName = "dbo.LecomPcatTableType";
                            cn.Execute("dbo.LecomImportPcat", SQLTypes.StoredProcedure, dtParm);
                            label1.Text = "Excel data import complete! Click below to view the match report or write an email (to all non-matches on the list).";
                            pcatReportViewButton.Visible = true;
                            emailButton.Visible = true;
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Please select a valid Excel 2007 file!");
                    openSheetDialog.ShowDialog();
                }
            }
        }

        private void mcatReportViewButton_Click(object sender, EventArgs e)
        {
            var report = new MCAT_PCAT_FindApplicants.Reports.mcatReportForm("MCAT Results and LECOM Candidate Matching", true, new Margins(25, 25, 25, 25));
            report.Show();
        }

        private void pcatReportViewButton_Click(object sender, EventArgs e)
        {
            var report = new MCAT_PCAT_FindApplicants.Reports.pcatReportForm("PCAT Results and LECOM Candidate Matching", true, new Margins(25, 25, 25, 25));
            report.Show();
        }

        private void emailButton_Click(object sender, EventArgs e)
        {
            var emailForm = new MCAT_PCAT_FindApplicants.EmailForm();
            emailForm.Show();
        }

        public class CursorWait : IDisposable
        {
            public CursorWait(bool appStarting = false, bool applicationCursor = false)
            {
                // Wait
                Cursor.Current = appStarting ? Cursors.AppStarting : Cursors.WaitCursor;
                if (applicationCursor) Application.UseWaitCursor = true;
            }

            public void Dispose()
            {
                // Reset
                Cursor.Current = Cursors.Default;
                Application.UseWaitCursor = false;
            }
        }        
    }
}

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
        public LECOM.SqlConnection cn;
        System.Data.SqlClient.SqlConnection conn;
        //define data tables to hold excel data in C#
        DataTable pcatTable = new DataTable();
        DataTable mcatTable = new DataTable();
        
        public Form1()
        {
            InitializeComponent();
            cn = this.WSqlConnection("MCAT_PCAT_FindApplicants", "SIS", "TmsEprd");
        }

        //This button gets LECOM Candidates
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
                        //This connection is different from cn
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
                                    cn.Execute("DELETE FROM LECOM_MATCHING_CURRENT_YEAR_CANDIDACY", SQLTypes.Text);

                                    //populate a separate table in Sarah db with this year's candidates  
                                    SqlParameters CParm = new SqlParameters();
                                    CParm.Add("exampleDT", candidacyStrings, SqlDbType.Structured);
                                    CParm.List[0].TypeName = "dbo.LecomMatchingCurrentYearCandidacyTableType";
                                    cn.Execute("dbo.Lecom_MatchingCurrentYearCandidacy", SQLTypes.StoredProcedure, CParm);

                                    label1.Text = "Candidate import complete! Please click 'Browse' and choose the excel spreadsheet you want to import.";
                                    //Make options available
                                    mcatBrowseButton.Visible = true;
                                    pcatBrowseButton.Visible = true;

                                    //prep for excel import
                                    
                                    //Declare the MCAT table's columns
                                    mcatTable.Columns.Add("LECOM", typeof(string)).MaxLength = 5;
                                    mcatTable.Columns.Add("legal_state_cd", typeof(string)).MaxLength = 2;
                                    mcatTable.Columns.Add("aamc_id", typeof(string)).MaxLength = 8;
                                    mcatTable.Columns.Add("test_date", typeof(DateTime));
                                    mcatTable.Columns.Add("lname", typeof(string)).MaxLength = 50;
                                    mcatTable.Columns.Add("fname", typeof(string)).MaxLength = 50;
                                    mcatTable.Columns.Add("mname", typeof(string)).MaxLength = 50;
                                    mcatTable.Columns.Add("suffix", typeof(string)).MaxLength = 50;
                                    mcatTable.Columns.Add("address", typeof(string)).MaxLength = 256;
                                    mcatTable.Columns.Add("city", typeof(string)).MaxLength = 50;
                                    mcatTable.Columns.Add("state_cd", typeof(string)).MaxLength = 2;
                                    mcatTable.Columns.Add("postal_cd", typeof(string)).MaxLength = 20;
                                    mcatTable.Columns.Add("country", typeof(string)).MaxLength = 50;
                                    mcatTable.Columns.Add("email", typeof(string)).MaxLength = 50;
                                    mcatTable.Columns.Add("sex", typeof(string)).MaxLength = 1;
                                    mcatTable.Columns.Add("age_at_test", typeof(int));
                                    mcatTable.Columns.Add("major_cd", typeof(string)).MaxLength = 2;
                                    mcatTable.Columns.Add("major", typeof(string)).MaxLength = 50;
                                    mcatTable.Columns.Add("primary_interest_cd", typeof(string));
                                    mcatTable.Columns.Add("primary_interest", typeof(string)).MaxLength = 50;
                                    mcatTable.Columns.Add("cpbs_score", typeof(int));
                                    mcatTable.Columns.Add("cpbs_cb_lower", typeof(int));
                                    mcatTable.Columns.Add("cpbs_cb_upper", typeof(int));
                                    mcatTable.Columns.Add("cpbs_%ile_rank", typeof(int));
                                    mcatTable.Columns.Add("cars_score", typeof(int));
                                    mcatTable.Columns.Add("cars_cb_lower", typeof(int));
                                    mcatTable.Columns.Add("cars_cb_upper", typeof(int));
                                    mcatTable.Columns.Add("cars_%ile_rank", typeof(int));
                                    mcatTable.Columns.Add("bbfl_score", typeof(int));
                                    mcatTable.Columns.Add("bbfl_cb_lower", typeof(int));
                                    mcatTable.Columns.Add("bbfl_cb_upper", typeof(int));
                                    mcatTable.Columns.Add("bbfl_%ile_rank", typeof(int));
                                    mcatTable.Columns.Add("psbb_score", typeof(int));
                                    mcatTable.Columns.Add("psbb_cb_lower", typeof(int));
                                    mcatTable.Columns.Add("psbb_cb_upper", typeof(int));
                                    mcatTable.Columns.Add("psbb_%ile_rank", typeof(int));
                                    mcatTable.Columns.Add("total_score", typeof(int));
                                    mcatTable.Columns.Add("total_cb_lower", typeof(int));
                                    mcatTable.Columns.Add("total_cb_upper", typeof(int));
                                    mcatTable.Columns.Add("total_%ile_rank", typeof(int));

                                    //PCAT table columns
                                    pcatTable.Columns.Add("LECOM", typeof(string)).MaxLength = 5;
                                    pcatTable.Columns.Add("lname", typeof(string)).MaxLength = 50;
                                    pcatTable.Columns.Add("fname", typeof(string)).MaxLength = 50;
                                    pcatTable.Columns.Add("MI", typeof(string)).MaxLength = 1;
                                    pcatTable.Columns.Add("email", typeof(string)).MaxLength = 50;
                                    pcatTable.Columns.Add("address1", typeof(string)).MaxLength = 100;
                                    pcatTable.Columns.Add("address2", typeof(string)).MaxLength = 100;
                                    pcatTable.Columns.Add("city", typeof(string)).MaxLength = 50;
                                    pcatTable.Columns.Add("state", typeof(string)).MaxLength = 2;
                                    pcatTable.Columns.Add("zip", typeof(string)).MaxLength = 20;
                                    pcatTable.Columns.Add("country", typeof(string)).MaxLength = 20;

                                }
                            }
                            else
                            {
                                MessageBox.Show("Error: no candidacy results returned!");
                                label1.Text = "Welcome! Please enter the current applicant year code in the box below and click the button to get started.";
                                label1.Refresh();
                                sqlConnectButton.Visible = true;
                                maskedTextBox1.Visible = true;
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
                        mcatBrowseButton.Refresh();
                        pcatBrowseButton.Visible = false;
                                           
                        //open the file as a Spreadsheet Light document
                        SLDocument ss = new SLDocument(openSheetDialog.FileName);
                        SLWorksheetStatistics stats = ss.GetWorksheetStatistics();

                        //iterate through rows until the final row is reached
                        for (int r = 2; r <= stats.EndRowIndex; r++)
                        {
                            //Get the string values from the table
                            string legal_state_cd = ss.GetCellValueAsString(r, 1).Trim();
                            string aamc = ss.GetCellValueAsString(r, 2).Trim();
                            DateTime date = ss.GetCellValueAsDateTime(r, 3);
                            string lname = ss.GetCellValueAsString(r, 4).Trim();
                            string fname = ss.GetCellValueAsString(r, 5).Trim();
                            string mname = ss.GetCellValueAsString(r, 6).Trim();
                            string suffix = ss.GetCellValueAsString(r, 7).Trim();
                            string address = ss.GetCellValueAsString(r, 8).Trim();
                            string city = ss.GetCellValueAsString(r, 9).Trim();
                            string state = ss.GetCellValueAsString(r, 10).Trim();
                            string postal_cd = ss.GetCellValueAsString(r, 11).Trim();
                            string country = ss.GetCellValueAsString(r, 12).Trim();
                            string email = ss.GetCellValueAsString(r, 13).Trim();
                            string sex = ss.GetCellValueAsString(r, 14).Trim();
                            int age = ss.GetCellValueAsInt32(r, 15);
                            string major_cd = ss.GetCellValueAsString(r, 16).Trim();
                            string major = ss.GetCellValueAsString(r, 17).Trim();
                            string primary_interest_cd = ss.GetCellValueAsString(r, 18).Trim();
                            string primary_interest = ss.GetCellValueAsString(r, 19).Trim();
                            int cpbs_score = ss.GetCellValueAsInt32(r, 20);
                            int cpbs_cb_lower = ss.GetCellValueAsInt32(r, 21);
                            int cpbs_cb_upper = ss.GetCellValueAsInt32(r, 22);
                            int cpbs_percentile_rank = ss.GetCellValueAsInt32(r, 23);
                            int cars_score = ss.GetCellValueAsInt32(r, 24);
                            int cars_cb_lower = ss.GetCellValueAsInt32(r, 25);
                            int cars_cb_upper = ss.GetCellValueAsInt32(r, 26);
                            int cars_percentile_rank = ss.GetCellValueAsInt32(r, 27);
                            int bbfl_score = ss.GetCellValueAsInt32(r, 28);
                            int bbfl_cb_lower = ss.GetCellValueAsInt32(r, 29);
                            int bbfl_cb_upper = ss.GetCellValueAsInt32(r, 30);
                            int bbfl_percentile_rank = ss.GetCellValueAsInt32(r, 31);
                            int psbb_score = ss.GetCellValueAsInt32(r, 32);
                            int psbb_cb_lower = ss.GetCellValueAsInt32(r, 33);
                            int psbb_cb_upper = ss.GetCellValueAsInt32(r, 34);
                            int psbb_percentile_rank = ss.GetCellValueAsInt32(r, 35);
                            int total_score = ss.GetCellValueAsInt32(r, 36);
                            int total_cb_lower = ss.GetCellValueAsInt32(r, 37);
                            int total_cb_upper = ss.GetCellValueAsInt32(r, 38);
                            int total_percentile_rank = ss.GetCellValueAsInt32(r, 39);
                            

                            //add each row to the standard data table
                            mcatTable.Rows.Add("", legal_state_cd, aamc, date, lname, fname, mname, suffix, address, city, state, postal_cd, country, email, sex, age, major_cd, major, primary_interest_cd, primary_interest, cpbs_score, cpbs_cb_lower, cpbs_cb_upper, cpbs_percentile_rank, cars_score, cars_cb_lower, cars_cb_upper, cars_percentile_rank, bbfl_score, bbfl_cb_lower, bbfl_cb_upper, bbfl_percentile_rank, psbb_score, psbb_cb_lower, psbb_cb_upper, psbb_percentile_rank, total_score, total_cb_lower, total_cb_upper, total_percentile_rank); ;
                        }
                        //close the SLDocument, as the data is now in a datatable
                        ss.CloseWithoutSaving();

                        if (cn.IsOpen)
                        {
                            //clear any old results from the table
                            cn.Execute("DELETE FROM LECOM_MATCHING_MCAT_TABLE", SQLTypes.Text);

                            SqlParameters dtParm = new SqlParameters();
                            dtParm.Add("exampleDT", mcatTable, SqlDbType.Structured);
                            dtParm.List[0].TypeName = "dbo.LecomMatchingMcatTableType";
                            cn.Execute("dbo.Lecom_MatchingImportMcat", SQLTypes.StoredProcedure, dtParm);
                            label1.Text = "Excel data import complete! Click below to view the match report.";
                            mcatReportViewButton.Visible = true;
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

                        //Update UI
                        mcatBrowseButton.Visible = false;
                        mcatBrowseButton.Refresh();
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
                            string mi = ss.GetCellValueAsString(r, 3).Trim();
                            string email = ss.GetCellValueAsString(r, 4).Trim();
                            string address1 = ss.GetCellValueAsString(r, 5).Trim();
                            string address2 = ss.GetCellValueAsString(r, 6).Trim();
                            string city = ss.GetCellValueAsString(r, 8).Trim();
                            string state = ss.GetCellValueAsString(r, 9).Trim();
                            string zip = ss.GetCellValueAsString(r, 10).Trim();
                            string country = ss.GetCellValueAsString(r, 11).Trim();
                           
                            //add each row to the standard data table
                            pcatTable.Rows.Add("", lname, fname, mi, email, address1, address2, city, state, zip, country);
                        }
                        //close the SLDocument, as the data is now in a datatable
                        ss.CloseWithoutSaving();

                        if (cn.IsOpen)
                        {
                            //clear any old results from the table
                            cn.Execute("DELETE FROM LECOM_MATCHING_PCAT_TABLE", SQLTypes.Text);

                            SqlParameters dtParm = new SqlParameters();
                            dtParm.Add("exampleDT", pcatTable, SqlDbType.Structured);
                            dtParm.List[0].TypeName = "dbo.LecomMatchingPcatTableType";
                            cn.Execute("dbo.Lecom_MatchingImportPcat", SQLTypes.StoredProcedure, dtParm);
                            label1.Text = "Excel data import complete! Click below to view the match report.";
                            pcatReportViewButton.Visible = true;
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

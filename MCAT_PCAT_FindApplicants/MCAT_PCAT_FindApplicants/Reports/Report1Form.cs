using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCAT_PCAT_FindApplicants.Reports
{
    public partial class Report1Form : Form
    {
        public ReportDataSource reportDataSource = new ReportDataSource();
        public LECOM.SqlConnection cn = new LECOM.SqlConnection("SIS", "Sarah");

        public DataSet1.McatPcatDataTable mcatPcatDataTable = new DataSet1.McatPcatDataTable();

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    this.reportViewer1.LocalReport.ReportPath = "";
        //    this.Name = "Report1Form";
        //    this.ResumeLayout(false);
        //}

        public Report1Form()
        {
            InitializeComponent();
            reportDataSource.Value = mcatPcatDataTable;
            GetData();
            reportViewer1.LocalReport.ReportPath = @"..\..\Reports\Report1.rdlc";
            
        }
       
        private void Report1Form_Load(object sender, EventArgs e)
        {
            //define the dataset
            //DataSet mcatPcatDataSet = new DataSet("DataSet1");
            //mcatPcatDataSet.Tables.Add(mcatPcatDataTable);

            
            //reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            
            reportViewer1.Visible = true;
        }

        public void GetData()
        {
            mcatPcatDataTable.Fill(cn);
            reportDataSource.Name = "McatPcat";
            reportViewer1.RefreshReport();
            //MessageBox.Show(table.Rows[0][0].ToString().Trim() + table.Rows[0][1].ToString().Trim());
        }

        
    }
}

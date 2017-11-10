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

        Reports.DataSet1.McatPcatDataTable mcatPcatDataTable = new Reports.DataSet1.McatPcatDataTable();
       
        public Report1Form()
        {
            InitializeComponent();
            reportDataSource.Value = mcatPcatDataTable;           
        }

        
        private void Report1Form_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportViewer1.LocalReport.ReportPath = @"..\..\Reports\Report1.rdlc";
            GetData(mcatPcatDataTable);
        }

        public void GetData(Reports.DataSet1.McatPcatDataTable table)
        {
            table.Fill(cn);
            reportDataSource.Name = "DataSet1";
            this.reportViewer1.RefreshReport();
        }
    }
}

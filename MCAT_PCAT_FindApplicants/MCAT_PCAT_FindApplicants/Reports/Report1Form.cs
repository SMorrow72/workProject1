using LECOM;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCAT_PCAT_FindApplicants.Reports
{
    public partial class Report1Form : BaseReport
    {
        DataSet1.McatPcatDataTable mcatPcatDataTable = new DataSet1.McatPcatDataTable();
        

        public Report1Form(string reportName, bool landscape, Margins margins, Control _parent = null) : base(reportName, landscape, margins, _parent)
        {
            InitializeComponent();
            reportDataSource.Value = mcatPcatDataTable;   
            GetData();                               
        }

        public override void AddControls()
        {
            reportViewer.LocalReport.ReportPath = @"..\..\Reports\Report1.rdlc"; 
        }

        private void Report1Form_Load(object sender, EventArgs e)
        {
            reportViewer.Visible = true;
            reportViewer.RefreshReport();
        }

        public override void GetData()
        {
            mcatPcatDataTable.Fill(cn);
            reportDataSource.Name = "DataSet1";
            reportViewer.RefreshReport();
            MessageBox.Show(mcatPcatDataTable.Rows[0][0].ToString().Trim() + " " + mcatPcatDataTable.Rows[0][1].ToString().Trim() + " " + mcatPcatDataTable.Rows[0][2].ToString().Trim() + " " + mcatPcatDataTable.Rows[0][3].ToString().Trim() + " " + mcatPcatDataTable.Rows[0][4].ToString().Trim() + " " + mcatPcatDataTable.Rows[0][5].ToString().Trim() + " " + mcatPcatDataTable.Rows[0][6].ToString().Trim());
        }        
    }
}

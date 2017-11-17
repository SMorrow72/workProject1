using LECOM;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCAT_PCAT_FindApplicants.Reports
{
    public partial class ReportForm1 : ClinEdReport
    {
        //Declare the report data table instance
        DataSet1.McatPcatDataTable mcatPcatDataTable = new DataSet1.McatPcatDataTable();

        public ReportForm1(string reportName, bool landscape, Margins margins, Control _parent = null) : base(reportName, landscape, margins, _parent)
        {
            reportDataSource.Value = mcatPcatDataTable;   
            GetData();                               
        }

        public override void AddControls()
        {
            reportViewer.LocalReport.ReportPath = @"..\..\Reports\Report1.rdlc"; 
        }

        private void ReportForm1_Load(object sender, EventArgs e)
        {
            reportViewer.Visible = true;
            reportViewer.RefreshReport();
        }

        public override void GetData()
        {
            mcatPcatDataTable.Fill(conn);
            reportDataSource.Name = "DataSet1";
            reportViewer.RefreshReport();
        }

        public override void Refresh()
        {
            GetData();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.reportViewer.LocalReport.ReportPath = "";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(938, 515);
            this.Name = "ReportForm1";
            this.ResumeLayout(false);
        }
    }
}

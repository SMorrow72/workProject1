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
    public partial class pcatReportForm : ClinEdReport
    {
        //Declare the report data table instance
        DataSet1.PcatDataTable pcatDataTable = new DataSet1.PcatDataTable();

        public pcatReportForm(string reportName, bool landscape, Margins margins, Control _parent = null) : base(reportName, landscape, margins, _parent)
        {
            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);
            reportDataSource.Value = pcatDataTable;   
            GetData();                               
        }

        public override void AddControls()
        {
            reportViewer.LocalReport.ReportPath = @"..\..\Reports\PcatReport.rdlc"; 
        }

        private void ReportForm1_Load(object sender, EventArgs e)
        {
            reportViewer.Visible = true;
            reportViewer.RefreshReport();
        }

        public override void GetData()
        {
            pcatDataTable.Fill(conn);
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
            this.Name = "pcatReportForm";
            this.ResumeLayout(false);
        }
    }
}

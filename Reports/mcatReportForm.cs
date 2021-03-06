﻿using LECOM;
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
    public partial class mcatReportForm : ClinEdReport
    {
        //Declare the report data table instance
        DataSet1.McatDataTable mcatDataTable = new DataSet1.McatDataTable();

        public mcatReportForm(string reportName, bool landscape, Margins margins, Control _parent = null) : base(reportName, landscape, margins, _parent)
        {
            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);
            reportDataSource.Value = mcatDataTable;   
            GetData();                               
        }

        public override void AddControls()
        {
            reportViewer.LocalReport.ReportPath = @"..\..\Reports\mcatReport.rdlc"; 
        }

        private void ReportForm1_Load(object sender, EventArgs e)
        {
            reportViewer.Visible = true;
            reportViewer.RefreshReport();
        }

        public override void GetData()
        {
            mcatDataTable.Fill(conn);
            reportDataSource.Name = "DataSet2";
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
            this.Name = "mcatReportForm";
            this.ResumeLayout(false);
        }
    }
}

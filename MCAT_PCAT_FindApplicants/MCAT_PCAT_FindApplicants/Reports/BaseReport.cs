using LECOM;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net.Mail;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysForms = System.Windows.Forms;

namespace MCAT_PCAT_FindApplicants.Reports
{
    public partial class BaseReport : Form
    {

        public Control parent;
        public SQLLogger lgr;
        public SqlConnection cn;
        public Panel panel;
        public ReportDataSource reportDataSource = new ReportDataSource();
        public WindowsMessager msgr;

        protected BaseReport()
        {
            InitializeComponent();
        }

        public BaseReport(string reportName, bool landscape, Margins margins, Control _parent = null)
        {
            InitializeComponent();
            this.Text = reportName;
            parent = _parent;
            msgr = new WindowsMessager();
            lgr = new SQLLogger(msgr, reportName, Environment.UserName);
            cn = new SqlConnection("SIS", "Sarah", msgr, lgr);
            reportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            Initialize(reportName, landscape, margins);
            AddControls();
            CreateEventHandlers();
        }

        public void Initialize(string reportName, bool landscape, Margins margins)
        {
            List<Control> listRemove = new List<Control>();
            msgr = new WindowsMessager();
            lgr = new SQLLogger(msgr, reportName, Environment.UserName);
            cn = new SqlConnection("SIS", "Sarah", msgr, lgr);
            panel = (Panel)this.Controls["pnlReport"];
            reportViewer.SetPageSettings(new PageSettings() { Landscape = landscape, Margins = margins });

            //foreach (Control ctrl in panel.Controls)
            //    if (ctrl.Name != "reportViewer") listRemove.Add(ctrl);

            //foreach (Control ctrl in listRemove)
            //    panel.Controls.Remove(ctrl);

            reportViewer.Visible = true;

            reportDataSource.Name = "DataSet1";
        }

        //Create virtual classes that will be defined in child classes

        public virtual void AddControls() { }

        public virtual void CreateEventHandlers() { }

        public virtual void GetData() { }

        public virtual void Refresh() { }

        public byte[] GetByteStream(string format = "PDF")
        {
            string mimeType = string.Empty, encoding = string.Empty, extension = string.Empty;
            string[] streamIDs; Warning[] warnings;
            byte[] bytes = reportViewer.LocalReport.Render(format, null, out mimeType, out encoding, out extension, out streamIDs, out warnings);
            return bytes;
        }

        private void ClinEdReportTemp_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (parent != null) { parent.BringToFront(); }
        }

        private void BaseReport_Load(object sender, EventArgs e)
        {

            this.reportViewer.RefreshReport();
            this.reportViewer.RefreshReport();
        }
    }
}

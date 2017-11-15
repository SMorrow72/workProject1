using LECOM;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysForms = System.Windows.Forms;

namespace MCAT_PCAT_FindApplicants.Reports
{
    public partial class ClinEdReport : Form
    {
        DateTime NullDate = new DateTime(1990, 1, 1);
        public Control parent;
        public SqlConnection conn;
        public Panel panel;
        public ReportDataSource reportDataSource = new ReportDataSource();
        public readonly Size NullSize = new Size(0, 0);
        
        protected ClinEdReport()
        {
            InitializeComponent();
        }

        public ClinEdReport(string reportName, bool landscape, Margins margins, Control _parent = null)
        {
            InitializeComponent();
            this.Text = reportName;
            parent = _parent;
            conn = this.WSqlConnection(reportName, "SIS", "Sarah");
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
            conn = this.WSqlConnection(reportName, "SIS", "Sarah");
            panel = (Panel)this.Controls["pnlReport"];
            reportViewer.SetPageSettings(new PageSettings() { Landscape = landscape, Margins = margins });

            foreach (Control ctrl in panel.Controls)
                if (ctrl.Name != "reportViewer") listRemove.Add(ctrl);

            foreach (Control ctrl in listRemove)
                panel.Controls.Remove(ctrl);

            reportViewer.Visible = true;

            reportDataSource.Name = "DataSet1";
        }

        public virtual void AddControls() { }

        public virtual void CreateEventHandlers() { }

        public SysForms.Button CreateButton(string Text, Point Location, Size Size)
        {
            var btn = new SysForms.Button();

            btn.Text = Text;
            btn.Location = Location;
            btn.Size = Size;

            panel.Controls.Add(btn);

            return btn;
        }

        public SysForms.ComboBox CreateComboBox(Point Location, Size Size)
        {
            var cb = new SysForms.ComboBox();

            cb.Location = Location;
            cb.Size = Size;

            panel.Controls.Add(cb);

            return cb;
        }

        public Label CreateLabel(string Text, Point Location)
        {
            var lbl = new Label();

            lbl.Text = Text;
            lbl.Location = Location;
            lbl.AutoSize = true;

            panel.Controls.Add(lbl);

            return lbl;
        }

        public ListBox CreateListBox(Point Location, Size Size)
        {
            var lb = new ListBox();

            lb.Location = Location;
            lb.Size = Size;

            panel.Controls.Add(lb);

            return lb;
        }

        public SysForms.RadioButton CreateRadioButton(string Text, Point Location, Size Size)
        {
            var rb = new SysForms.RadioButton();

            rb.Text = Text;
            rb.Location = Location;
            rb.Size = Size;

            panel.Controls.Add(rb);

            return rb;
        }

        public SysForms.DateTimePicker CreateDateTimePicker(Point Location, Size Size)
        {
            var dt = new SysForms.DateTimePicker();

            dt.Location = Location;
            dt.Size = Size;

            dt.MinDate = new DateTime(1992, 1, 1);
            dt.MaxDate = new DateTime(2049, 12, 31);

            dt.Format = DateTimePickerFormat.Short;

            panel.Controls.Add(dt);

            return dt;
        }

        public SysForms.TextBox CreateTextBox(Point Location, Size Size)
        {
            var txt = new SysForms.TextBox();

            txt.Location = Location;
            txt.Size = Size;

            panel.Controls.Add(txt);

            return txt;
        }

        public byte[] GetByteStream(string format = "PDF")
        {
            string mimeType = string.Empty, encoding = string.Empty, extension = string.Empty;
            string[] streamIDs; Warning[] warnings;
            byte[] bytes = reportViewer.LocalReport.Render(format, null, out mimeType, out encoding, out extension, out streamIDs, out warnings);
            return bytes;
        }

        public virtual void GetData() { }

        //public virtual void Refresh() { }

        public void SendReportByEmail(string to, string subject, string body, string attachmentName, string format = "PDF")
        {
            MailMessage msg = new MailMessage("AdmissionApps@lecom.edu", to, subject, body);
            Attachment app = new Attachment(new MemoryStream(GetByteStream(format)), attachmentName);
            msg.Attachments.Add(app);
            SmtpClient client = new SmtpClient("MAILSERVER01.lecomintra.net");
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("AdmissionApps", "AdmissionApps1");
            try { client.Send(msg); }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred in trying to e-mail the report.  Please re-open the application and try again.  If problems persist, please contact IT.  The error is: " +
                    ex.ToString());
            }
        }

        private void ClinEdReportTemp_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (parent != null) { parent.BringToFront(); }
        }
    }
}

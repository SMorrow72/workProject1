namespace MCAT_PCAT_FindApplicants.Reports
{
    partial class ClinEdReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlReport = new System.Windows.Forms.Panel();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlReport
            // 
            this.pnlReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReport.Controls.Add(this.reportViewer);
            this.pnlReport.Location = new System.Drawing.Point(2, 4);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Size = new System.Drawing.Size(934, 507);
            this.pnlReport.TabIndex = 3;
            // 
            // reportViewer
            // 
            this.reportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.reportViewer.Location = new System.Drawing.Point(0, 32);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ShowBackButton = false;
            this.reportViewer.ShowFindControls = false;
            this.reportViewer.ShowPromptAreaButton = false;
            this.reportViewer.Size = new System.Drawing.Size(934, 475);
            this.reportViewer.TabIndex = 2;
            this.reportViewer.Visible = false;
            // 
            // ClinEdReportTemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 515);
            this.Controls.Add(this.pnlReport);
            this.Name = "ClinEdReportTemp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clin Ed Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClinEdReportTemp_FormClosed);
            this.pnlReport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlReport;
        protected Microsoft.Reporting.WinForms.ReportViewer reportViewer;
    }
}
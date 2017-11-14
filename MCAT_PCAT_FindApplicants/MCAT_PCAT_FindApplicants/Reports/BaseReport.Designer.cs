namespace MCAT_PCAT_FindApplicants.Reports
{
    partial class BaseReport
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
            this.components = new System.ComponentModel.Container();
            this.DataSet1 = new MCAT_PCAT_FindApplicants.Reports.DataSet1();
            this.CandidacyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.McatPcatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CandidacyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.McatPcatBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CandidacyBindingSource
            // 
            this.CandidacyBindingSource.DataMember = "Candidacy";
            this.CandidacyBindingSource.DataSource = this.DataSet1;
            // 
            // McatPcatBindingSource
            // 
            this.McatPcatBindingSource.DataMember = "McatPcat";
            this.McatPcatBindingSource.DataSource = this.DataSet1;
            // 
            // reportViewer
            // 
            this.reportViewer.Location = new System.Drawing.Point(0, 32);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(932, 477);
            this.reportViewer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reportViewer);
            this.panel1.Location = new System.Drawing.Point(2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 507);
            this.panel1.TabIndex = 1;
            // 
            // BaseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 515);
            this.Controls.Add(this.panel1);
            this.Name = "BaseReport";
            this.Text = "BaseReport";
            this.Load += new System.EventHandler(this.BaseReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CandidacyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.McatPcatBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource CandidacyBindingSource;
        private DataSet1 DataSet1;
        private System.Windows.Forms.BindingSource McatPcatBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Panel panel1;
    }
}
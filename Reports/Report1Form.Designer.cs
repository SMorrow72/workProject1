﻿namespace MCAT_PCAT_FindApplicants.Reports
{
    partial class Report1Form
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.CandidacyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new MCAT_PCAT_FindApplicants.Reports.DataSet1();
            this.McatPcatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.CandidacyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.McatPcatBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // CandidacyBindingSource
            // 
            this.CandidacyBindingSource.DataMember = "Candidacy";
            this.CandidacyBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // McatPcatBindingSource
            // 
            this.McatPcatBindingSource.DataMember = "McatPcat";
            this.McatPcatBindingSource.DataSource = this.DataSet1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 35);
            this.panel1.TabIndex = 1;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "Candidacy";
            reportDataSource1.Value = this.CandidacyBindingSource;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.McatPcatBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "MCAT_PCAT_FindApplicants.Reports.Report1.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 2);
            this.reportViewer.Name = "reportViewer1";
            this.reportViewer.Size = new System.Drawing.Size(903, 228);
            this.reportViewer.TabIndex = 2;
            // 
            // Report1Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 273);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.panel1);
            this.Name = "Report1Form";
            this.Text = "Report1Form";
            this.Load += new System.EventHandler(this.Report1Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CandidacyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.McatPcatBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource CandidacyBindingSource;
        private DataSet1 DataSet1;
        private System.Windows.Forms.BindingSource McatPcatBindingSource;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
    }
}
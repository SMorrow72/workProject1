namespace MCAT_PCAT_FindApplicants
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.OpenSheetFile = new System.Windows.Forms.OpenFileDialog();
            this.sqlConnectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.mcatBrowseButton = new System.Windows.Forms.Button();
            this.mcatReportViewButton = new System.Windows.Forms.Button();
            this.pcatBrowseButton = new System.Windows.Forms.Button();
            this.pcatReportViewButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sqlConnectButton
            // 
            this.sqlConnectButton.BackColor = System.Drawing.Color.Blue;
            this.sqlConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sqlConnectButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sqlConnectButton.Location = new System.Drawing.Point(65, 201);
            this.sqlConnectButton.Name = "sqlConnectButton";
            this.sqlConnectButton.Size = new System.Drawing.Size(158, 33);
            this.sqlConnectButton.TabIndex = 3;
            this.sqlConnectButton.Text = "Get Started";
            this.sqlConnectButton.UseVisualStyleBackColor = false;
            this.sqlConnectButton.Click += new System.EventHandler(this.sqlConnectButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 105);
            this.label1.TabIndex = 4;
            this.label1.Text = "Welcome! Please enter the current applicant year code in the box below and click " +
    "the button to get started.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(31, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 58);
            this.label2.TabIndex = 6;
            this.label2.Text = "Note: type the year code in a 4-digit format. For example: in December 2017, the " +
    "applicant year code would be 1819.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(122, 175);
            this.maskedTextBox1.Mask = "0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(32, 20);
            this.maskedTextBox1.TabIndex = 7;
            // 
            // mcatBrowseButton
            // 
            this.mcatBrowseButton.Location = new System.Drawing.Point(82, 145);
            this.mcatBrowseButton.Name = "mcatBrowseButton";
            this.mcatBrowseButton.Size = new System.Drawing.Size(126, 23);
            this.mcatBrowseButton.TabIndex = 8;
            this.mcatBrowseButton.Text = "Choose MCAT Sheet";
            this.mcatBrowseButton.UseVisualStyleBackColor = true;
            this.mcatBrowseButton.Visible = false;
            this.mcatBrowseButton.Click += new System.EventHandler(this.mcatBrowseButton_Click);
            // 
            // mcatReportViewButton
            // 
            this.mcatReportViewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mcatReportViewButton.Location = new System.Drawing.Point(90, 139);
            this.mcatReportViewButton.Name = "mcatReportViewButton";
            this.mcatReportViewButton.Size = new System.Drawing.Size(109, 33);
            this.mcatReportViewButton.TabIndex = 9;
            this.mcatReportViewButton.Text = "View Report";
            this.mcatReportViewButton.UseVisualStyleBackColor = true;
            this.mcatReportViewButton.Visible = false;
            this.mcatReportViewButton.Click += new System.EventHandler(this.mcatReportViewButton_Click);
            // 
            // pcatBrowseButton
            // 
            this.pcatBrowseButton.Location = new System.Drawing.Point(82, 194);
            this.pcatBrowseButton.Name = "pcatBrowseButton";
            this.pcatBrowseButton.Size = new System.Drawing.Size(126, 23);
            this.pcatBrowseButton.TabIndex = 11;
            this.pcatBrowseButton.Text = "Choose PCAT Sheet";
            this.pcatBrowseButton.UseVisualStyleBackColor = true;
            this.pcatBrowseButton.Visible = false;
            this.pcatBrowseButton.Click += new System.EventHandler(this.pcatBrowseButton_Click);
            // 
            // pcatReportViewButton
            // 
            this.pcatReportViewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pcatReportViewButton.Location = new System.Drawing.Point(90, 139);
            this.pcatReportViewButton.Name = "pcatReportViewButton";
            this.pcatReportViewButton.Size = new System.Drawing.Size(109, 33);
            this.pcatReportViewButton.TabIndex = 12;
            this.pcatReportViewButton.Text = "View Report";
            this.pcatReportViewButton.UseVisualStyleBackColor = true;
            this.pcatReportViewButton.Visible = false;
            this.pcatReportViewButton.Click += new System.EventHandler(this.pcatReportViewButton_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.sqlConnectButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 255);
            this.Controls.Add(this.pcatReportViewButton);
            this.Controls.Add(this.pcatBrowseButton);
            this.Controls.Add(this.mcatReportViewButton);
            this.Controls.Add(this.mcatBrowseButton);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sqlConnectButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Find Matches";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OpenSheetFile;
        private System.Windows.Forms.Button sqlConnectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button mcatBrowseButton;
        private System.Windows.Forms.Button mcatReportViewButton;
        private System.Windows.Forms.Button pcatBrowseButton;
        private System.Windows.Forms.Button pcatReportViewButton;
    }
}


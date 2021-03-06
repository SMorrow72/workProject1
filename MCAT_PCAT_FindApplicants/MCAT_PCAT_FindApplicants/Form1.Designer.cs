﻿namespace MCAT_PCAT_FindApplicants
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
            this.OpenSheetFile = new System.Windows.Forms.OpenFileDialog();
            this.sqlConnectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.reportViewButton = new System.Windows.Forms.Button();
            this.emailButton = new System.Windows.Forms.Button();
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
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(108, 175);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 8;
            this.browseButton.Text = "Browse...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Visible = false;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // reportViewButton
            // 
            this.reportViewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportViewButton.Location = new System.Drawing.Point(90, 139);
            this.reportViewButton.Name = "reportViewButton";
            this.reportViewButton.Size = new System.Drawing.Size(109, 33);
            this.reportViewButton.TabIndex = 9;
            this.reportViewButton.Text = "View Report";
            this.reportViewButton.UseVisualStyleBackColor = true;
            this.reportViewButton.Visible = false;
            this.reportViewButton.Click += new System.EventHandler(this.reportViewButton_Click);
            // 
            // emailButton
            // 
            this.emailButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailButton.Location = new System.Drawing.Point(90, 188);
            this.emailButton.Name = "emailButton";
            this.emailButton.Size = new System.Drawing.Size(109, 33);
            this.emailButton.TabIndex = 10;
            this.emailButton.Text = "Email";
            this.emailButton.UseVisualStyleBackColor = true;
            this.emailButton.Visible = false;
            this.emailButton.Click += new System.EventHandler(this.emailButton_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.sqlConnectButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 255);
            this.Controls.Add(this.emailButton);
            this.Controls.Add(this.reportViewButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sqlConnectButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OpenSheetFile;
        private System.Windows.Forms.Button sqlConnectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button reportViewButton;
        private System.Windows.Forms.Button emailButton;
    }
}


namespace MCAT_PCAT_FindApplicants
{
    partial class EmailForm
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
            this.toLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.subLabel = new System.Windows.Forms.Label();
            this.bodyLabel = new System.Windows.Forms.Label();
            this.subTextBox = new System.Windows.Forms.TextBox();
            this.bodyTextBox = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.salutationLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toLabel.Location = new System.Drawing.Point(25, 9);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(35, 20);
            this.toLabel.TabIndex = 0;
            this.toLabel.Text = "To: ";
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromLabel.Location = new System.Drawing.Point(25, 34);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(50, 20);
            this.fromLabel.TabIndex = 1;
            this.fromLabel.Text = "From:";
            // 
            // subLabel
            // 
            this.subLabel.AutoSize = true;
            this.subLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subLabel.Location = new System.Drawing.Point(25, 59);
            this.subLabel.Name = "subLabel";
            this.subLabel.Size = new System.Drawing.Size(67, 20);
            this.subLabel.TabIndex = 2;
            this.subLabel.Text = "Subject:";
            // 
            // bodyLabel
            // 
            this.bodyLabel.AutoSize = true;
            this.bodyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bodyLabel.Location = new System.Drawing.Point(26, 84);
            this.bodyLabel.Name = "bodyLabel";
            this.bodyLabel.Size = new System.Drawing.Size(53, 20);
            this.bodyLabel.TabIndex = 3;
            this.bodyLabel.Text = "Body: ";
            // 
            // subTextBox
            // 
            this.subTextBox.Location = new System.Drawing.Point(99, 59);
            this.subTextBox.Name = "subTextBox";
            this.subTextBox.Size = new System.Drawing.Size(415, 20);
            this.subTextBox.TabIndex = 4;
            this.subTextBox.Text = "Med School";
            // 
            // bodyTextBox
            // 
            this.bodyTextBox.Location = new System.Drawing.Point(29, 114);
            this.bodyTextBox.Multiline = true;
            this.bodyTextBox.Name = "bodyTextBox";
            this.bodyTextBox.Size = new System.Drawing.Size(484, 247);
            this.bodyTextBox.TabIndex = 5;
            // 
            // sendBtn
            // 
            this.sendBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendBtn.Location = new System.Drawing.Point(449, 367);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(64, 30);
            this.sendBtn.TabIndex = 6;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // salutationLabel
            // 
            this.salutationLabel.AutoSize = true;
            this.salutationLabel.Location = new System.Drawing.Point(96, 89);
            this.salutationLabel.Name = "salutationLabel";
            this.salutationLabel.Size = new System.Drawing.Size(85, 13);
            this.salutationLabel.TabIndex = 7;
            this.salutationLabel.Text = "Dear <Student>,";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 410);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(544, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // EmailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 432);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.salutationLabel);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.bodyTextBox);
            this.Controls.Add(this.subTextBox);
            this.Controls.Add(this.bodyLabel);
            this.Controls.Add(this.subLabel);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.toLabel);
            this.Name = "EmailForm";
            this.Text = "EmailForm";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Label subLabel;
        private System.Windows.Forms.Label bodyLabel;
        private System.Windows.Forms.TextBox subTextBox;
        private System.Windows.Forms.TextBox bodyTextBox;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.Label salutationLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}
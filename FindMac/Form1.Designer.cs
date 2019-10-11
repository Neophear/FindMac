namespace FindMac
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
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtMac = new System.Windows.Forms.TextBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblMac = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(35, 12);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 20);
            this.txtIP.TabIndex = 0;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(335, 12);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 20);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtMac
            // 
            this.txtMac.Location = new System.Drawing.Point(195, 12);
            this.txtMac.Name = "txtMac";
            this.txtMac.Size = new System.Drawing.Size(100, 20);
            this.txtMac.TabIndex = 2;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(12, 15);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(17, 13);
            this.lblIP.TabIndex = 3;
            this.lblIP.Text = "IP";
            // 
            // lblMac
            // 
            this.lblMac.AutoSize = true;
            this.lblMac.Location = new System.Drawing.Point(159, 15);
            this.lblMac.Name = "lblMac";
            this.lblMac.Size = new System.Drawing.Size(30, 13);
            this.lblMac.TabIndex = 4;
            this.lblMac.Text = "MAC";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(12, 38);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(454, 239);
            this.txtOutput.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 289);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.lblMac);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.txtMac);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtIP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtMac;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblMac;
        private System.Windows.Forms.TextBox txtOutput;

    }
}


namespace LamportServer
{
    partial class serverForm
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
            this.log = new System.Windows.Forms.TextBox();
            this.ip = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // log
            // 
            this.log.AccessibleName = "stats";
            this.log.Location = new System.Drawing.Point(13, 39);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.Size = new System.Drawing.Size(372, 254);
            this.log.TabIndex = 0;
            this.log.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ip
            // 
            this.ip.Location = new System.Drawing.Point(13, 13);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(372, 20);
            this.ip.TabIndex = 1;
            // 
            // serverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 305);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.log);
            this.Name = "serverForm";
            this.Text = "Lamport Server";
            this.Load += new System.EventHandler(this.serverForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.TextBox ip;
    }
}


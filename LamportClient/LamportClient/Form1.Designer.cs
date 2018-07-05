namespace LamportClient
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
            this.button1 = new System.Windows.Forms.Button();
            this.destination = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clock = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.TextBox();
            this.serverAddress = new System.Windows.Forms.TextBox();
            this.connect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "Send Message To";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // destination
            // 
            this.destination.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destination.Location = new System.Drawing.Point(219, 120);
            this.destination.Multiline = true;
            this.destination.Name = "destination";
            this.destination.Size = new System.Drawing.Size(166, 49);
            this.destination.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 43);
            this.label1.TabIndex = 2;
            this.label1.Text = "Clock :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // clock
            // 
            this.clock.AutoSize = true;
            this.clock.Font = new System.Drawing.Font("Cambria", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clock.Location = new System.Drawing.Point(211, 36);
            this.clock.Name = "clock";
            this.clock.Size = new System.Drawing.Size(39, 43);
            this.clock.TabIndex = 3;
            this.clock.Text = "0";
            this.clock.Click += new System.EventHandler(this.label2_Click);
            // 
            // log
            // 
            this.log.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log.Location = new System.Drawing.Point(13, 186);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.Size = new System.Drawing.Size(372, 107);
            this.log.TabIndex = 4;
            this.log.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // serverAddress
            // 
            this.serverAddress.Location = new System.Drawing.Point(13, 300);
            this.serverAddress.Name = "serverAddress";
            this.serverAddress.Size = new System.Drawing.Size(258, 20);
            this.serverAddress.TabIndex = 5;
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(277, 296);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(107, 23);
            this.connect.TabIndex = 6;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 356);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.serverAddress);
            this.Controls.Add(this.log);
            this.Controls.Add(this.clock);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.destination);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox destination;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label clock;
        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.TextBox serverAddress;
        private System.Windows.Forms.Button connect;
    }
}


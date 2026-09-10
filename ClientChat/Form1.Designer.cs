namespace ClientChat
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
            this.clientconnect = new System.Windows.Forms.Button();
            this.msg = new System.Windows.Forms.TextBox();
            this.send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clientconnect
            // 
            this.clientconnect.Location = new System.Drawing.Point(257, 39);
            this.clientconnect.Name = "clientconnect";
            this.clientconnect.Size = new System.Drawing.Size(75, 23);
            this.clientconnect.TabIndex = 0;
            this.clientconnect.Text = "connect";
            this.clientconnect.UseVisualStyleBackColor = true;
            this.clientconnect.Click += new System.EventHandler(this.clientconnect_Click);
            // 
            // msg
            // 
            this.msg.Location = new System.Drawing.Point(217, 134);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(156, 22);
            this.msg.TabIndex = 1;
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(411, 132);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(75, 23);
            this.send.TabIndex = 2;
            this.send.Text = "send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.send);
            this.Controls.Add(this.msg);
            this.Controls.Add(this.clientconnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clientconnect;
        private System.Windows.Forms.TextBox msg;
        private System.Windows.Forms.Button send;
    }
}


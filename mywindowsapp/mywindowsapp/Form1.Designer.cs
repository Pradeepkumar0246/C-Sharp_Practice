namespace mywindowsapp
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
            this.buttonName = new System.Windows.Forms.Button();
            this.labelprompt = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelgreeting = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonName
            // 
            this.buttonName.Location = new System.Drawing.Point(740, 184);
            this.buttonName.Name = "buttonName";
            this.buttonName.Size = new System.Drawing.Size(75, 23);
            this.buttonName.TabIndex = 0;
            this.buttonName.Text = "SayHello";
            this.buttonName.UseVisualStyleBackColor = true;
            this.buttonName.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelprompt
            // 
            this.labelprompt.AutoSize = true;
            this.labelprompt.Location = new System.Drawing.Point(560, 123);
            this.labelprompt.Name = "labelprompt";
            this.labelprompt.Size = new System.Drawing.Size(109, 16);
            this.labelprompt.TabIndex = 1;
            this.labelprompt.Text = "Enter Your Name";
            this.labelprompt.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(686, 120);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(231, 22);
            this.textBoxName.TabIndex = 2;
            // 
            // labelgreeting
            // 
            this.labelgreeting.AutoSize = true;
            this.labelgreeting.Location = new System.Drawing.Point(694, 256);
            this.labelgreeting.Name = "labelgreeting";
            this.labelgreeting.Size = new System.Drawing.Size(0, 16);
            this.labelgreeting.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 601);
            this.Controls.Add(this.labelgreeting);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelprompt);
            this.Controls.Add(this.buttonName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonName;
        private System.Windows.Forms.Label labelprompt;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelgreeting;
    }
}


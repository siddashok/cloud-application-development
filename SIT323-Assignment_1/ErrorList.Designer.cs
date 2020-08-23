namespace SIT323_Assignment
{
    partial class ErrorList
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.textBoxForm = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxForm2
            // 
            this.textBoxForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxForm.Location = new System.Drawing.Point(14, 37);
            this.textBoxForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxForm.Multiline = true;
            this.textBoxForm.Name = "textBoxForm2";
            this.textBoxForm.ReadOnly = true;
            this.textBoxForm.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxForm.Size = new System.Drawing.Size(1033, 664);
            this.textBoxForm.TabIndex = 0;
            this.textBoxForm.Text = "Please open a TAN file!!!";
            this.textBoxForm.TextChanged += new System.EventHandler(this.TextBoxForm2_TextChanged);
            // 
            // ErrorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 719);
            this.Controls.Add(this.textBoxForm);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ErrorList";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBoxForm;
    }
}
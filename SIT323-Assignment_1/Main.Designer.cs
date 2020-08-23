namespace SIT323_Assignment
{
    partial class TaskHome
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_File_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_File_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTool_Validate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Validate_Allocations = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_View = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_View_Error = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Help_About = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_File,
            this.MenuTool_Validate,
            this.MenuItem_View,
            this.MenuItem_Help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(763, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItem_File
            // 
            this.MenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_File_Open,
            this.MenuItem_File_Exit});
            this.MenuItem_File.Name = "MenuItem_File";
            this.MenuItem_File.Size = new System.Drawing.Size(39, 21);
            this.MenuItem_File.Text = "File";
            // 
            // MenuItem_File_Open
            // 
            this.MenuItem_File_Open.Name = "MenuItem_File_Open";
            this.MenuItem_File_Open.Size = new System.Drawing.Size(160, 22);
            this.MenuItem_File_Open.Text = "Open TAFF File";
            this.MenuItem_File_Open.Click += new System.EventHandler(this.File_open_click);
            // 
            // MenuItem_File_Exit
            // 
            this.MenuItem_File_Exit.Name = "MenuItem_File_Exit";
            this.MenuItem_File_Exit.Size = new System.Drawing.Size(160, 22);
            this.MenuItem_File_Exit.Text = "Exit";
            this.MenuItem_File_Exit.Click += new System.EventHandler(this.Exit_click);
            // 
            // MenuTool_Validate
            // 
            this.MenuTool_Validate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Validate_Allocations});
            this.MenuTool_Validate.Name = "MenuTool_Validate";
            this.MenuTool_Validate.Size = new System.Drawing.Size(67, 21);
            this.MenuTool_Validate.Text = "Validate";
            // 
            // MenuItem_Validate_Allocations
            // 
            this.MenuItem_Validate_Allocations.Enabled = false;
            this.MenuItem_Validate_Allocations.Name = "MenuItem_Validate_Allocations";
            this.MenuItem_Validate_Allocations.Size = new System.Drawing.Size(139, 22);
            this.MenuItem_Validate_Allocations.Text = "Allocations";
            this.MenuItem_Validate_Allocations.Click += new System.EventHandler(this.ValidateAllocation_open_click);
            // 
            // MenuItem_View
            // 
            this.MenuItem_View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_View_Error});
            this.MenuItem_View.Name = "MenuItem_View";
            this.MenuItem_View.Size = new System.Drawing.Size(47, 21);
            this.MenuItem_View.Text = "View";
            // 
            // MenuItem_View_Error
            // 
            this.MenuItem_View_Error.Name = "MenuItem_View_Error";
            this.MenuItem_View_Error.Size = new System.Drawing.Size(129, 22);
            this.MenuItem_View_Error.Text = "Error List";
            this.MenuItem_View_Error.Click += new System.EventHandler(this.Error_open_click);
            // 
            // MenuItem_Help
            // 
            this.MenuItem_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Help_About});
            this.MenuItem_Help.Name = "MenuItem_Help";
            this.MenuItem_Help.Size = new System.Drawing.Size(47, 21);
            this.MenuItem_Help.Text = "Help";
            // 
            // MenuItem_Help_About
            // 
            this.MenuItem_Help_About.Name = "MenuItem_Help_About";
            this.MenuItem_Help_About.Size = new System.Drawing.Size(178, 22);
            this.MenuItem_Help_About.Text = "About Allocations";
            this.MenuItem_Help_About.Click += new System.EventHandler(this.Help_open_click);
            // 
            // textBox_Valid
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 25);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox_Valid";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(763, 363);
            this.textBox1.TabIndex = 3;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 388);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Home";
            this.Text = "Allocations - Assessment Task 1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_File_Open;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_File_Exit;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_View;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_View_Error;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Help_About;
        public System.Windows.Forms.ToolStripMenuItem MenuTool_Validate;
        public System.Windows.Forms.ToolStripMenuItem MenuItem_Validate_Allocations;
        public System.Windows.Forms.TextBox textBox1;
    }
}


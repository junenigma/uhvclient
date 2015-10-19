namespace UHVClient
{
    partial class MainMenu
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
            this.skinUI1 = new DotNetSkin.SkinUI();
            this.任务列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.常规ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.弹出安全U盘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.任务列表ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.定期检查ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据抄录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinUI1
            // 
            this.skinUI1.Active = true;
            this.skinUI1.Button = true;
            this.skinUI1.Caption = true;
            this.skinUI1.CheckBox = true;
            this.skinUI1.ComboBox = true;
            this.skinUI1.ContextMenu = true;
            this.skinUI1.DisableTag = 999;
            this.skinUI1.Edit = true;
            this.skinUI1.GroupBox = true;
            this.skinUI1.ImageList = null;
            this.skinUI1.MaiMenu = true;
            this.skinUI1.Panel = true;
            this.skinUI1.Progress = true;
            this.skinUI1.RadioButton = true;
            this.skinUI1.ScrollBar = true;
            this.skinUI1.SkinFile = null;
            this.skinUI1.SkinSteam = null;
            this.skinUI1.Spin = true;
            this.skinUI1.StatusBar = true;
            this.skinUI1.SystemMenu = true;
            this.skinUI1.TabControl = true;
            this.skinUI1.Text = "Mycontrol1=edit\r\nMycontrol2=edit\r\n";
            this.skinUI1.ToolBar = true;
            this.skinUI1.TrackBar = true;
            // 
            // 任务列表ToolStripMenuItem
            // 
            this.任务列表ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.常规ToolStripMenuItem,
            this.弹出安全U盘ToolStripMenuItem});
            this.任务列表ToolStripMenuItem.Name = "任务列表ToolStripMenuItem";
            this.任务列表ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.任务列表ToolStripMenuItem.Text = "数据管理";
            // 
            // 常规ToolStripMenuItem
            // 
            this.常规ToolStripMenuItem.Name = "常规ToolStripMenuItem";
            this.常规ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.常规ToolStripMenuItem.Text = "选择安全U盘";
            this.常规ToolStripMenuItem.Click += new System.EventHandler(this.常规ToolStripMenuItem_Click);
            // 
            // 弹出安全U盘ToolStripMenuItem
            // 
            this.弹出安全U盘ToolStripMenuItem.Name = "弹出安全U盘ToolStripMenuItem";
            this.弹出安全U盘ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.弹出安全U盘ToolStripMenuItem.Text = "弹出安全U盘";
            this.弹出安全U盘ToolStripMenuItem.Click += new System.EventHandler(this.弹出安全U盘ToolStripMenuItem_Click);
            // 
            // 任务列表ToolStripMenuItem1
            // 
            this.任务列表ToolStripMenuItem1.Name = "任务列表ToolStripMenuItem1";
            this.任务列表ToolStripMenuItem1.Size = new System.Drawing.Size(68, 21);
            this.任务列表ToolStripMenuItem1.Text = "巡检管理";
            // 
            // 定期检查ToolStripMenuItem
            // 
            this.定期检查ToolStripMenuItem.Name = "定期检查ToolStripMenuItem";
            this.定期检查ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.定期检查ToolStripMenuItem.Text = "定期检查";
            // 
            // 数据抄录ToolStripMenuItem
            // 
            this.数据抄录ToolStripMenuItem.Name = "数据抄录ToolStripMenuItem";
            this.数据抄录ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.数据抄录ToolStripMenuItem.Text = "数据抄录";
            // 
            // 系统设置ToolStripMenuItem
            // 
            this.系统设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于系统ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.系统设置ToolStripMenuItem.Name = "系统设置ToolStripMenuItem";
            this.系统设置ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.系统设置ToolStripMenuItem.Text = "系统设置";
            // 
            // 关于系统ToolStripMenuItem
            // 
            this.关于系统ToolStripMenuItem.Name = "关于系统ToolStripMenuItem";
            this.关于系统ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.关于系统ToolStripMenuItem.Text = "关于系统";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.任务列表ToolStripMenuItem,
            this.任务列表ToolStripMenuItem1,
            this.定期检查ToolStripMenuItem,
            this.数据抄录ToolStripMenuItem,
            this.系统设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1089, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 561);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "特高压换流站智能管理系统作业管理程序";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DotNetSkin.SkinUI skinUI1;
        private System.Windows.Forms.ToolStripMenuItem 任务列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 常规ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 弹出安全U盘ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 任务列表ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 定期检查ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据抄录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;

        private string _diskSign;
        public string DiskSign
        {
            set { this._diskSign = value; }
            get { return this._diskSign; }
        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UHVClient
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void 常规ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetUDiskInfo ud = new GetUDiskInfo();
            //ud.MdiParent = this;
            //ud.WindowState = FormWindowState.Maximized;
            ud.Owner = this;
            ud.Show(this);
        }

        private void 弹出安全U盘ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

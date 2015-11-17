using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Security.AccessControl;
using System.Text.RegularExpressions;

namespace UHVClient
{
    public partial class GetUDiskInfo : Form
    {
        public GetUDiskInfo()
        {
            InitializeComponent();
        }

        private void GetUDiskInfo_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            var drv = System.IO.DriveInfo.GetDrives();
            foreach (var item in drv)
            {
                if (item.IsReady)
                {
                    if ((item.DriveType == DriveType.Removable || item.DriveType == DriveType.Fixed) && "交换区" == item.VolumeLabel)
                    {
                        listBox1.Items.Add(item.ToString());
                    }
                }
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                MainMenu frm1 = (MainMenu)this.Owner;
                frm1.DiskSign = listBox1.Items[index].ToString();

                //GetDataInfo di = new GetDataInfo();
                //di.MdiParent = frm1;
                //di.WindowState = FormWindowState.Maximized;
                //di.Show();

                this.Close();
            }
        }
    }
}

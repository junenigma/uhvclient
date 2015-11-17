using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace UHVClient
{
    public partial class GetDataInfo : Form
    {
        public GetDataInfo()
        {
            InitializeComponent();
        }

        private void GetDataInfo_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            //this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            //this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.WindowState = FormWindowState.Maximized;

            MainMenu frm1 = (MainMenu)this.MdiParent;
            //this.textBox1.Text = frm1.DiskSign;

            ListFiles(new DirectoryInfo(frm1.DiskSign));
        }

        /// <summary> 
        /// 递归列举出指定目录的所有文件         /// </summary> 
        public void ListFiles(FileSystemInfo info)
        {
            {
                if (!info.Exists) return;
                DirectoryInfo dir = info as DirectoryInfo;                 //不是目录 
                if (dir == null) return;
                FileSystemInfo[] files = dir.GetFileSystemInfos();
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo file = files[i] as FileInfo;                     //是文件 
                    if (file != null)
                    {
                        if ((file.FullName.Substring(file.FullName.LastIndexOf(".")) == ".db"))
                        {
                            Config.DatabaseFile = file.FullName;
                            this.statusStrip1.Text = Config.DataSource;
                            try
                            {
                                using (SQLiteConnection conn = new SQLiteConnection(Config.DataSource))
                                {
                                    using (SQLiteCommand cmd = new SQLiteCommand())
                                    {
                                        conn.Open();
                                        cmd.Connection = conn;

                                        SQLiteHelper sh = new SQLiteHelper(cmd);

                                        DataTable dt = sh.GetTableList();
                                        dataGridView1.DataSource = dt;

                                        conn.Close();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                    }
                    //else
                    //{
                    //    ListFiles(files[i]);
                    //}
                }
            }
        }
    }
}

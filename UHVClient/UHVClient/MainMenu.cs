using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UHVClient
{
    public partial class MainMenu : Form
    {
        BaseClass bc = new BaseClass();
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

        private void 数据初始化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 判断是否已经有控件打开，如果没有new，否则直接引用
            InitData ud = new InitData();
            //ud.MdiParent = this;
            //ud.WindowState = FormWindowState.Maximized;
            ud.Owner = this;
            //ud.MdiParent = this;
            ud.Show(this);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            bc.listFolders(toolStripComboBox1);

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            string[] weeks = new string[] { "周日", "周一", "周二", "周三", "周四", "周五", "周六" };
            foreach (string week in weeks)
            {
                DataGridViewTextBoxColumn dgvtbc = new DataGridViewTextBoxColumn();
                dgvtbc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvtbc.Width = 110;
                dgvtbc.HeaderText = week;
                dataGridView1.Columns.Add(dgvtbc);
            }
            dataGridView1.Rows.Add(6);

            int count = 0;
            int w = Convert.ToInt16(DateTime.Parse(DateTime.Now.ToString("yyyy年MM月01日")).DayOfWeek);
            int month = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (i > 0)
                {
                    w = 0;
                }
                for (int j = w; j < dataGridView1.ColumnCount; j++)
                {
                    count++;
                    if (count > 31) break;
                    dataGridView1.Rows[i].Cells[j].Value = count.ToString("00");
                    dataGridView1.Rows[i].Cells[j].Style.Alignment = DataGridViewContentAlignment.TopRight;
                    dataGridView1.Rows[i].Height = 90;
                    if (count == DateTime.Now.Day)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[j];
                        //dataGridView1.Rows[i].Cells[j].Value += @"
                        //23日月巡";
                    }
                }
            }




        }

        private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void 记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }


        public void listFolders(ToolStripComboBox tscb)//获取本地磁盘目录
        {
            string[] logicdrives = System.IO.Directory.GetLogicalDrives();
            for (int i = 0; i < logicdrives.Length; i++)
            {
                tscb.Items.Add(logicdrives[i]);
                tscb.SelectedIndex = 0;
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bc.GetPath(toolStripComboBox1.Text, imageList1, listView1, 0);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            bc.GOBack(listView1, imageList1, toolStripComboBox1.Text);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string pp = listView1.SelectedItems[0].Text;
                bc.GetPath(pp.Trim(), imageList1, listView1, 1);
            }
            catch
            {
                MessageBox.Show("无法打开此文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 导入巡检记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 判断是否已经有控件打开，如果没有new，否则直接引用
            ImportInspectRecord ud = new ImportInspectRecord();
            //ud.MdiParent = this;
            //ud.WindowState = FormWindowState.Maximized;
            ud.Owner = this;
            //ud.MdiParent = this;
            ud.Show(this);
        }

        private void 导入定期检查记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 判断是否已经有控件打开，如果没有new，否则直接引用
            ImportScheduleRecord ud = new ImportScheduleRecord();
            //ud.MdiParent = this;
            //ud.WindowState = FormWindowState.Maximized;
            ud.Owner = this;
            //ud.MdiParent = this;
            ud.Show(this);
        }
    }
}

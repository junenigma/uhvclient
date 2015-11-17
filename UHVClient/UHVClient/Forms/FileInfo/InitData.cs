using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UHVClient
{
    public partial class InitData : Form
    {
        DataSet ds = new DataSet();
        int max = 0;
        Thread thread = null;

        public InitData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;

            try
            {
                using (SqlConnection _sqlConn = new SqlConnection(Config.SQLSource))
                {
                    using (SqlCommand _sqlComm = new SqlCommand())
                    {
                        _sqlConn.Open();
                        _sqlComm.Connection = _sqlConn;

                        _sqlComm.CommandText = "select devbid,devtyid,devrunnumber,devbmodel,devbname,fatherbasicid,remark from t_DeviceBasicBook";
                        _sqlComm.CommandType = CommandType.Text;


                        SqlDataAdapter _sqlda = new SqlDataAdapter(_sqlComm);
                        _sqlda.Fill(ds);

                        max = ds.Tables[0].Rows.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            progressBar1.Minimum = 0;
            progressBar1.Maximum = max;

            thread = new Thread(InitDatas);
            thread.IsBackground = true;
            thread.Name = "jun";
            thread.Start();
        }

        private void InitData_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            string[] list = new string[] { "设备基础台账", "设备缺陷库", "巡检作业任务", "巡检作业标准" };

            int x = 0, y = 0;
            foreach (string item in list)
            {
                CheckBox cb = new CheckBox();
                cb.Size = new Size(244, 20);
                cb.Text = item;
                cb.Location = new Point(x, y);
                listBox1.Controls.Add(cb);
                y += 20;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process tt = System.Diagnostics.Process.GetProcessById(System.Diagnostics.Process.GetCurrentProcess().Id);
            //tt.Kill();

            //this.Close();
            ds.Clear();
            if (thread.IsAlive)
            {
                try
                {
                    thread.Abort();
                    thread.Join();

                    this.BeginInvoke(new MethodInvoker(delegate ()
                    {
                        button1.Enabled = true;
                    }));
                }
                catch { }

            }
        }

        private void InitDatas()
        {
            SetLableText("数据初始化中...");
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    StringBuilder _str = new StringBuilder();
                    int _count = max;
                    foreach (DataRow _row in ds.Tables[0].Rows)
                    {
                        if (_count % 1000 == 0)
                        {
                            using (SQLiteConnection _conn = new SQLiteConnection(Config.DataSource))
                            {
                                using (SQLiteCommand _comm = new SQLiteCommand())
                                {
                                    _conn.Open();
                                    _comm.CommandType = CommandType.Text;
                                    _comm.Connection = _conn;
                                    _comm.CommandText = _str.ToString();
                                    _comm.ExecuteNonQuery();
                                }
                            }
                            _str.Remove(0, _str.Length);
                        }

                        SetLableText(string.Format("当前行：{0}，已完成行：{1}，完成比例：{2}%", _count, max - _count, (Convert.ToDecimal(max - _count) / Convert.ToDecimal(max) * 100).ToString("f0")));
                        SetPbleText(max - _count);

                        _str.AppendFormat(@"insert into t_DeviceBasicBook(DBB_ID,DT_ID,DBB_NUM,DBB_MODEL,DBB_NAME,DBB_FATHER_ID,REMARK)
                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", _row[0], _row[1], _row[2], _row[3], _row[4], _row[5], _row[6]);
                        _count--;
                    }
                }
            }
            catch{ }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            SetLableText("数据初始化完成！");
            try
            {
                this.BeginInvoke(new MethodInvoker(delegate ()
                {
                    button1.Enabled = true;
                }));
            }
            catch { }
        }

        delegate void labDelegate(string str);

        private void SetLableText(string str)
        {
            if (label1.InvokeRequired)
            {
                try
                {
                    Invoke(new labDelegate(SetLableText), new string[] { str });
                }
                catch { }
            }
            else
            {
                label1.Text = str;
            }
        }

        delegate void pbDelegate(int value);

        private void SetPbleText(int value)
        {
            if (progressBar1.InvokeRequired)
            {
                try
                {
                    Invoke(new pbDelegate(SetPbleText), new object[] { value });
                }
                catch { }
            }
            else
            {
                progressBar1.Value = value;
            }
        }
    }
}

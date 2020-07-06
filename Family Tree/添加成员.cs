using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Family_Tree
{
    public partial class 添加成员 : Form
    {
        public 添加成员()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = DESKTOP-OND28LD\SQLEXPRESS1; Initial Catalog = ZP; User ID = sa; Password = 123456";
            StringBuilder sb = new StringBuilder();
            string sql = @"INSERT INTO member(id,name,sex,ids,birth,death,idf,idzp) VALUES('" + txt1.Text + "','" + txt2.Text + "','" + txt3.Text + "','" + txt4.Text + "','" + txt5.Text + "','" + txt6.Text + "','" + txt7.Text + "','" + txt8.Text + "')";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("信息已存入数据库！");
            }
            catch (Exception msg)
            {
                MessageBox.Show("出问题了！\n出错原因：" + msg.Message);
            }
            conn.Close();
            sb.Append("你输入的成员信息是：");
            sb.Append("\nID：" + txt1.Text);
            sb.Append("\n姓名：" + txt2.Text);
            sb.Append("\n性别：" + txt3.Text);
            sb.Append("\n配偶id：" + txt4.Text);
            sb.Append("\n出生日期：" + txt5.Text);
            sb.Append("\n死亡日期：" + txt6.Text);
            sb.Append("\n父亲id：" + txt7.Text);
            sb.Append("\n族谱id：" + txt8.Text);
            MessageBox.Show(sb.ToString(), "请检查",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           修删成员 m = new 修删成员();
           m.Show();
        }
    }
}

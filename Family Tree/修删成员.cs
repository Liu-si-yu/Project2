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
    public partial class 修删成员 : Form
    {
        public 修删成员()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = DESKTOP-OND28LD\SQLEXPRESS1; Initial Catalog = ZP; User ID = sa; Password = 123456";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sql = @"SELECT id FROM member WHERE id= '" + com.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                com.Text = dr[0].ToString();

            }
            dr.Close();

            string sql1 = @"SELECT name FROM member WHERE id= '" + com.Text + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                txt1.Text = dr1[0].ToString();
            }
            dr1.Close();

            string sql2 = @"SELECT sex FROM member WHERE id= '" + com.Text + "'";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                txt2.Text = dr2[0].ToString();
            }
            dr2.Close();

            string sql3 = @"SELECT ids FROM member WHERE id= '" + com.Text + "'";
            SqlCommand cmd3 = new SqlCommand(sql3, conn);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                txt3.Text = dr3[0].ToString();
            }
            dr3.Close();

            string sql4 = @"SELECT birth FROM member WHERE id= '" + com.Text + "'";
            SqlCommand cmd4 = new SqlCommand(sql4, conn);
            SqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                txt4.Text = dr4[0].ToString();
            }
            dr4.Close();

            string sql5 = @"SELECT death FROM member WHERE id= '" + com.Text + "'";
            SqlCommand cmd5 = new SqlCommand(sql5, conn);
            SqlDataReader dr5 = cmd5.ExecuteReader();
            while (dr5.Read())
            {
                txt5.Text = dr5[0].ToString();
            }
            dr5.Close();

            string sql6 = @"SELECT idf FROM member WHERE id= '" + com.Text + "'";
            SqlCommand cmd6 = new SqlCommand(sql6, conn);
            SqlDataReader dr6 = cmd6.ExecuteReader();
            while (dr6.Read())
            {
                txt6.Text = dr6[0].ToString();
            }
            dr6.Close();

            string sql7 = @"SELECT idzp FROM member WHERE id= '" + com.Text + "'";
            SqlCommand cmd7 = new SqlCommand(sql7, conn);
            SqlDataReader dr7 = cmd7.ExecuteReader();
            while (dr7.Read())
            {
                txt7.Text = dr7[0].ToString();
            }
            dr7.Close();


            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = DESKTOP-OND28LD\SQLEXPRESS1; Initial Catalog = ZP; User ID = sa; Password = 123456";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sql = @"DELETE  FROM member WHERE id= '" + com.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("删除生成成功！");
                conn.Close();
                this.Close();
            }
            catch (Exception msg)
            {
                MessageBox.Show("出问题了！\n出错原因：" + msg.Message);
            }
            conn.Close();
        }

        private void 修删成员_Load(object sender, EventArgs e)
        {
            // TODO:  这行代码将数据加载到表“zPDataSet.member”中。您可以根据需要移动或删除它。
       //     this.memberTableAdapter.Fill(this.zPDataSet.member);
            string connString = @"Data Source = DESKTOP-OND28LD\SQLEXPRESS1; Initial Catalog = ZP; User ID = sa; Password = 123456";
            string sql = @"SELECT id FROM member";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "id");
            com.DataSource = ds.Tables["id"];
            com.DisplayMember = ds.Tables["id"].Columns[0].ToString();
            conn.Close();

        }

        private void com_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //先删除
            string connString = @"Data Source = DESKTOP-OND28LD\SQLEXPRESS1; Initial Catalog = ZP; User ID = sa; Password = 123456";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sql = @"DELETE  FROM member WHERE id= '" + com.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
            //    MessageBox.Show("删除生成成功！");
             //   conn.Close();
                
            }
            catch (Exception msg)
            {
           //     MessageBox.Show("出问题了！\n出错原因：" + msg.Message);
            }
            
           //再添加
            StringBuilder sb = new StringBuilder();
            string sql1 = @"INSERT INTO member(id,name,sex,ids,birth,death,idf,idzp) VALUES('" + com.Text + "','" + txt1.Text + "','" + txt2.Text + "','" + txt3.Text + "','" + txt4.Text + "','" + txt5.Text + "','" + txt6.Text + "','" + txt7.Text + "')";
            SqlConnection conn1 = new SqlConnection(connString);
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            try
           {
                cmd1.ExecuteNonQuery();
        //        MessageBox.Show("信息已存入数据库！");
            }
            catch (Exception msg)
            {
           //     MessageBox.Show("出问题了！\n出错原因：" + msg.Message);
            }
            conn1.Close();
            sb.Append("你输入的成员信息是：");
            sb.Append("\nID：" + com.Text);
            sb.Append("\n姓名：" + txt1.Text);
            sb.Append("\n性别：" + txt2.Text);
            sb.Append("\n配偶id：" + txt3.Text);
            sb.Append("\n出生日期：" + txt4.Text);
            sb.Append("\n死亡日期：" + txt5.Text);
            sb.Append("\n父亲id：" + txt6.Text);
            sb.Append("\n族谱id：" + txt7.Text);
            MessageBox.Show(sb.ToString(), "请检查",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        
        }
    }
}

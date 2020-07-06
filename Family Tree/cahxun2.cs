using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 综合查询
{
    public partial class cahxun2 : Form
    {
        string sb;
        public cahxun2(string sb)
        {
            this.sb = sb;
            InitializeComponent();

            if (com.Text == null)
                com.Text = sb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int xd = 0;
            int ids = 0;
       //     string idf = "0";
       //     string mo = "无";
     //       string fm = "无";
            string connString = @"Data Source = DESKTOP-OND28LD\SQLEXPRESS1; Initial Catalog = ZP; User ID = sa; Password = 123456";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            //配偶id
            string sql = @"SELECT ids FROM member WHERE id= '" + com.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label7.Text = dr[0].ToString();
            }
            dr.Close();
            //找父亲id
            string sql1 = @"SELECT idf FROM member WHERE id= '" + com.Text + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                label3.Text = dr1[0].ToString();

            }
            dr1.Close();

            //通过父亲找兄弟
            string sql2 = @"SELECT id FROM member WHERE idf= '" + label3.Text + "'";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                xd++;
            }
            dr2.Close();
            xd = xd - 1;
            button2.Text = xd.ToString();
            //找子女
            string sql3 = @"SELECT id FROM member WHERE idf= '" + com.Text + "'";
            SqlCommand cmd3 = new SqlCommand(sql3, conn);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                ids++;
            }
            dr3.Close();
            button3.Text = ids.ToString();


            //找配偶
            string sql4 = @"SELECT name FROM member WHERE id= '" + label7.Text + "'";
            SqlCommand cmd4 = new SqlCommand(sql4, conn);
            SqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                label7.Text = dr4[0].ToString();
            }
            dr4.Close();

            //找母亲id
            string sql6 = @"SELECT id FROM member WHERE ids= '" + label3.Text + "'";
            SqlCommand cmd6 = new SqlCommand(sql6, conn);
            SqlDataReader dr6 = cmd6.ExecuteReader();
            while (dr6.Read())
            {
                label5.Text = dr6[0].ToString();
            }
            dr6.Close();
            //找父亲
            string sql5 = @"SELECT name FROM member WHERE id= '" + label3.Text + "'";
            SqlCommand cmd5 = new SqlCommand(sql5, conn);
            SqlDataReader dr5 = cmd5.ExecuteReader();
            while (dr5.Read())
            {
                label3.Text = dr5[0].ToString();
            }
            dr5.Close();
            

            //找母亲
            string sql7 = @"SELECT name FROM member WHERE id= '" + label5.Text + "'";
            SqlCommand cmd7 = new SqlCommand(sql7, conn);
            SqlDataReader dr7 = cmd7.ExecuteReader();
            while (dr7.Read())
            {
                label5.Text = dr7[0].ToString();
            }
            dr7.Close();

            label3.Visible = true;
            label5.Visible = true;
            label7.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
        }    
           
    }
}

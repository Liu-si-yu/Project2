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
    public partial class cahxun1 : Form
    {
        string sb;
        public cahxun1()
        {
            
            InitializeComponent();

        
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = DESKTOP-OND28LD\SQLEXPRESS1; Initial Catalog = ZP; User ID = sa; Password = 123456";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sql = @"SELECT id FROM member WHERE id= '" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label2.Text = dr[0].ToString();

            }
            dr.Close();

            string sql1 = @"SELECT name FROM member WHERE id= '" + textBox1.Text + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                label10.Text = dr1[0].ToString();
            }
            dr1.Close();

            string sql2 = @"SELECT sex FROM member WHERE id= '" + textBox1.Text + "'";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                label13.Text = dr2[0].ToString();
            }
            dr2.Close();

            string sql3 = @"SELECT ids FROM member WHERE id= '" + textBox1.Text + "'";
            SqlCommand cmd3 = new SqlCommand(sql3, conn);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                label14.Text = dr3[0].ToString();
            }
            dr3.Close();

            string sql4 = @"SELECT birth FROM member WHERE id= '" + textBox1.Text + "'";
            SqlCommand cmd4 = new SqlCommand(sql4, conn);
            SqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                label15.Text = dr4[0].ToString();
            }
            dr4.Close();

            string sql5 = @"SELECT death FROM member WHERE id= '" + textBox1.Text + "'";
            SqlCommand cmd5 = new SqlCommand(sql5, conn);
            SqlDataReader dr5 = cmd5.ExecuteReader();
            while (dr5.Read())
            {
                label16.Text = dr5[0].ToString();
            }
            dr5.Close();

            string sql6 = @"SELECT idf FROM member WHERE id= '" + textBox1.Text + "'";
            SqlCommand cmd6 = new SqlCommand(sql6, conn);
            SqlDataReader dr6 = cmd6.ExecuteReader();
            while (dr6.Read())
            {
                label17.Text = dr6[0].ToString();
            }
            dr6.Close();

            string sql7 = @"SELECT idzp FROM member WHERE id= '" + textBox1.Text + "'";
            SqlCommand cmd7 = new SqlCommand(sql7, conn);
            SqlDataReader dr7 = cmd7.ExecuteReader();
            while (dr7.Read())
            {
                label19.Text = dr7[0].ToString();
            }
            dr7.Close();


            conn.Close();

            label2.Visible = true;
            label10.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            label19.Visible = true;
            button2.Visible = true;

        }

        private void cahxun1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cahxun2 w = new cahxun2(textBox1.Text);
            w.Show();
        }

     
    }
}

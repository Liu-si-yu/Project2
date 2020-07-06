using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 综合查询;
using 族谱;

namespace Family_Tree
{
    public partial class normol : Form
    {
        public normol()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cahxun1 m = new cahxun1();
            m.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            查看和删除族谱信息 hu = new 查看和删除族谱信息("1");
                hu.Show();
        }
    }
}

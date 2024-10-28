using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class Form1 : Form
    {
        int i = 1;
        int r = 2;
        int o = 3;
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Run(i, ref r, out o);
            textBox1.Text = i.ToString();
            textBox2.Text = r.ToString();
            textBox3.Text = o.ToString();
        }

        private void Run(int i, ref int r, out int o)
        {
            i += 100;
            r += 100  + o;
            o = 10 + r;
        }
        
        

    }
}

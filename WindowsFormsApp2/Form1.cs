using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ushort sNumber = ushort.Parse(textBox1.Text);

                lblshort.Text = sNumber.ToString();
                lblexception.Text = "-";
            }
            catch (Exception ex)
            { 
                lblexception.Text = ex.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int sNumber = int.Parse(textBox1.Text);

                lblshort.Text = sNumber.ToString();
                lblexception.Text = "-";
            }
            catch (Exception ex)
            {
                lblexception.Text = ex.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                double sNumber = double.Parse(textBox1.Text);

                lblshort.Text = sNumber.ToString();
                lblexception.Text = "-";
            }
            catch (Exception ex)
            {
                lblexception.Text = ex.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            short sNUmber = 0;
            int iNUmber = 0;
            double dNUmber = 0;

            lblexception.Text = "";


            if (short.TryParse(textBox1.Text, out sNUmber))
            {
                lblshort.Text = sNUmber.ToString();
            }
            else if(int.TryParse(textBox1.Text, out iNUmber))
            {
                lblint.Text = iNUmber.ToString();   
            }
            else if(double.TryParse(textBox1.Text, out dNUmber))
            {
                lbldouble.Text = dNUmber.ToString();        
            }
            else
            {
                lblexception.Text = "변환 x";
            }
        }
    }
}

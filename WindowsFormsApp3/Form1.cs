using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int inuma = int.Parse(textBox2.Text);
            int inumb = int.Parse(textBox3.Text);

            //int iResult = inuma + inumb;

            //textBox1.Text = iResult.ToString(); 

            textBox1.Text = fPlus(inuma, inumb).ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int inuma = int.Parse(textBox2.Text);
            int inumb = int.Parse(textBox3.Text);

            int iResult = inuma - inumb;

            textBox1.Text = iResult.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int inuma = int.Parse(textBox2.Text);
            int inumb = int.Parse(textBox3.Text);

            int iResult = inuma * inumb;

            textBox1.Text = iResult.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int inuma = int.Parse(textBox2.Text);
            int inumb = int.Parse(textBox3.Text);

            int iResult = inuma / inumb;

            textBox1.Text = iResult.ToString();
        }

        private int fPlus(int iA, int iB)
        {
            int iResult = 0;

            iResult = iA + iB;

            return 0;
        }
    }
}

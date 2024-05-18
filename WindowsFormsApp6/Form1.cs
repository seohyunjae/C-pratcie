using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ArrayTest();

            ArrayClassTest();
        }

        private void ArrayTest()
        {
            int iDay1 = 0;

            int[] iArrayTest1 = { 1, 2, 3, 4, 5 };

        }

        private void ArrayClassTest()
        {
            int[] iArrayTest1 = { 1, 2, 3, 4, 5 };

            Array.Resize(ref iArrayTest1, 10);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] iArrayTest1 = { 1, 2, 3, 4, 5 ,70 ,60};


            dgDay["colDay1", 0].Value = iArrayTest1[0];
            dgDay["colDay2", 0].Value = iArrayTest1[1];
            dgDay["colDay3", 0].Value = iArrayTest1[2];
            dgDay["colDay4", 0].Value = iArrayTest1[3];
            dgDay["colDay5", 0].Value = iArrayTest1[4];
            dgDay["colDay6", 0].Value = iArrayTest1[5];
            dgDay["colDay7", 0].Value = iArrayTest1[6];

        }
    }
}

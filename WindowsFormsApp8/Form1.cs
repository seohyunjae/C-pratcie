using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnwhileResult_Click(object sender, EventArgs e)
        {
            // 1-45 6개

            int[] iArray = new int[6];
            int iCount = 0;

            StringBuilder sb = new StringBuilder();
            Random rd = new Random();


            // iArray가 다 안차면 계속 진행
            while (Array.IndexOf(iArray, 0) != -1)
            {
                int iNumber = rd.Next(1, 46)
                int it = Array.IndexOf(iArray, 1);
            }
        }
    }
}

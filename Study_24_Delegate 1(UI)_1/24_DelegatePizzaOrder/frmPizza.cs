using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24_DelegatePizzaOrder
{
    public partial class frmPizza : Form
    {

        public delegate int delPizzaComplete(string strResult, int Time);
        public event delPizzaComplete eventdelPizzaComplete; // delegate event 선언


        public frmPizza()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void fPizzarCheck()
        {
            int i = 0;

            while (i < 10) 
            {
                i++;

                lboxMake.Items.Add(i.ToString());

                //this.Refresh();
                Thread.Sleep(1000);
            }

            eventdelPizzaComplete("완료", 1000);
        }
    }
}

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

namespace WindowsFormsApp13
{
    public partial class Play : Form
    {
        string _strPlayerName = string.Empty;
        public Play()
        {
            InitializeComponent();
        }
        public Play(string strPlayerName)
        {
            InitializeComponent();

            lblPlayerName.Text = _strPlayerName = strPlayerName;
        }

        public void test()
        {
            int ivar = 0; ;

            Random rd = new Random();

            while (pbarPlayer.Value < 100)
            {
                ivar = rd.Next(1, 11);
                //pbarPlayer.Value = (pbarPlayer.Value + ivar > 100)
                if (pbarPlayer.Value + ivar > 100)
                {
                    pbarPlayer.Value = 100;
                }
                else
                {
                    pbarPlayer.Value = pbarPlayer.Value + ivar;
                }

                lblProcess.Text = string.Format("진행 상황 표시 : {0}%", pbarPlayer.Value);
                this.Refresh();
                Thread.Sleep(300);
            }
        }
    }
}

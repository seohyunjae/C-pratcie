using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace _26_Thread
{
    public partial class Form1 : Form
    {
        private enum enumPlayer
        {
            아이린,
            슬기,
            웬디,
            조이,
            예리,
        }

        int _locationX = 0;
        int _locationY = 0;

        List<Play> lplay = new List<Play>();

        public Form1()
        {
            InitializeComponent();

            _locationX = this.Location.X;
            _locationY = this.Location.Y;
            this.FormClosing += Form1_FormClosing;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _locationX = this.Location.X + this.Width;
            _locationY = this.Location.Y;

            for (int i = 0; i < numPlayerCount.Value; i++)
            {
                Play pl = new Play(((enumPlayer)i).ToString());
                pl.Location = new Point(_locationX, _locationY + pl.Height * i);
                pl.eventdelMessage += Pl_eventdelMessage;

                pl.Show();

                pl.fThreadStart();

                lplay.Add(pl);
            }
        }

        private int Pl_eventdelMessage(object sender, string strResult)
        {
            if (this.InvokeRequired) // 요청 한 Thread가 현재 Main Thread에있는 Control를 엑세스 할수 있는지 확인
            {
                this.Invoke(new Action(delegate ()
                {
                    Play oPlayerForm = sender as Play;

                    lboxResult.Items.Add(string.Format("Player : {0}, Text : {1}", oPlayerForm.StrPlayerName, strResult));
                }));
            }
            return 0;

        }
        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            foreach (Play oPlayForm in lplay)
            {
                oPlayForm.ThreadAbort(); // 프로그램 종료 강제로 Thread 해제
            }
        }
    }
}

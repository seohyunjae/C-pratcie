using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        struct structPlayer
        {
            public int iCount; // player가 몇회 진행 중인지

            public int iSun; // 해에 대한 값
            public int iMoon; // 달에 대한 값
            public int iStar; // 별에 대한 값
            public string hyo_silver;

            public int iCardSum; // 해,달,별을 더한 값

            // 값들을 더해서 반환
            public int CardSun(int iSum, int IMoon, int IStar)
            {
                return iSun + iMoon + IStar;
            }

            // 결과를 String 형태로 변환(화면에 결과를 보여주기 )
            public string ResultText(int iCardSum)
            {
                return string.Format("{0}회 해:{1}, 달:{2}, + 별:{3} => 합계는 {4}입니다", iCount, iSun, iMoon, iStar, iCardSum);
            }

        }

        structPlayer _structPlayer1;
        structPlayer _structPlayer2;


        Random _rd = new Random();

        //class classPlayer
        //{
        //    public int iCount = 0; // player가 몇회 진행 중인지

        //    public int iSun; // 해에 대한 값
        //    public int iMoon; // 달에 대한 값
        //    public int iStar; // 별에 대한 값

        //    public int iCardSum; // 해,달,별을 더한 값

        //    // 값들을 더해서 반환
        //    public int CardSun(int iSum, int IMoon, int IStar)
        //    {
        //        return iSun + iMoon + IStar;
        //    }

        //    // 결과를 String 형태로 변환(화면에 결과를 보여주기 )
        //    public string ResultText(int iCardSum)
        //    {
        //        return string.Format("{0}회 해:{1}, 달:{2}, + 별:{3} => 합계는 {4}입니다", iCount, iSun, iMoon, iStar, iCardSum);
        //    }

        //}




        public Form1()
        {
            InitializeComponent();
        }

        private void pboxSun_Click(object sender, EventArgs e)
        {
            int iNumber = _rd.Next(1, 21);

            if (rdoButton1.Checked)
            {
                _structPlayer1.iSun = iNumber;
            }
            else 
            {
                _structPlayer2.iSun = iNumber;
            }
            iCheckedChange();
        }

        private void pboxmoon_Click(object sender, EventArgs e)
        {
            int iNumber = _rd.Next(1, 21);

            if (rdoButton1.Checked)
            {
                _structPlayer1.iMoon = iNumber;
            }
            else
            {
                _structPlayer2.iMoon = iNumber;
            }
            iCheckedChange(); 

        }

        private void pboxstar_Click(object sender, EventArgs e)
        {
            int iNumber = _rd.Next(1, 21);

            if (rdoButton1.Checked)
            {
                _structPlayer1.iStar = iNumber;
            }
            else
            {
                _structPlayer2.iStar = iNumber;
            }
            iCheckedChange();

        }

        private void pboxNone_Click(object sender, EventArgs e)
        {
            // 아무짓도 안하고 한턴을 넘긴다

            iCheckedChange();

        }

        private void iCheckedChange()
        {
            if (rdoButton1.Checked)
            {
                rdoButton2.Checked = true;
            }
            else
            {
                rdoButton1.Checked = true;

            }
        }
    }
}

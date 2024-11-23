using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _29_UserControl
{
    public partial class UCInfo : UserControl
    {
        public delegate int delEvent(object Sender, string strText); // delegate 선언
        public event delEvent eventdelSedner; // delegate event 선언

        [Category("UserProperty"), Description("lmage")]
        public Image UserFace
        {
            get
            {
                return this.pboxFace.BackgroundImage;
            }
            set
            {
                this.pboxFace.BackgroundImage = value;
            }
        }

        [Category("UserProperty"), Description("No")]
        public string UserNo
        {
            get
            {
                return this.lblNo.Text;
            }
            set
            {
                this.lblNo.Text = value;
            }
        }
        [Category("UserProperty"), Description("현상범의 이름")]
        public string UserName
        {
            get
            {
                return this.lblName.Text;
            }
            set
            {
                this.lblName.Text = value;
            }
        }

        [Category("UserProperty"), Description("현상범의 금액")]
        public string UserGold
        {
            get
            {
                return this.lblGold.Text;
            }
            set
            {
                this.lblGold.Text = value;
            }
        }

        public UCInfo()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            string strText = string.Empty;
            Button eBtn = sender as Button;

            switch (eBtn.Name)
            {
                case "btnReg":
                    this.BackColor = Color.Red;

                    strText = string.Format("{0}은 금액 {1}으로 수배중입니다", lblName.Text, lblGold.Text);

                    break;
                case "btnIdle":
                    this.BackColor = Color.Yellow;

                    strText = string.Format("{0}은 수배중지 상태입니다", lblName.Text);
                    break;
                case "btnCatch":
                    this.BackColor = Color.Green;

                    strText = string.Format("{0}은 잡혔습니다", lblName.Text);
                    break;
                default:
                    break;
            }

            if (eventdelSedner != null)
            {
                eventdelSedner(this, strText);
            }
        }
    }
}

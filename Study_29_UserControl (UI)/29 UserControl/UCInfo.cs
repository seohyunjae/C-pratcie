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
            Button eBtn = sender as Button;

            switch (eBtn.Name)
            {
                case "btnReg":
                    this.BackColor = Color.Red;
                    break;
                case "btnIdle":
                    this.BackColor = Color.Yellow;
                    break;
                case "btnCatch":
                    this.BackColor = Color.Green;
                    break;
                default:
                    break;
            }
        }
    }
}

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

namespace WindowsFormsApp11
{
    public partial class frmPizza : Form
    {
        public delegate int delPizzaComplete(string strResult, int iTime);

        public event delPizzaComplete eventdelPizzaComplete; // delegate event 선언

        public frmPizza()
        {
            InitializeComponent();

        }

      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void fPizzrCheck(Dictionary<string, int> dPizzaOrder)
        {
            int iTotalTime = 0;

            //int iTime = 0;
            //string strType = string.Empty;

            foreach (KeyValuePair<string, int> order in dPizzaOrder)
            {
                int iNowTime = 0;
                string strType = string.Empty;
                int itTime = 0;
                int iCount = order.Value;


                switch (order.Key)
                {
                    // 도우
                    case "오리지널":
                        iNowTime = 3000;
                        strType = "도우";
                   
                        break;
                    case "씬":
                        iNowTime = 3500;
                        strType = "도우";
                        break;

                    // 엣지
                    case "리치골드":
                        iNowTime = 500;
                        strType = "엣지";
                        break;
                    case "치즈크러스터":
                        iNowTime = 400;
                        strType = "엣지";
                        break;

                    // 토핑
                    case "소세지":
                        iNowTime = 32;
                        strType = "토핑";
                        break;
                    case "감자":
                        iNowTime = 17;
                        strType = "토핑";
                        break;
                    case "치즈":
                        iNowTime = 30;
                        strType = "토핑";
                        break;
                    default:
                        break;
                }

                itTime = iNowTime * iCount;

                iTotalTime = iTotalTime + itTime;   

                lboxMake.Items.Add(string.Format("{0}) {1} : {2}초 ({3}초, {4}개)", strType, order, itTime, iNowTime, iCount));

                this.Refresh();
                Thread.Sleep(1000);
            }


            //int i = 0;

            //while(i < 10)
            //{
            //    i++;

            //    lboxMake.Items.Add(i.ToString());   
            //    this.Refresh();
            //    Thread.Sleep(1000); 
            //}

            eventdelPizzaComplete("Pizza가 완성 되었습니다", iTotalTime);
        }
    }
}

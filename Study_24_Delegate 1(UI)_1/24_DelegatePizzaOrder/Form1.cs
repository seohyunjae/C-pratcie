﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24_DelegatePizzaOrder
{
    public partial class Form1 : Form
    {
        public delegate int delFuncDow_Edge(int i);
        public delegate int delFuncTopping(string strOrder, int Ea);

        public delegate T delFunc<T>(int i);
        public delegate object delFunc(object i);  // var, object

        int _iTotalPrice = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> dPizzaOrder = new Dictionary<string, int>(); // Pizza 주문을 담을 그릇
            delFuncDow_Edge delDow = new delFuncDow_Edge(fDow);
            delFuncDow_Edge delEdge = new delFuncDow_Edge(fEdge);

            delFuncTopping delTopping = null;

            int iDowOrder = 0;
            int iEdgeOrder = 0;

            // Dow 호출
            if (rdoDow1.Checked)
            {
                iDowOrder = 1;
                dPizzaOrder.Add("오리지널", 1);
            }
            else if (rdoDow2.Checked)
            {
                iDowOrder = 2;
                dPizzaOrder.Add("씬", 1);
            }
            //delDow(iDowOrder);

            // Edge를 선택
            if (rdoEdge1.Checked)
            {
                iEdgeOrder = 1;
                dPizzaOrder.Add("리치골드", 1);

            }
            else if (rdoEdge2.Checked)
            {
                iEdgeOrder = 2;
                dPizzaOrder.Add("치즈크러스터", 1);

            }
            //delEdge(iEdgeOrder);

            fcallBackDelegate(iDowOrder, delDow);
            fcallBackDelegate(iEdgeOrder, delEdge);

            if (cboxTopping1.Checked)
            {
                //delTopping = new delFuncTopping(fTopping1);
                delTopping += fTopping1;
                dPizzaOrder.Add("소세지", (int)numEa.Value);
            }

            if (cboxTopping2.Checked)
            {
                delTopping += fTopping2;
                dPizzaOrder.Add("감자", (int)numEa.Value);

            }

            if (cboxTopping3.Checked)
            {
                delTopping += fTopping3;
                dPizzaOrder.Add("치즈", (int)numEa.Value);
            }

            delTopping -= fTopping1;

            delTopping("토핑", (int)numEa.Value);

            flboxOrderRed("----------------------------------");
            flboxOrderRed(string.Format("전체 주문가격은 {0}원 입니다", _iTotalPrice));

            frmLoding(dPizzaOrder);
        }

   
        #region Function
        /// <summary>
        /// 0 : 선택안함, 1 : 오리지널, 2: 씬
        /// </summary>
        /// <param name="iOrder"></param>
        /// <returns></returns>
        private int fDow(int iOrder)
        {
            string strOrder = string.Empty;
            int iPrice = 0;

            if (iOrder ==1)
            {
                iPrice = 10000;
                strOrder = string.Format("도우는 오리지널을 선택하였습니다, {0}원", iPrice.ToString());
            }
            else if (iOrder == 2)
            {
                iPrice = 11000;
                strOrder = string.Format("도우는 씬을 선택하였습니다, {0}원", iPrice.ToString());

            }
            else
            {
                strOrder = "도우를 선택하지 않았습니다";
            }
            lboxOrder.Items.Add(strOrder);

            return _iTotalPrice = _iTotalPrice + iPrice;

        }
        #endregion

        #region Function
        /// <summary>
        /// 0 : 선택안함, 1 : 리치골드, 2: 치즈크러스터
        /// </summary>
        /// <param name="iOrder"></param>
        /// <returns></returns>
        private int fEdge(int iOrder)
        {
            string strOrder = string.Empty;
            int iPrice = 0;

            if (iOrder == 1)
            {
                iPrice = 1000;
                strOrder = string.Format("엣지는 리치골드를 선택하였습니다, {0}원", iPrice.ToString());
            }
            else if (iOrder == 2)
            {
                iPrice = 2000;
                strOrder = string.Format("엣지는 치즈 크러스터를 선택하였습니다, {0}원", iPrice.ToString());

            }
            else
            {
                strOrder = "엣지는 선택하지 않았습니다";
            }
            //lboxOrder.Items.Add(strOrder);
            flboxOrderRed(strOrder);

            return _iTotalPrice = _iTotalPrice + iPrice;
        }

        public int fcallBackDelegate(int i, delFuncDow_Edge delFunction)
        {
            return delFunction(i);
        }

        private int fTopping1(string Order, int iEa)
        {
            string strOrder = string.Empty;
            int iPrice = iEa * 500;

            strOrder = string.Format("소세지 {0} {1}개를 선택 하셨습니다. : {2}원  (1ea 500원)", Order, iEa, iPrice);

            flboxOrderRed(strOrder);

            return _iTotalPrice = _iTotalPrice + iPrice; 
        }

        private int fTopping2(string Order, int iEa)
        {
            string strOrder = string.Empty;
            int iPrice = iEa * 500;

            strOrder = string.Format("감자 {0} {1}개를 선택 하셨습니다. : {2}원  (1ea 200원)", Order, iEa, iPrice);

            flboxOrderRed(strOrder);

            return _iTotalPrice = _iTotalPrice + iPrice;
        }


        private int fTopping3(string Order, int iEa)
        {
            string strOrder = string.Empty;
            int iPrice = iEa * 500;

            strOrder = string.Format("치즈 {0} {1}개를 선택 하셨습니다. : {2}원  (1ea 300원)", Order, iEa, iPrice);

            flboxOrderRed(strOrder);

            return _iTotalPrice = _iTotalPrice + iPrice;
        }


        private void flboxOrderRed(string strOrder)
        {
            lboxOrder.Items.Add(strOrder);
        }
        #endregion

        #region event 예제
        frmPizza fPizza;
        private void frmLoding()
        {
            if (fPizza != null)
            {
                fPizza.Dispose();
                fPizza = null;
            }

            fPizza = new frmPizza();
            fPizza.eventdelPizzaComplete += FPizza_eventdelPizzaComplete;
            fPizza.Show();
            fPizza.fPizzarCheck();

        }

        private int FPizza_eventdelPizzaComplete(string strResult, int Time)
        {
            return 0;
        }
        #endregion
    }

}

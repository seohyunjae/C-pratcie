﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataTableTest
{
    public partial class Form1 : Form
    {
        DataSet ds =new DataSet(); // 학급들에 대한 정보를 가지고 있을 DataSet
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            DataTable dt = null;

            dt = new DataTable(cboxRegClass.Text);

            DataColumn colName = new DataColumn("NAME", typeof(string));

        }

        private void btnViewDataDel_Click(object sender, EventArgs e)
        {

        }

        private void cboxViewClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

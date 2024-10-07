using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16_StreamReader_Write
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 진입점
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConfigSet_Click(object sender, EventArgs e)
        {
            string strEnter = "\r\n";
            string strText = tboxData.Text;
            bool bChecked = cboxData.Checked;
            int iNumber = (int)numData.Value;

            StringBuilder sb = new StringBuilder();
            sb.Append(strText + strEnter);
            sb.Append(bChecked.ToString() + strEnter);
            sb.Append(iNumber.ToString() + strEnter);

            tboxConfigData.Text = sb.ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strFilePath = string.Empty;

            SFDialog.InitialDirectory = Application.StartupPath; //프로그램 실행 파일 위치
            SFDialog.FileName = "*.txt";
            SFDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (SFDialog.ShowDialog() == DialogResult.OK)
            {
                strFilePath = SFDialog.FileName;

                StreamWriter swSFDialog = new StreamWriter(strFilePath);

                swSFDialog.WriteLine(tboxConfigData.Text);
            }
        }
    }
}

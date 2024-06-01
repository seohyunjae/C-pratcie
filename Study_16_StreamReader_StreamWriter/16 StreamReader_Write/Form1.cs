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
        CXAMLControl _XML = new CXAMLControl();

        Dictionary<string, string> _dData = new Dictionary<string, string>();


        /// <summary>
        /// 진입점
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// GroupBox 안에 있는 Data를 화면에 보여주기 위한 상단 TextBox로 보냄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            _dData.Clear();

            _dData.Add(CXAMLControl._TEXT_DATA, strText);
            _dData.Add(CXAMLControl._CBOX_DATA, bChecked.ToString());
            _dData.Add(CXAMLControl._NUMBER_DATA, iNumber.ToString());
        }


        /// <summary>
        /// Main TextBox에 있는 문자를 텍스트 파일로 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strFilePath = string.Empty;

            SFDialog.InitialDirectory = Application.StartupPath;   //프로그램 실행 파일 위치
            SFDialog.FileName = "*.xml";
            SFDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";

            if (SFDialog.ShowDialog() == DialogResult.OK)
            {
                strFilePath = SFDialog.FileName;

                //// StreamWriter를 이용해서 텍스트 파일을 일어노는 부분을 구현
                //StreamWriter swSFDialog = new StreamWriter(strFilePath);

                //swSFDialog.WriteLine(tboxConfigData.Text);
                //swSFDialog.Close();

                //File.WriteAllText(strFilePath, tboxConfigData.Text);

                _XML.fXML_Writer(strFilePath, _dData);
            }

        }


        /// <summary>
        /// 텍스트 파일을 읽어와서 Main TextBox에 보여 줌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            string strFilePath = string.Empty;

            OFDialog.InitialDirectory = Application.StartupPath;   //프로그램 실행 파일 위치
            OFDialog.FileName = "*.xml";
            OFDialog.Filter = "xml files (*.txt)|*.xml|All files (*.*)|*.*";

            StringBuilder sb = new StringBuilder();

            if (OFDialog.ShowDialog() == DialogResult.OK)
            {
                strFilePath = OFDialog.FileName;
                
                //// StreamReader를 이용해서 텍스트 파일을 일어노는 부분을 구현
                //StreamReader srOFDialog = new StreamReader(strFilePath, Encoding.UTF8, true);

                //while (srOFDialog.EndOfStream == false)
                //{
                //    sb.Append(srOFDialog.ReadLine());
                //    sb.Append("\r\n");
                //}

                sb.Append(File.ReadAllText(strFilePath));  // 텍스트 파일을 String 형태로 한번에 읽어 옴

                //string[] dd =  File.ReadAllLines(strFilePath);   // 텍스트 파일을 한줄 씩 String 배열 형태로 한번에 읽어 옴


                tboxConfigData.Text = sb.ToString();

                _dData.Clear();
                _dData = _XML.FXML_Redaer(strFilePath);
            }
        }


        /// <summary>
        /// Config Data를 Group Box안에 있는 Control들에 Set
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfigRead_Click(object sender, EventArgs e)
        {
            string[] strConfig = tboxConfigData.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);  // 문자열 안에있는 '\r\n'을 기준으로 split 시킴

            tboxData.Text = strConfig[0];
            cboxData.Checked = bool.Parse(strConfig[1]);
            numData.Value = int.Parse(strConfig[2]);
        }
    }
}

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

namespace _17_XMLControl
{
    public partial class Form1 : Form
    {

        CXMLControl _xml = new CXMLControl();   // 만들어 놓은 CXMLControl을 사용하기 위해 선언 및 초기화 (기본 생성자)
        Dictionary<string, string> _dData = new Dictionary<string, string>();  // CXMLControl과 Data를 주고 받기 위해 Dictionary를 선언 및 초기화

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


            _dData.Clear();  // 기존에 Dictionary에 Data가 남아 있을 수 있으므로 작성 하기 전 초기화 시킴

            // Dictionary에 UI에서 작성 한 항목과 값을 Key와 Value로 저장
            _dData.Add(CXMLControl._TEXT_DATA, strText);
            _dData.Add(CXMLControl._CBOX_DATA, bChecked.ToString());
            _dData.Add(CXMLControl._NUMBER_DATA, iNumber.ToString());


            sb.Append(strText + strEnter);
            sb.Append(bChecked.ToString() + strEnter);
            sb.Append(iNumber.ToString() + strEnter);

            tboxConfigData.Text = sb.ToString();
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
            SFDialog.Filter = "xml files (*.xml)|*.txt|All files (*.*)|*.*";

            if (SFDialog.ShowDialog() == DialogResult.OK)
            {
                strFilePath = SFDialog.FileName;

                //// StreamWriter를 이용해서 텍스트 파일을 일어노는 부분을 구현
                //StreamWriter swSFDialog = new StreamWriter(strFilePath);

                //swSFDialog.WriteLine(tboxConfigData.Text);
                //swSFDialog.Close();

                //File.WriteAllText(strFilePath, tboxConfigData.Text);

                _xml.fXML_Writer(strFilePath, _dData);   // 작성 한 CXMLControl에서 fXML_Writer를 호출해서 XML File을 생성
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
            OFDialog.Filter = "xml files (*.xml)|*.*";

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

                _dData.Clear();   // 기존에 Dictionary에 Data가 남아 있을 수 있으므로 작성 하기 전 초기화 시킴
                _dData = _xml.fXML_Reader(strFilePath);   // 작성 한 CXMLControl에서 fXML_Reader를 호출해서 XML File을 읽어서 필요한 정보를 Dictionary 형태로 가져 옴
            }
        }


        /// <summary>
        /// Config Data를 Group Box안에 있는 Control들에 Set
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfigRead_Click(object sender, EventArgs e)
        {
            //string[] strConfig = tboxConfigData.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);  // 문자열 안에있는 '\r\n'을 기준으로 split 시킴

            //tboxData.Text = strConfig[0];
            //cboxData.Checked = bool.Parse(strConfig[1]);
            //numData.Value = int.Parse(strConfig[2]);


            // Dictionary에 있는 정보를 UI에 입력함
            tboxData.Text = _dData[CXMLControl._TEXT_DATA];
            cboxData.Checked = bool.Parse(_dData[CXMLControl._CBOX_DATA]);
            numData.Value = int.Parse(_dData[CXMLControl._NUMBER_DATA]);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _17_XMLControl
{
    class CXMLControl
    {
        // Dictionary 및 XML의 항목을 정의 ( static(정적) 변수로 사용 : 프로그램 실행 시 메모리에 바로 할당
        public static string _TEXT_DATA = "TEXT_DATA";
        public static string _CBOX_DATA = "CBOX_DATA";
        public static string _NUMBER_DATA = "NUMBER_DATA";


        /// <summary>
        /// XML을 저장 하기 위해 사용
        /// </summary>
        /// <param name="strXMLPath">저장 할 XML File의 경로 및 파일명</param>
        /// <param name="DXMLConfig">XML로 저장 할 항목</param>
        public void fXML_Writer(string strXMLPath, Dictionary<string,string> DXMLConfig)
        {
            // using 범위 내에 XmlWriter를 정의 하여 using을 벗어 나게 될 경우 자동으로 Dispose 하여 메모리를 관리
            using (XmlWriter wr = XmlWriter.Create(strXMLPath))
            {
                // XML 형태의 Data를 작성 (결과 및 예제 확인)

                wr.WriteStartDocument();

                // Setting#01
                wr.WriteStartElement("SETTING");
                wr.WriteAttributeString("ID", "0001");  // attribute 쓰기

                wr.WriteElementString(_TEXT_DATA, DXMLConfig[_TEXT_DATA]);
                wr.WriteElementString(_CBOX_DATA, DXMLConfig[_CBOX_DATA]);
                wr.WriteElementString(_NUMBER_DATA, DXMLConfig[_NUMBER_DATA]);

                wr.WriteEndElement();
                wr.WriteEndDocument();
            }
        }


        /// <summary>
        /// XML을 읽어 오기 위해 사용
        /// </summary>
        /// <param name="strXMLPath">읽어 올 XML File의 경로 및 파일명</param>
        /// <returns></returns>
        public Dictionary<string, string> fXML_Reader(string strXMLPath)
        {
            Dictionary<string, string> DXMLConfig = new Dictionary<string, string>();  // 읽어 온 XML Data를 Dictionary에 저장하기 위해 선언 및 초기화

            // using 범위 내에 XmlReader를 정의 하여 using을 벗어 나게 될 경우 자동으로 Dispose 하여 메모리를 관리
            using (XmlReader rd = XmlReader.Create(strXMLPath))
            {
                // xml을 한줄 씩 읽으면서 필요 한 정보를 가져 옴
                while (rd.Read())
                {
                    if (rd.IsStartElement())
                    {
                        if (rd.Name.Equals("SETTING"))
                        {
                            string strID = rd["ID"];  // attribute 읽기   //여기 뭐지??  ID를 읽고 뭐하는거지??
                            rd.Read();  //다음 노드로 이동

                            string strTEXT = rd.ReadElementContentAsString(_TEXT_DATA, "");  // 키 값을 기준으로 결과 값을 가져 옴
                            DXMLConfig.Add(_TEXT_DATA, strTEXT);   // 키값과 가져온 결과 값을 Dictionary에 저장

                            string strCBOX = rd.ReadElementContentAsString(_CBOX_DATA, "");
                            DXMLConfig.Add(_CBOX_DATA, strCBOX);

                            string strNUMBER = rd.ReadElementContentAsString(_NUMBER_DATA, "");
                            DXMLConfig.Add(_NUMBER_DATA, strNUMBER);
                        }
                    }
                }
            }

            return DXMLConfig;   // 작성 한 Dictionary를 반환
        }
    }
}

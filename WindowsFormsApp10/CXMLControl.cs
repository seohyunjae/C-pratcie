using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WindowsFormsApp10
{
    class CXMLControl
    {
        // Dictionary 및 XML의 항목을 정의 ( static(정적) 변수로 사용 : 프로그램 실행 시 메모리에 바로 할당
        public static string _TICK = "TICK";
        public static string _TOTAL = "TOTAL";
        public static string _LEVEL_1 = "LEVEL_1";
        public static string _LEVEL_3 = "LEVEL_3";
        public static string _LEVEL_50 = "LEVEL_50";



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

                wr.WriteElementString(_TICK, DXMLConfig[_TICK]);
                wr.WriteElementString(_TOTAL, DXMLConfig[_TOTAL]);
                wr.WriteElementString(_LEVEL_1, DXMLConfig[_LEVEL_1]);
                wr.WriteElementString(_LEVEL_3, DXMLConfig[_LEVEL_3]);
                wr.WriteElementString(_LEVEL_50, DXMLConfig[_LEVEL_50]);


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

                            string strTICK = rd.ReadElementContentAsString(_TICK, "");  // 키 값을 기준으로 결과 값을 가져 옴
                            DXMLConfig.Add(_TICK, strTICK);   // 키값과 가져온 결과 값을 Dictionary에 저장

                            string strTOTAL = rd.ReadElementContentAsString(_TOTAL, "");
                            DXMLConfig.Add(_TOTAL, strTOTAL);

                            string strLEVEL_1 = rd.ReadElementContentAsString(_LEVEL_1, "");
                            DXMLConfig.Add(_LEVEL_1, strLEVEL_1);

                            string strLEVEL_3 = rd.ReadElementContentAsString(_LEVEL_3, "");
                            DXMLConfig.Add(_LEVEL_3, strLEVEL_3);

                            string strLEVEL_50 = rd.ReadElementContentAsString(_LEVEL_50, "");
                            DXMLConfig.Add(_LEVEL_50, strLEVEL_50);
                        }
                    }
                }
            }

            return DXMLConfig;   // 작성 한 Dictionary를 반환
        }
    }
}

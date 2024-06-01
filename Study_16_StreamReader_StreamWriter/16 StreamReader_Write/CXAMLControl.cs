using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

namespace _16_StreamReader_Write
{
    internal class CXAMLControl
    {
        public static string _TEXT_DATA = "TEXT_DATA";
        public static string _CBOX_DATA = "CBOX_DATA";
        public static string _NUMBER_DATA = "NUMBER_DATA";


        public Dictionary<string, string> FXML_Redaer(string strXMLPath)
        {
            Dictionary<string, string> DXMLConfing = new Dictionary<string, string>();

            using (XmlReader rd = XmlReader.Create(strXMLPath))
            {
                while (rd.Read())
                {
                    if (rd.IsStartElement())
                    {
                        if (rd.Name.Equals("SETTING"))
                        {
                            string strID = rd["ID"];

                            rd.Read();

                            string strTEXT = rd.ReadElementContentAsString(_TEXT_DATA, "");
                            DXMLConfing.Add(_TEXT_DATA, strTEXT);

                            string strCBox = rd.ReadElementContentAsString(_CBOX_DATA, "");
                            DXMLConfing.Add(_CBOX_DATA, strCBox);

                            string strNUMBER = rd.ReadElementContentAsString(_NUMBER_DATA, "");
                            DXMLConfing.Add(_NUMBER_DATA, strNUMBER);

                        }
                    }
                }
            }

            return DXMLConfing;
        }


        public void fXML_Writer(string strXMLPath, Dictionary<string, string> DXMLConfing)
        {
            using (XmlWriter wr = XmlWriter.Create(strXMLPath))
            {
                wr.WriteStartDocument();

                // SETTING
                wr.WriteStartElement("SETTING");
                wr.WriteAttributeString("ID", "0001");

                wr.WriteElementString(_TEXT_DATA, DXMLConfing[_TEXT_DATA]);
                wr.WriteElementString(_CBOX_DATA, DXMLConfing[_CBOX_DATA]);
                wr.WriteElementString(_NUMBER_DATA, DXMLConfing[_NUMBER_DATA]);

                wr.WriteEndElement();
                wr.WriteEndDocument();
            }
        }
    }
}

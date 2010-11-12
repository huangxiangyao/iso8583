using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml;
using System.IO;

namespace Solab.Iso8583.Parsing
{

    /// <summary>
    /// This class can read a configuration file in XML format and configure
    /// a MessageFactory with the information contained in it. The config file
    /// can contain ISO headers for each message type, as well as templates
    /// for different message types and finally parsing guides for each
    /// message type. The message type must be indicated in hex.
    /// </summary>
    public class ConfigParser
    {

        /// <summary>
        /// Creates a MessageFactory and configures it from the XML file read
        /// from the absolute path specified.
        /// </summary>
        /// <param name="filename">An absolute path to the XML configuration file.</param>
        /// <returns>A new configured MessageFactory.</returns>
        public static MessageFactory CreateFromFile(String filename)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(filename);
            MessageFactory m = new MessageFactory();
            foreach (XmlNode node in xml.DocumentElement.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    if ("header".Equals(node.Name))
                    {
                        string type = node.Attributes["type"].Value;
                        string header = node.ChildNodes[0].Value;
                        m.SetIsoHeader(Convert.ToInt16(type, 16), header);
                    }
                    else if ("template".Equals(node.Name))
                    {
                        int type = Convert.ToInt16(node.Attributes["type"].Value, 16);
                        IsoMessage templ = new IsoMessage();
                        templ.Type = type;
                        foreach (XmlNode field in node.ChildNodes)
                        {
                            if (field.NodeType == XmlNodeType.Element && "field".Equals(field.Name))
                            {
                                int num = Convert.ToInt16(field.Attributes["num"].Value);
                                string ftype = field.Attributes["type"].Value;
                                string length = field.Attributes["length"] == null ? "0" : field.Attributes["length"].Value;
                                string val = field.ChildNodes[0].Value;
                                //Ir creando mensaje con esto
                                templ.SetValue(num, val,
                                    (IsoType)Enum.Parse(typeof(IsoType), ftype),
                                    Convert.ToInt16(length));
                            }
                        }
                        m.AddMessageTemplate(templ);
                    }
                    else if ("parse".Equals(node.Name))
                    {
                        int type = Convert.ToInt16(node.Attributes["type"].Value, 16);
                        Dictionary<int, FieldParseInfo> guide = new Dictionary<int, FieldParseInfo>();
                        foreach (XmlNode field in node.ChildNodes)
                        {
                            if (field.NodeType == XmlNodeType.Element && "field".Equals(field.Name))
                            {
                                string num = field.Attributes["num"].Value;
                                string ftype = field.Attributes["type"].Value;
                                XmlAttribute lenAttr = field.Attributes["length"];
                                int len = 0;
                                if (lenAttr != null)
                                {
                                    len = Convert.ToInt16(lenAttr.Value);
                                }
                                //TODO ir creando guia con esto
                                FieldParseInfo fpi = new FieldParseInfo((IsoType)Enum.Parse(typeof(IsoType), ftype), len);
                                guide[Convert.ToInt16(num)] = fpi;
                            }
                        }
                        m.SetParseDictionary(type, guide);
                    }
                    else if ("assign-date".Equals(node.Name))
                    {
                        string val = node.Attributes["value"].Value;
                        m.AssignDate = "true".Equals(val);
                    }
                }
            }
            return m;
        }

    }

}

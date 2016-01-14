using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DiplomskiProjekt
{
    public static class FileManager
    {
        private static string _fileName = "Zapis.xml";
        private static string _filePath = String.Concat(Environment.CurrentDirectory, "\\", _fileName);

        public static string FilePath
        {
            get
            {
                return _filePath;
            }
        }

        public static void ChangeAppConfig(string key, string value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            foreach (XmlElement element in xmlDoc.DocumentElement)
            {
                if (element.Name.Equals("appSettings"))
                {
                    foreach (XmlNode node in element.ChildNodes)
                    {
                        if (node.Attributes[0].Value.Equals(key))
                        {
                            node.Attributes[1].Value = value;
                            break;
                        }
                    }
                    break;
                }
            }
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static void WriteToXmlFile(string nodeName, string nodeValue)
        {
            if (File.Exists(FilePath) == false)
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.NewLineOnAttributes = true;
                xmlWriterSettings.Encoding = new UTF8Encoding(false);
                using (XmlWriter xmlWriter = XmlWriter.Create(FilePath, xmlWriterSettings))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Encryption");

                    xmlWriter.WriteElementString(nodeName, nodeValue);

                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Flush();
                    xmlWriter.Close();
                }
            }
            else
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(FilePath);
                XmlNode RootNode = xmlDoc.SelectSingleNode("Encryption");
                if (String.IsNullOrEmpty(ReadFromXMLFile(nodeName)))
                {
                    XmlElement newNode = xmlDoc.CreateElement(nodeName);
                    newNode.InnerText = nodeValue;
                    RootNode.AppendChild(newNode);
                }
                else
                {
                    if (RootNode.HasChildNodes)
                    {
                        for (int i = 0; i < RootNode.ChildNodes.Count; i++)
                        {
                            if (RootNode.ChildNodes[i].Name.Equals(nodeName))
                            {
                                RootNode.ChildNodes[i].InnerText = nodeValue;
                                break;
                            }
                        }
                    }
                }
                xmlDoc.Save(FilePath);
            }
        }

        public static string ReadFromXMLFile(string nodeName)
        {
            string nodeValue = "";

            XmlDocument doc = new XmlDocument();
            doc.Load(FilePath);
            try
            {
                XmlNodeList DataXML = doc.GetElementsByTagName(nodeName);

                nodeValue = DataXML[0].InnerXml;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Element does not exist!");
            }
            return nodeValue;
        }

        public static void ReplaceSubstringInFile(string stringForReplacement, string stringToBeReplaced)
        {
            var fileContents = System.IO.File.ReadAllText(FilePath);

            fileContents = fileContents.Replace(stringToBeReplaced, stringForReplacement);

            System.IO.File.WriteAllText(FilePath, fileContents);
        }

    }
}

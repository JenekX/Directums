using System;
using System.IO;
using System.Xml.Linq;
using System.Configuration;

namespace Directums.Service.Classes
{
    public class LogManager
    {
        private static string logFolder = ConfigurationManager.AppSettings.Get("LogFolder");

        public static bool AddException(Exception e)
        {
            string fileName = Path.Combine(logFolder, DateTime.Today.ToShortDateString() + ".log");
            XDocument doc = null;

            try
            {
                doc = XDocument.Load(fileName);
            }
            catch
            {
                doc = new XDocument();
                doc.Add(new XElement("items"));
            }

            try
            {
                var items = doc.Element("items");
                
                var item = new XElement("item");
                item.Add(new XAttribute("type", "exception"));
                item.Add(new XText(e.ToString()));

                items.Add(item);

                doc.Save(fileName);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
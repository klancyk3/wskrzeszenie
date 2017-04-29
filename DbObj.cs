using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Crawler
{
    public class DbObj
    {
        public string Save<T>(T serializedObj, string tableName)
        {
            var id = serializedObj.GetHashCode();
            return Save(id, Serialize <T> (serializedObj), tableName);            
        }
        
        public string Save(int id, string serializedObj, string tableName)
        {
            System.IO.File.WriteAllText(PathMgr.SileSaveDb(tableName, id.ToString()), serializedObj);
            return "";
        }

        public string Serialize<T>(T obj)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
            XmlDocument doc = new XmlDocument();
            System.IO.StringWriter sww = new System.IO.StringWriter();
            XmlWriter writer = XmlWriter.Create(sww);
            xsSubmit.Serialize(writer, obj);
            var xml = sww.ToString(); // Your xml
            return xml;
        }
    }
}

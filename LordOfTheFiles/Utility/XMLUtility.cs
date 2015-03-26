using LordOfTheFiles.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace LordOfTheFiles.Utility
{
    public class XMLUtility
    {
        //public static T DictionaryFromXML<T>(string xml)
        //{
        //    using (StringReader stringReader = new StringReader(xml))
        //    {
        //        XmlSerializer serializer = new XmlSerializer(typeof(T));
        //        return (T)serializer.Deserialize(stringReader);
        //    }
        //}

        public static string DHTToXML(SortedList<ulong, string> dictionary)
        {
            List<Item> dht = new List<Item>(dictionary.Count);
            foreach (KeyValuePair<ulong, string> pair in dictionary)
            {
                dht.Add(new Item(pair.Key, pair.Value));
            }

            using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Item>));
                xmlSerializer.Serialize(stringWriter, dht);
                return stringWriter.ToString().ToLower();
            }
        }
    }
}

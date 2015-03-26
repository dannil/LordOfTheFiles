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
        public static SortedList<ulong, string> DHTFromXML(string xml)
        {
            List<Item> dht = FromXML<List<Item>>(xml);

            SortedList<ulong, string> dhtDictionary = new SortedList<ulong, string>(dht.Count);
            foreach (Item item in dht)
            {
                dhtDictionary.Add(item.Key, item.Value);
            }
            return dhtDictionary;
        }

        public static string DHTToXML(SortedList<ulong, string> dictionary)
        {
            List<Item> dht = new List<Item>(dictionary.Count);
            foreach (KeyValuePair<ulong, string> pair in dictionary)
            {
                dht.Add(new Item(pair.Key, pair.Value));
            }

            return ToXML(dht);
        }

        public static T FromXML<T>(string xml)
        {
            using (StreamReader streamReader = new StreamReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(streamReader);
            }
        }

        public static string ToXML<T>(T obj)
        {
            using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(stringWriter, obj);
                return stringWriter.ToString();
            }
        }
    }
}

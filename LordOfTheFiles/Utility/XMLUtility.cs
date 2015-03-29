using LordOfTheFiles.Model;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace LordOfTheFiles.Utility
{
    /// <summary>
    /// Contains functionality for converting objects to and from XML.
    /// </summary>
    public class XMLUtility
    {
        /// <summary>
        /// Convert the specified XML resource to a SortedList which acts as the DHT
        /// </summary>
        /// <param name="path">The path of the XML resource</param>
        /// <returns>A SortedList with all the XML resource's contents</returns>
        public static SortedList<ulong, string> DHTFromXML(string path)
        {
            List<Item> dht = FromXML<List<Item>>(path);

            SortedList<ulong, string> dhtDictionary = new SortedList<ulong, string>(dht.Count);
            foreach (Item item in dht)
            {
                dhtDictionary.Add(item.Key, item.Value);
            }
            return dhtDictionary;
        }

        /// <summary>
        /// Convert the specified SortedList to XML
        /// </summary>
        /// <param name="sortedList">The SortedList to be converted</param>
        /// <returns>An XML representation of the SortedList</returns>
        public static string DHTToXML(SortedList<ulong, string> sortedList)
        {
            List<Item> dht = new List<Item>(sortedList.Count);
            foreach (KeyValuePair<ulong, string> pair in sortedList)
            {
                dht.Add(new Item(pair.Key, pair.Value));
            }

            return ToXML(dht);
        }

        /// <summary>
        /// Converts a XML resource to an object
        /// </summary>
        /// <typeparam name="T">The object type to be converted</typeparam>
        /// <param name="path">The path of the XML resource</param>
        /// <returns>An object with all the XML resource's contents</returns>
        public static T FromXML<T>(string path)
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(streamReader);
            }
        }

        /// <summary>
        /// Converts an object to a XML resource
        /// </summary>
        /// <typeparam name="T">The object type to be converted</typeparam>
        /// <param name="obj">The object to be converted</param>
        /// <returns>A XML representation of the specified object</returns>
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

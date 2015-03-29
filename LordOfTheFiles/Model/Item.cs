using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LordOfTheFiles.Model
{
    /// <summary>
    /// Class which represents an entry in our distributed hash table
    /// when it's saved as XML
    /// </summary>
    public class Item
    {
        // Instance variables
        private ulong key;
        private string value;

        public Item()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        public Item(ulong key, string value)
        {
            this.key = key;
            this.value = value;
        }

        /// <summary>
        /// Property for key
        /// </summary>
        public ulong Key
        {
            get { return this.key; }
            set { this.key = value; }
        }

        /// <summary>
        /// Property for value
        /// </summary>
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

    }
}

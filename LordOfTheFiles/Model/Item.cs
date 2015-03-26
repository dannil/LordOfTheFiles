using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LordOfTheFiles.Model
{
    public class Item
    {
        private ulong key;
        private string value;

        public Item()
        {

        }

        public Item(ulong key, string value)
        {
            this.key = key;
            this.value = value;
        }

        public ulong Key
        {
            get { return this.key; }
            set { this.key = value; }
        }

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

    }
}

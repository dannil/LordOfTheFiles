using System;
using System.Collections.Generic;
using System.Text;

namespace LordOfTheFiles.Model
{
    public class File
    {
        private string name;
        private byte[] content;

        public File(string name, byte[] content)
        {
            this.name = name;
            this.content = content;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public byte[] Content
        {
            get { return content; }
            set { content = value; }
        }
    }
}

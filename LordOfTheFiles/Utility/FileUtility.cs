using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LordOfTheFiles.Utility
{
    public class FileUtility
    {
        public static byte[] ReadBytes(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}

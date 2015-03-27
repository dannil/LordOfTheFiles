using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using ByteSize;

namespace LordOfTheFiles.Utility
{
    public class FileUtility
    {
        public static string FILES_DIR = Environment.CurrentDirectory + "/files/";

        public static byte[] ReadBytes(string path)
        {
            return File.ReadAllBytes(path);
        }

        public static string GetFileSize(string path)
        {
            double size = GetFileSizeAsKB(path);

            if (size < ByteSize.ByteSize.FromKiloBytes(1000).KiloBytes)
            {
                double convertedSize = Math.Round(ByteSize.ByteSize.FromKiloBytes(size).KiloBytes, 2);
                return convertedSize.ToString() + " " + ByteSize.ByteSize.KiloByteSymbol;
            }
            else if (size < ByteSize.ByteSize.FromMegaBytes(1000).KiloBytes)
            {
                double convertedSize = Math.Round(ByteSize.ByteSize.FromKiloBytes(size).MegaBytes, 2);
                return convertedSize.ToString() + " " + ByteSize.ByteSize.MegaByteSymbol;
            }
            return null;
        }

        public static double GetFileSizeAsKB(string path)
        {
            FileInfo info = new FileInfo(path);

            var size = ByteSize.ByteSize.FromBytes(info.Length);

            return size.KiloBytes;
        }

        public static double GetFileSizeAsMB(string path)
        {
            return ByteSize.ByteSize.FromKiloBytes(GetFileSizeAsKB(path)).MegaBytes;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using ByteSize;

namespace LordOfTheFiles.Utility
{
    /// <summary>
    /// Contains functionality for operations on files.
    /// </summary>
    public class FileUtility
    {
        // Utility constants
        public static string FILES_DIR = Environment.CurrentDirectory + "/files/";
        public static string REF_DIR = Environment.CurrentDirectory + "/ref/";

        /// <summary>
        /// Read the specified file to bytes
        /// </summary>
        /// <param name="path">The path of the file</param>
        /// <returns>The file as bytes</returns>
        public static byte[] ReadBytes(string path)
        {
            return File.ReadAllBytes(path);
        }

        public static List<string> ReadLines(string path)
        {
            List<string> lines = new List<string>();

            using (StreamReader r = new StreamReader(path))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }

        /// <summary>
        /// Returns a string representation of the file size for a file on the specified path.
        /// </summary>
        /// <param name="path">The path of the file</param>
        /// <returns>The file size for the specified file</returns>
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

        /// <summary>
        /// Returns the size for the specified file as kilobytes.
        /// </summary>
        /// <param name="path">The path of the file</param>
        /// <returns>The file size in kilobytes.</returns>
        public static double GetFileSizeAsKB(string path)
        {
            FileInfo info = new FileInfo(path);

            var size = ByteSize.ByteSize.FromBytes(info.Length);

            return size.KiloBytes;
        }

        /// <summary>
        /// Returns the size for the specified file as megabytes.
        /// </summary>
        /// <param name="path">The path of the file</param>
        /// <returns>The file size in megabytes.</returns>
        public static double GetFileSizeAsMB(string path)
        {
            return ByteSize.ByteSize.FromKiloBytes(GetFileSizeAsKB(path)).MegaBytes;
        }

        public static string ToValidPath(string path)
        {
            return path.Replace('/', '\\');
        }

        public static string Combine(string name, string extension)
        {
            return name + "." + extension;
        }
    }
}

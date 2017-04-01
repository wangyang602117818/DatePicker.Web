using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;

namespace DatePicker.Common
{
    public class ZipHelper
    {
        public static void CompressFolder(string directoryPath, string zipFile)
        {
            if (!zipFile.EndsWith(".zip")) zipFile = zipFile + ".zip";
            ZipFile.CreateFromDirectory(directoryPath, zipFile);
        }
    }
}

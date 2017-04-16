using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;

namespace DatePicker.Common
{
    public class ZipHelper
    {
        public static void CompressFolder(string sourceDirectory, string destinationFullFileName)
        {
            if (!destinationFullFileName.EndsWith(".zip")) destinationFullFileName = destinationFullFileName + ".zip";
            ZipFile.CreateFromDirectory(sourceDirectory, destinationFullFileName);
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
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
        public static void AddFileToZip(string fullName, Dictionary<string, string> fileNameText)
        {
            if (!fullName.EndsWith(".zip")) fullName = fullName + ".zip";
            string path = Path.GetDirectoryName(fullName);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            using (FileStream zipFile = new FileStream(fullName, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipFile, ZipArchiveMode.Update))
                {
                    foreach (var item in fileNameText)
                    {
                        ZipArchiveEntry readEntry = archive.CreateEntry(item.Key);
                        using (StreamWriter writer = new StreamWriter(readEntry.Open()))
                        {
                            writer.Write(item.Value);
                        }
                    }
                }
            }
        }
    }
}

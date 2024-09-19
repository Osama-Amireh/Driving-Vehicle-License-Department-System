using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDClasses
{
    public class clsUtil
    {
        public static string CreateGUID()
        {
            Guid id = Guid.NewGuid();
            return id.ToString();
        }
        public static bool CreateFolderIfDosenotExsist(string FolderPath)
        {
            bool exists = System.IO.Directory.Exists(FolderPath);
            if (!exists)
                System.IO.Directory.CreateDirectory(FolderPath);
            return exists;

        }
        public static string ReplaceFileNameWithGUID(string sourceFile)

        {
            string Filename = sourceFile;
            FileInfo fileInfo = new FileInfo(sourceFile);
            string ext = fileInfo.Extension;
            return CreateGUID() + ext;

        }
        public static bool CopyImageToProjectImagesFolder(ref string sourseFile)
        {
            string DestinationFolder = @"C:\DVLDImage\";
            if (!CreateFolderIfDosenotExsist(DestinationFolder))
            {
                return false;
            }
            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourseFile);
            try
            {

                File.Copy(sourseFile, destinationFile, true);
            }
            catch (IOException ex)
            {
                return false;
            }
            sourseFile = destinationFile;
            return true;
        }
    }
}

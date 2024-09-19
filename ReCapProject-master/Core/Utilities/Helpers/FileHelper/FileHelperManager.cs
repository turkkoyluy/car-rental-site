using Core.Utilities.Helpers.GuidHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                Console.WriteLine("dosya var");
                File.Delete(filePath);
            }
            Console.WriteLine("dosya yok");
            return Upload(file,root);
        }

        public string Upload(IFormFile file, string filePath)
        {
            if (file.Length>0)
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                    
                }
                string extension = Path.GetExtension(file.FileName);
                string guid = GuidHelper.GuidHelper.CreateGuid();
                string fileName = guid+extension;
                Console.WriteLine("extension" + extension);
                Console.WriteLine("guid:" + guid);
                Console.WriteLine("filename:"+fileName);
                using (FileStream fileStream = File.Create(Path.Combine( filePath + fileName)))
                {
                    Console.WriteLine("filestream==========>"+fileStream.Position);
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return fileName;
                }               
            }
            return "/Upload";
        }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.DataLayer.FileHandling
{
    public class FileHandle
    {
        public string FileUpload(IFormFile iFile, string type)
        {

            // var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());


            if (iFile != null && iFile.Length != 0)
            {
                try
                {
                    var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
                    directory = directory.Parent;

                    string directoryOther = directory + "\\NSD.Web\\wwwroot\\Files\\" + type;
                    if (!Directory.Exists(directoryOther))
                    {
                        Directory.CreateDirectory(directoryOther);
                    }
                    var fileName = ContentDispositionHeaderValue.Parse(iFile.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(directoryOther, fileName);
                    var dbPath = Path.Combine("/Files/" + type, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        iFile.CopyTo(stream);
                    }

                    return dbPath;


                }
                catch (Exception ex)
                {
                    return null;
                }
            }


            return null;
        }
        public MemoryStream Download(string FilePath)
        {
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            directory = directory.Parent;
            string path = directory + "\\NSD.Web\\wwwroot" + FilePath;
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;
            return memory;

        }
        public string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

        public Stream Download(object path)
        {
            throw new NotImplementedException();
        }
    }
}

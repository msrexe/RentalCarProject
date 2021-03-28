using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var uploading = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(uploading);
                }
            }
            string path = Environment.CurrentDirectory + @"\wwwroot\Images";

            var result = newPath(file);
            string full_path = $@"{path}\{result}";
            File.Move(sourcepath, full_path);
            return result;
        }
        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file).ToString();
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }
        public static string newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            var newPath = Guid.NewGuid().ToString() + fileExtension;
            return newPath;
        }

    }
}

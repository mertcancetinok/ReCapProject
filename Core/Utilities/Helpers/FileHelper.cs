using System;
using System.IO;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            
            if (file != null)
            {
                var path = newPath(file);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return path;
            }
            return "";


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
            var result = newPath(file);
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
        private static string newPath(IFormFile file)
        {

            var extention = Path.GetExtension(file.FileName);
            var randomName = string.Format($"{Guid.NewGuid()}{extention}");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "CarImages\\", randomName);
            return path;
        }
    }
}
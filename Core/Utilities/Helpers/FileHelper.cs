﻿using System;
using System.IO;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        
        static string directory = Directory.GetCurrentDirectory() + @"\wwwroot\";
        static string path = @"img\CarImages\";
        private readonly IWebHostEnvironment webHostEnvironment;
        public FileHelper(IWebHostEnvironment hostEnvironment)
        {
            webHostEnvironment = hostEnvironment;
        }
        public static string Add(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName).ToUpper();
            string newFileName = Guid.NewGuid().ToString("N") + extension;
            if (!Directory.Exists(directory + path))
            {
                Directory.CreateDirectory(directory + path);
            }
            using (FileStream fileStream = File.Create(directory + path + newFileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            return ("https://localhost:44343/" + path + newFileName).Replace("\\", "/");
        }

        public static string Update(IFormFile file, string oldImagePath)
        {
            Delete(oldImagePath);
            return Add(file);
        }

        public static void Delete(string imagePath)
        {
            if (File.Exists(directory + imagePath.Replace("/", "\\"))
                && Path.GetFileName(imagePath) != "default.png")
            {
                File.Delete(directory + imagePath.Replace("/", "\\"));
            }
        }
    }
}
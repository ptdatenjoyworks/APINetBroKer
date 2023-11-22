﻿using Core.Services;
using Microsoft.AspNetCore.Http;
using System.IO.Compression;

namespace Domain.Service
{
    public class FileService : IFileService
    {
        private string FilePath = $"{AppDomain.CurrentDomain.BaseDirectory}ContractItemAttchments";
        public async Task<string> SaveFileAttachment(IFormFile file)
        {
            try
            {
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(FilePath, uniqueFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return filePath;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public byte[] GetFileDownload(string path)
        {
            if (string.IsNullOrEmpty(path) || !System.IO.File.Exists(path))
            {
                throw new ArgumentNullException("File not found");
            }

            var filebyte = System.IO.File.ReadAllBytes(path);
            if (!FileLengthCaculate(filebyte))
            {
                throw new ArgumentNullException("attachment file size too big");
            }
            return filebyte;
        }

        public MemoryStream GetAllFileDownload(List<string> files)
        {
            using (var memoryStream = new MemoryStream())
            {
                // Create a new zip archive
                using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    foreach (var file in files)
                    {
                        var fileInfo = new FileInfo(file);

                        // Create a new entry in the zip archive for each file
                        var entry = zipArchive.CreateEntry(fileInfo.Name);

                        // Write the file contents into the entry
                        using (var entryStream = entry.Open())
                        using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                        {
                            fileStream.CopyTo(entryStream);
                        }
                    }
                }
                memoryStream.Seek(0, SeekOrigin.Begin);
                if (!FileLengthCaculate(memoryStream.ToArray()))
                {
                    throw new ArgumentNullException("attachment file size too big");
                }

                return memoryStream;
            }
        }

        public bool FileLengthCaculate(byte[] fileLenght)
        {
            double filesize = (double)fileLenght.Length / (1024 * 1024 * 1024);
            return filesize < 2;
        }

    }
}

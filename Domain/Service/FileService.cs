using Core.Entities.Contract;
using Core.Models.Requests.Contract;
using Core.Services;
using Microsoft.AspNetCore.Http;

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
    }
}

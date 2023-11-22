using Core.Entities.Contract;
using Core.Models.Requests.Contract;
using Microsoft.AspNetCore.Http;

namespace Core.Services
{
    public interface IFileService
    {
        Task<string> SaveFileAttachment(IFormFile file);

        byte[] GetFileDownload(string path);

        MemoryStream GetAllFileDownload(List<string> files);
    }
}

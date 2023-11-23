using Core.Entities.Contract;
using Core.Models.Requests.Contract;
using Microsoft.AspNetCore.Http;

namespace Core.Services
{
    public interface IFileService
    {
        Task<string> SaveFileAttachment(IFormFile file);

        byte[] GetFileDownload(string path);

        Task GetAllFileDownload(List<string> files, Stream stream);
    }
}

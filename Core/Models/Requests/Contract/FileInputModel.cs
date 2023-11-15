using Microsoft.AspNetCore.Http;

namespace Core.Models.Requests.Contract
{
    public class FileInputModel
    {
        public int Id { get; set; } 
        public IFormFile? File { get; set; }
    }
}

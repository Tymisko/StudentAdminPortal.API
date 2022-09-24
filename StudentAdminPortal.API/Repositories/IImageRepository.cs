using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace StudentAdminPortal.API.Repositories
{
    public interface IImageRepository
    {
        Task<string> UploadAsync(IFormFile file, string fileName);
    }
}
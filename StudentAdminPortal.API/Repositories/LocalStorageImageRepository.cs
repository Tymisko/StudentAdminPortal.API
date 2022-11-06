using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace StudentAdminPortal.API.Repositories
{
    public class LocalStorageImageRepository : IImageRepository
    {
        public async Task<string> UploadAsync(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Images", fileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);

            return GetServerRelativePath(fileName);
        }

        private string GetServerRelativePath(string fileName)
        {
            return Path.Combine("Resources", "Images", fileName);
        }
    }
}
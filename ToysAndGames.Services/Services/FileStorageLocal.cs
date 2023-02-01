using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using ToysAndGames.Services.Interfaces;

namespace ToysAndGames.Services.Services
{
    public class FileStorageLocal : IFileStorage
    {
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FileStorageLocal(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _env = env;
            _httpContextAccessor = httpContextAccessor;
        }
        public Task DeleteFile(string route, string container)
        {
            if (route != null)
            {
                var fileName = Path.GetFileName(route);
                string fileFolder = Path.Combine(_env.WebRootPath, container, fileName);

                if (File.Exists(fileFolder))
                    File.Delete(fileFolder);
            }

            return Task.FromResult(0);
        }

        public async Task<string> EditFile(byte[] content, string extension, string container, string route, string contentType)
        {
            await DeleteFile(route, container);
            return await SaveFile(content, extension, container, contentType);
        }

        public async Task<string> SaveFile(byte[] content, string extension, string container, string contentType)
        {
            var fileName = $"{Guid.NewGuid()}{extension}";
            string folder = Path.Combine(_env.WebRootPath, container);

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string route = Path.Combine(folder, fileName);
            await File.WriteAllBytesAsync(route, content);

            var currentURL = $"{_httpContextAccessor.HttpContext?.Request.Scheme}://{_httpContextAccessor.HttpContext?.Request.Host}";
            var urlDB = Path.Combine(currentURL, container, fileName).Replace("\\", "/");
            return urlDB;
        }
    }
}

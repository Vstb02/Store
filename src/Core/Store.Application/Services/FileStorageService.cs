using Store.Application.Common.Configurations;
using Store.Application.Interfaces;

namespace Store.Application.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly string _basePath;
        public FileStorageService(FileStorageConfiguration storageConfiguration)
        {
            _basePath = storageConfiguration.BasePath;
        }

        public Task<bool> Delete(string directory, string key, CancellationToken cancellationToken = default)
        {
            if (!IsFileExist(directory, key))
                return Task.FromResult(false);

            var fullPath = GetFullPathFile(directory, key);

            File.Delete(fullPath);
            return Task.FromResult(true);
        }

        public Task<Stream> Download(string directory, string key, CancellationToken cancellationToken = default)
        {
            if (!IsFileExist(directory, key))
                throw new FileNotFoundException($"File not found in store {GetFullPathFile(directory, "")}", key);

            var fullPathFile = GetFullPathFile(directory, key);

            return Task.FromResult<Stream>(new FileStream(fullPathFile, FileMode.Open, FileAccess.Read, FileShare.Read));
        }

        public async Task<string> Upload(string directory, Stream dataStream, string fileExtension, CancellationToken cancellationToken = default)
        {
            CheckDirectoryAndCreateIfNotExist(directory);

            var newFileName = GenerateNewKey(fileExtension);
            var newFileFullPath = GetFullPathFile(directory, newFileName);

            using (var fileStream = new FileStream(newFileFullPath, FileMode.CreateNew, FileAccess.Write, FileShare.None))
            {
                await dataStream.CopyToAsync(fileStream, cancellationToken);
            }

            return newFileName;
        }

        public void HardDelete(string urlFile)
        => File.Delete($"./{urlFile}");


        protected bool IsFileExist(string directory, string key)
            => File.Exists(GetFullPathFile(directory, key));

        protected string GetFullPathFile(string directory, string key)
            => Path.Combine(GetFullPathDir(directory), key);

        protected string GetFullPathDir(string dir)
            => Path.Combine(_basePath.ToLower(), dir);

        protected void CheckDirectoryAndCreateIfNotExist(string directory)
        {
            var fullPath = Path.Combine(_basePath, directory);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
        }

        protected string GenerateNewKey(string fileExtension)
            => $"{Guid.NewGuid()}{fileExtension}";
    }
}

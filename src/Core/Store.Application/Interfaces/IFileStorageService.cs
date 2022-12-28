namespace Store.Application.Interfaces
{
    public interface IFileStorageService
    {
        /// <summary>
        /// Сохраняет данные в хранилище
        /// </summary>
        /// <param name="dataStream"></param>
        /// <returns></returns>
        Task<string> Upload(string directory, Stream dataStream, string fileExtension, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получение файла по ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Поток содержащий данные</returns>
        Task<Stream> Download(string directory, string key, CancellationToken cancellationToken = default);
        Task<bool> Delete(string directory, string key, CancellationToken cancellationToken = default);
        void HardDelete(string urlFile);
    }
}

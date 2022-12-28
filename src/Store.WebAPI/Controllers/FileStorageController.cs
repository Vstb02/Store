using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces;
using Store.WebAPI.Helpers;
using Store.WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace Store.WebAPI.Controllers
{
    public class FileStorageController : ApiControllerBase
    {
        private readonly string dir = "FileStorage";

        private readonly IFileStorageService _fileStorageService;
        private readonly ILogger<FileStorageController> _logger;

        public FileStorageController(ILogger<FileStorageController> logger,
                                     IFileStorageService fileStorageService)
        {
            _logger = logger;
            _fileStorageService = fileStorageService;
        }

        /// <summary>
        /// Сохранение файла
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Success</response>
        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFile([Required] IFormFile file)
        {
            try
            {
                var fileExtension = FileHelper.GetFileExtension(file.ContentType);
                if (fileExtension is null)
                {
                    return BadRequest("Запрещеный тип файла");
                }
                var key = await _fileStorageService.Upload(dir, file.OpenReadStream(), fileExtension);

                return Ok($"/{dir}/{key})");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при сохранении файла");
                return StatusCode(500, "Произошла ошибка при сохранении файла");
            }
        }

        /// <summary>
        /// Удаление файла
        /// </summary>
        /// <param name="fileUrl"></param>
        /// <returns></returns>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Success</response>
        [HttpDelete]
        public IActionResult Delete([Required] string fileUrl)
        {
            try
            {
                _fileStorageService.HardDelete(fileUrl);

                return Ok("Файл успешно удален");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при удалении файла");
                return StatusCode(500, "Произошла ошибка при удалении файла");
            }
        }
    }
}

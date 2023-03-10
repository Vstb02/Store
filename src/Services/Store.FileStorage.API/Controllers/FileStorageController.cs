using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Common.Helpers;
using Store.Application.Common.Identity;
using Store.Application.Interfaces;
using Store.Infrastructure.Base.Controllers;
using System.ComponentModel.DataAnnotations;

namespace Store.FileStorage.API.Controllers
{
    [Authorize(Roles = $"{IdentityRoles.Admin}, {IdentityRoles.Operator}")]
    public class FileStorageController : ApiControllerBase
    {
        private readonly string dir = "FileStorage";

        private readonly IFileStorageService _fileStorageService;

        public FileStorageController(IFileStorageService fileStorageService)
        {
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
            var fileExtension = FileHelper.GetFileExtension(file.ContentType);
            if (fileExtension is null)
            {
                return BadRequest(new { ErrorMessage = "Запрещеный тип файла" });
            }
            var key = await _fileStorageService.Upload(dir, file.OpenReadStream(), fileExtension);

            return Ok($"/{dir}/{key})");
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
            _fileStorageService.HardDelete(fileUrl);

            return Ok("Файл успешно удален");
        }
    }
}

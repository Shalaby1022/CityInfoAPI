using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.OpenApi.Extensions;

namespace CityInfoAPI.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : Controller
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider
            ?? throw new System.ArgumentNullException(
                nameof(fileExtensionContentTypeProvider));

        }

        [HttpGet("{FileId}")]
        public IActionResult GetFile(string FileId)
        {
            var path = "C:\\Users\\lenovo\\source\\repos\\CityInfoAPI\\CityInfoAPI\\02-DA-DataCategorization (1).pdf";

            if(!System.IO.File.Exists(path))
            {
                return NotFound();
            }
            if(!_fileExtensionContentTypeProvider.TryGetContentType(path, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes ,contentType, Path.GetFileName(path));
            
        }
    }
}

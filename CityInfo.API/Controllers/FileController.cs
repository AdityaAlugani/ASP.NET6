using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider contentprovider;
        public FileController(FileExtensionContentTypeProvider filecontentprovider) 
        {
            contentprovider= filecontentprovider;
        }
        [HttpGet("{fileid}")]
        public ActionResult GetFile(string fileid)
        {
            string filePath = "RESUME.ALUGANIADITYA.docx";
            if(!System.IO.File.Exists(filePath)) 
            {
                return NotFound();
            }
            contentprovider.TryGetContentType(filePath, out var contentType);
            var bytes=System.IO.File.ReadAllBytes(filePath);
            return File(bytes,contentType,Path.GetFileName(filePath));
        }
    }
}

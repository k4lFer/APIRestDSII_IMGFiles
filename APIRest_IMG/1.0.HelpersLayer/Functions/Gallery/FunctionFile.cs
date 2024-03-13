

using Microsoft.AspNetCore.Http;

namespace _1._0.HelpersLayer.Functions.Gallery
{
    public class FunctionFile
    {
        public string ConvertBase64(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            // Utiliza la versión sincrónica de CopyTo
            file.CopyTo(memoryStream);
            memoryStream.Position = 0;
            var fileBytes = memoryStream.ToArray();
           
            var base64String = Convert.ToBase64String(fileBytes);
            return base64String;
        }

        
       /* public async Task<string> ConvertToBase64Async(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var fileBytes = memoryStream.ToArray();
            var base64String = Convert.ToBase64String(fileBytes);
            return base64String;
        }*/
         
    }
}

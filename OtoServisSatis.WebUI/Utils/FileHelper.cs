namespace OtoServisSatis.WebUI.Utils
{
    public class FileHelper
    {
        public static async Task<string> FileLoaderAsync(IFormFile formFile,string filePath="/Img/")
        {
            var dosyaAd = " ";
            if (formFile != null && formFile.Length>0)
            {
                dosyaAd = formFile.FileName;
                string directory=Directory.GetCurrentDirectory()+"/wwwroot/"+filePath+dosyaAd;
                using var stream = new FileStream(directory, FileMode.Create);
                await formFile.CopyToAsync(stream);
            }
            return dosyaAd;

        }
    }
}

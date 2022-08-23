using System;

namespace Food.API.Services;

public class FileService
{
    private readonly IConfiguration _configuration;

    public FileService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<string> UploadFile(IFormFile file,string type)
    {
        try
        {
            if (file != null && file.Length > 0)
            {
          
                var id = Guid.NewGuid().ToString("N");
                var extension = Path.GetExtension(file.FileName);
                var fileName = $"{id}{extension}";

                var folder = _configuration[$"AssetsDirectories:{type}"];

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

           
                string temp_filePath = $"{folder}{Path.DirectorySeparatorChar}{fileName}";
                using (Stream fileStream = new FileStream(temp_filePath, FileMode.Create, FileAccess.Write))
                {
                    fileStream.Position = 0;
                 await   file.CopyToAsync(fileStream);
                }

            

                return fileName;
            }
            return null;
        }
        catch (Exception e)
        {
            return null;
        }
    }

}
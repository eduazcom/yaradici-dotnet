namespace YaradiciEduAz.Abstractions.IServices;

public interface IFileStorageService
{
    public Task<string?> SaveBase64AsImageAsync(string base64String, string directoryPath);
}

public class FileStorageService:IFileStorageService
{
    private readonly string _baseUrl;

    public FileStorageService(IConfiguration configuration)
    {
        _baseUrl = configuration["BaseUrl"] + "/teacher-thumbnails";
    }

    public async Task<string?> SaveBase64AsImageAsync(string base64String, string directoryPath)
    {
        try
        {
            // Base64 başlığını sil
            var base64Data = base64String.Contains(",") 
                ? base64String.Split(',')[1] 
                : base64String;

            var fileBytes = Convert.FromBase64String(base64Data);

            // Unikal fayl adı yarat
            var fileName = $"{Guid.NewGuid()}.png"; 
            var filePath = Path.Combine(directoryPath, fileName);

            // Qovluq yoxdursa, yarat
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            // Faylı yadda saxla
            await File.WriteAllBytesAsync(filePath, fileBytes);

            // URL yarat və qaytar
            return $"{_baseUrl}/{fileName}";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving Base64 image: {ex.Message}");
            return null;
        }
    }
}

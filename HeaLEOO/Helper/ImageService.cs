public class ImageService
{
    private readonly IWebHostEnvironment _env;

    public ImageService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public async Task<string> UploadImageAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return null!;
        var extension = Path.GetExtension(file.FileName);
        var fileName = $"{Guid.NewGuid().ToString()}{extension}";
        var path = Path.Combine(_env.WebRootPath, "uploads", fileName);
        if (!Directory.Exists(Path.Combine(_env.WebRootPath, "uploads")))
            Directory.CreateDirectory(Path.Combine(_env.WebRootPath, "uploads"));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return fileName; 
    }
    public void DeleteImage(string fileName)
    {
        if (string.IsNullOrEmpty(fileName)) return;

        var path = Path.Combine(_env.WebRootPath, "uploads", fileName);
        if (File.Exists(path))
            File.Delete(path);
    }
}

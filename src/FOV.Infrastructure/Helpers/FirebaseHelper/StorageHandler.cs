using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace FOV.Infrastructure.Helpers.FirebaseHandler;

public record StorageFile
{
    public string FileName { get; set; } = default!;
    public string FileUrl { get; set; } = default!;
}

public class StorageHandler
{
    private readonly FirebaseStorage _firebaseStorage;
    public StorageHandler(IConfiguration configuration)
    {
        string apiKey = configuration["Firebase:ApiKey"];
        string bucket = configuration["Firebase:Bucket"];
        _firebaseStorage = new FirebaseStorage(bucket, new FirebaseStorageOptions
        {
            AuthTokenAsyncFactory = () => Task.FromResult(apiKey)
        });
    }

    public async Task<StorageFile> UploadQrImageForTableAsync(Stream qrImageStream, string fileName)
    {
        var fileUrl = await _firebaseStorage
            .Child("qrcodes")
            .Child(fileName)
            .PutAsync(qrImageStream);

        return new StorageFile
        {
            FileName = fileName,
            FileUrl = fileUrl
        };
    }
    public async Task<StorageFile> UploadQrImageForAttendanceAsync(Stream qrImageStream, string fileName)
    {
        var fileUrl = await _firebaseStorage
            .Child("attendance")
            .Child(fileName)
            .PutAsync(qrImageStream);

        return new StorageFile
        {
            FileName = fileName,
            FileUrl = fileUrl
        };
    }

    public async Task<StorageFile> UploadImageAsync(IFormFile file, string fileName)
    {
        if (file == null || file.Length == 0)
        {
            throw new Exception("File does not exist or is empty.");
        }

        using var stream = file.OpenReadStream();
        var cancellation = _firebaseStorage
            .Child(fileName) // Specify the folder where you want to upload
            .Child(file.FileName)
            .PutAsync(stream, CancellationToken.None);

        try
        {
            var result = await cancellation;

            return new StorageFile
            {
                FileName = fileName,
                FileUrl = result
            };
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to upload image: {ex.Message}");
        }
    }


}

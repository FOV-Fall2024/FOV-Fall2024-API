using Firebase.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Domain.Helpers.FirebaseHandler;

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

    public async Task<StorageFile> UploadQrImageAsync(Stream qrImageStream, string fileName)
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
}
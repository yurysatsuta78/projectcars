using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using projectcars.Interfaces.Services;
using SixLabors.ImageSharp;

namespace projectcars.Services
{
    public class GoogleDriveService : IGoogleDriveService
    {
        private readonly string _jsonKeyPath;

        public GoogleDriveService(IConfiguration configuration)
        {
            _jsonKeyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configuration["GoogleDrive:JsonKeyPath"]);
        }

        private async Task<GoogleCredential> GetCredentials()
        {
            var credential = await Task.Run(() => GoogleCredential.FromFile(_jsonKeyPath)
                .CreateScoped(DriveService.ScopeConstants.Drive));
            return credential;
        }

        private DriveService CreateDriveService(GoogleCredential credential)
        {
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "ProjectCarsWebApiCloud"
            });

            return service;
        }

        public async Task<Models.Image> UploadImage(IFormFile image, Guid? carId, Guid? brandId, Guid? generationId)
        {
            var quality = 60;

            if (image != null)
            {
                var folderId = carId != null ? "1xji7BWp4CTsxRozXrys1A43Y6vfJMUCE" : (brandId != null ? "1YtHYEXlgf4A6QrSpcmPXUDVLOLfqxjJU" : (generationId != null ? "1ajMYZSopdB3sdWeQmevYzl6Duem1fW1f" : null));
                if (folderId == null)
                {
                    throw new ArgumentException("At least one of carId, brandId or generationId must be provided.");
                }

                var credentials = await GetCredentials();
                var googleDriveService = CreateDriveService(credentials);

                var fileName = $"{Guid.NewGuid()}.jpg";
                using var img = SixLabors.ImageSharp.Image.Load(image.OpenReadStream());
                using var stream = new MemoryStream();
                await img.SaveAsJpegAsync(stream, new SixLabors.ImageSharp.Formats.Jpeg.JpegEncoder { Quality = quality });
                stream.Position = 0;

                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = fileName,
                    MimeType = "image/jpeg",
                    Parents = new List<string> { folderId }
                };
                FilesResource.CreateMediaUpload imageRequest = googleDriveService.Files.Create(fileMetadata, stream, "image/jpeg");
                imageRequest.Fields = "id";
                await imageRequest.UploadAsync();

                var permission = new Google.Apis.Drive.v3.Data.Permission()
                {
                    Type = "anyone",
                    Role = "reader",
                    AllowFileDiscovery = true
                };
                var permissionRequest = googleDriveService.Permissions.Create(permission, imageRequest.ResponseBody.Id);
                await permissionRequest.ExecuteAsync();

                var fileUrl = $"https://drive.google.com/uc?id={imageRequest.ResponseBody.Id}";
                var newImage = Models.Image.Create(Guid.NewGuid(), fileUrl);
                return newImage;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}

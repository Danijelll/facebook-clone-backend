using FacebookClone.BLL.Constants;
using FacebookClone.BLL.Model;

namespace FacebookClone.Presentation.Helpers
{
    public static class ImageUploadHelper
    {
        public static string UploadImage(string folderName, IFormFile file, string webRootPath)
        {

            IEnumerable<string> allowedExtensions = ImageConstants.AllowedImageExtensions;

            string extension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(extension))
            {
                throw BusinessExceptions.ImageExtensionNotValidException;
            }

            if (file.Length > ImageConstants.MaxImageSize)
            {
                throw BusinessExceptions.ImageSizeNotValidException;
            }

            string folderPath = Path.Combine(webRootPath, folderName);

            Directory.CreateDirectory(folderPath);

            string url = Upload(file, folderPath);

            return url;
        }

        public static string Upload(IFormFile file, string uploadLocation)
        {
            string fileName = DateTime.UtcNow.Ticks.ToString() + Guid.NewGuid().GetHashCode() + Path.GetExtension(file.FileName);

            string path = Path.Combine(uploadLocation, fileName);

            using(FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return fileName;
        }

        internal static string UploadImage(string folderName, IFormFile image, object webRootPath)
        {
            throw new NotImplementedException();
        }
    }
}

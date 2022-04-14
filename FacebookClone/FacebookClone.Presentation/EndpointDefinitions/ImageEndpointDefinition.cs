using FacebookClone.BLL.Constants;
using FacebookClone.BLL.DTO;
using FacebookClone.BLL.Model;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Shared;
using FacebookClone.Presentation.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FacebookClone.Presentation.EndpointDefinitions
{
    public static class ImageEndpointDefinition
    {
        public static void DefineEndpoints(WebApplication app)
        {
            app.MapPost("/images", (HttpContext context, HttpRequest request, IImageService imageService, IWebHostEnvironment environment) =>
            {
                string imageData = request.Form["data"];

                ImageDTO imageDto = JsonConvert.DeserializeObject<ImageDTO>(imageData);

                if(request.Form.Files.Count == 0)
                {
                    throw BusinessExceptions.ImageNotUploadedException;
                }

                    IFormFile image = request.Form.Files[0];

                    string folderName = Path.Combine(ImageConstants.ImageFolder, imageDto.AlbumId.ToString());

                    string imageUrl = ImageUploadHelper.UploadImage(folderName, image, environment.WebRootPath);

                    imageDto.ImageUrl = imageUrl;

                ImageDTO result = imageService.Add(imageDto, Convert.ToInt32(context.User.Claims.SingleOrDefault(e => e.Type == "id").Value));

                return result;
            });

            app.MapGet("/images/search/{albumId}", (IImageService imageService, HttpContext context, int albumId) => imageService.GetAllByAlbumId(albumId, Convert.ToInt32(context.User.Claims.SingleOrDefault(e => e.Type == "id").Value)));

            app.MapDelete("/images/{id}", (IImageService imageService, int id, IWebHostEnvironment environment) => 
            {
                imageService.Delete(id, environment.WebRootPath);
            });
        }
    }
}

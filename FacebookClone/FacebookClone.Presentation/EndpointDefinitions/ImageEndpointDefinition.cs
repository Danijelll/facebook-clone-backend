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
            app.MapPost("/images", (HttpRequest request, IImageService imageService, IWebHostEnvironment environment) =>
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

                ImageDTO result = imageService.Add(imageDto);

                return result;
            });

            app.MapGet("/images", (IImageService imageService, [FromQuery(Name = "pageSize")] int pageSize, [FromQuery(Name = "pageNumber")] int pageNumber) => imageService.GetAll(pageSize, pageNumber));

            app.MapGet("/images/{id}", (IImageService imageService, int id) => imageService.GetById(id));

            app.MapGet("/images/search/{albumId}", (IImageService imageService, int albumId, [FromQuery(Name = "pageSize")] int pageSize, [FromQuery(Name = "pageNumber")] int pageNumber) => imageService.GetAllByAlbumId(albumId, pageSize, pageNumber));

            app.MapDelete("/images/{id}", (IImageService imageService, int id, IWebHostEnvironment environment) => 
            {
                imageService.Delete(id, environment.WebRootPath);
            });

            app.MapPut("/images", (ImageDTO image, IImageService imageService) => imageService.Update(image));
        }
    }
}

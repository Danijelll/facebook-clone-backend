using FacebookClone.BLL.Constants;
using FacebookClone.BLL.DTO.Albums;
using FacebookClone.BLL.DTO.Image;
using FacebookClone.BLL.Model;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.Presentation.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FacebookClone.Presentation.EndpointDefinitions
{
    public static class AlbumEndpointDefinition
    {
        public static void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/albums", [Authorize(Roles = "Admin", Policy = "RequireId")] (IAlbumService albumService) => albumService.GetAll());

            app.MapPost("/albums", [Authorize(Roles = "Admin,User", Policy = "RequireId")] (HttpRequest request, IAlbumService albumService, IWebHostEnvironment environment) =>
            {
                if (request.Form.Files.Count == 0)
                {
                    throw BusinessExceptions.ImageNotUploadedException;
                }

                string albumData = request.Form["data"];

                if (string.IsNullOrEmpty(albumData))
                {
                    throw BusinessExceptions.ImageSizeNotValidException;
                }

                AlbumWithImagesDTO albumWithImagesDTO = JsonConvert.DeserializeObject<AlbumWithImagesDTO>(albumData);

                albumWithImagesDTO.Images = new List<ImageDTO>();

                for (int i = 0; i < request.Form.Files.Count; i++)
                {
                    IFormFile image = request.Form.Files[i];

                    string folderName = Path.Combine(ImageConstants.ImageFolder, albumWithImagesDTO.UserId.ToString());

                    string imageUrl = ImageUploadHelper.UploadImage(folderName, image, environment.WebRootPath);

                    albumWithImagesDTO.Images.Add(new ImageDTO
                    {
                        ImageUrl = imageUrl,
                    });
                }

                AlbumWithImagesDTO result = albumService.Add(albumWithImagesDTO);

                return result;
            });

            app.MapGet("/albums/{id}", [Authorize(Roles = "Admin,User", Policy = "RequireId")] (IAlbumService albumService, int id) => albumService.GetById(id));

            app.MapGet("/albums/search/{userId}", [Authorize(Roles = "Admin,User", Policy = "RequireId")] (IAlbumService albumService, int userId, [FromQuery(Name = "pageSize")] int pageSize, [FromQuery(Name = "pageNumber")] int pageNumber) => albumService.GetAllAlbumWithImagesByUserId(userId, pageSize, pageNumber));

            app.MapDelete("/albums/{id}", [Authorize(Roles = "Admin,User", Policy = "RequireId")] (IAlbumService albumService, int id) => albumService.Delete(id));

            app.MapPut("/albums", [Authorize(Roles = "Admin,User", Policy = "RequireId")] (AlbumDTO album, IAlbumService albumService) => albumService.Update(album));

            app.MapGet("/feed", [Authorize(Roles = "Admin,User", Policy = "RequireId")] (HttpContext context, IAlbumService albumService, [FromQuery(Name = "pageSize")] int pageSize, [FromQuery(Name = "pageNumber")] int pageNumber) => albumService.GetAllFriendsWithAlbumsWithImages(Convert.ToInt32(context.User.Claims.SingleOrDefault(e => e.Type == "id").Value), pageSize, pageNumber));

        }
    }
}
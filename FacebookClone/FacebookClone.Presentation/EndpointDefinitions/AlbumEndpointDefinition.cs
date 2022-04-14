﻿using FacebookClone.BLL.Constants;
using FacebookClone.BLL.DTO;
using FacebookClone.BLL.Mappers;
using FacebookClone.BLL.Model;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.Presentation.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FacebookClone.Presentation.EndpointDefinitions
{
    public static class AlbumEndpointDefinition
    {
        public static void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/albums", (IAlbumService albumService, [FromQuery(Name = "pageSize")] int pageSize, [FromQuery(Name = "pageNumber")] int pageNumber) => albumService.GetAll(pageSize, pageNumber));

            app.MapPost("/albums", (HttpRequest request, IAlbumService albumService, IWebHostEnvironment environment) =>
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

                for(int i = 0; i < request.Form.Files.Count; i++)
                {
                    IFormFile image = request.Form.Files[i];

                    string folderName = Path.Combine(ImageConstants.ImageFolder, albumWithImagesDTO.UserId.ToString());

                    string imageUrl = ImageUploadHelper.UploadImage(folderName, image, environment.WebRootPath);

                    albumWithImagesDTO.Images[i].ImageUrl = imageUrl;
                }

                AlbumWithImagesDTO result = albumService.Add(albumWithImagesDTO);

                return result;
            });

            app.MapGet("/albums/{id}", (IAlbumService albumService, int id) => albumService.GetById(id));

            app.MapGet("/albums/search/{userId}", (IAlbumService albumService, int userId, [FromQuery(Name = "pageSize")] int pageSize, [FromQuery(Name = "pageNumber")] int pageNumber) => albumService.GetAllByUserId(userId, pageSize, pageNumber));

            app.MapDelete("/albums/{id}", (IAlbumService albumService, int id) => albumService.Delete(id));

            app.MapPut("/albums", (AlbumDTO album, IAlbumService albumService) => albumService.Update(album));
        }
    }
}
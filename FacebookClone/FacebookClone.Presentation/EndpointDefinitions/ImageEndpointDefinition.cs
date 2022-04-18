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

            app.MapGet("/images/search/{albumId}", (IImageService imageService, HttpContext context, int albumId) => imageService.GetAllByAlbumId(albumId, Convert.ToInt32(context.User.Claims.SingleOrDefault(e => e.Type == "id").Value)));

            app.MapDelete("/images/{id}", (IImageService imageService, int id, IWebHostEnvironment environment) => 
            {
                imageService.Delete(id, environment.WebRootPath);
            });
        }
    }
}

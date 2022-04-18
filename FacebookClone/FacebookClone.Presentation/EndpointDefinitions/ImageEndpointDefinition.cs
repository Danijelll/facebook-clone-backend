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
            app.MapDelete("/images/{id}", (IImageService imageService, int id, IWebHostEnvironment environment) => 
            {
                imageService.Delete(id, environment.WebRootPath);
            });
        }
    }
}

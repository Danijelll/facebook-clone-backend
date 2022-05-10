using FacebookClone.BLL.Services.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace FacebookClone.Presentation.EndpointDefinitions
{
    public static class ImageEndpointDefinition
    {
        public static void DefineEndpoints(WebApplication app)
        {
            app.MapDelete("/images/{id}", [Authorize(Policy = "RequireId")] (IImageService imageService, int id, IWebHostEnvironment environment) =>
            {
                imageService.Delete(id, environment.WebRootPath);
            });
        }
    }
}
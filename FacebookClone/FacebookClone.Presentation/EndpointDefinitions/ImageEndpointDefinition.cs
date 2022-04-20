using FacebookClone.BLL.Services.Abstract;

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
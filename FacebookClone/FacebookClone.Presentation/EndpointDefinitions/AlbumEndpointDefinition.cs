using FacebookClone.BLL.DTO;
using FacebookClone.BLL.Services.Abstract;

namespace FacebookClone.Presentation.EndpointDefinitions
{
    public static class AlbumEndpointDefinition
    {
        public static void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/albums", (IAlbumService albumService) => albumService.GetAll());

            app.MapPost("/albums", (AlbumDTO album, IAlbumService albumService) => albumService.Add(album));

            app.MapGet("/albums/{id}", (IAlbumService albumService, int id) => albumService.GetById(id));

            app.MapGet("/albums/search/{userId}", (IAlbumService albumService, int userId) => albumService.GetAllByUserId(userId));

            app.MapDelete("/albums/{id}", (IAlbumService albumService, int id) => albumService.Delete(id));

            app.MapPut("/albums", (AlbumDTO album, IAlbumService albumService) => albumService.Update(album));
        }
    }
}

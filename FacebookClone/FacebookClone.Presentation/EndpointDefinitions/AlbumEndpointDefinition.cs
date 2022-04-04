using FacebookClone.BLL.DTO;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Shared;

namespace FacebookClone.Presentation.EndpointDefinitions
{
    public static class AlbumEndpointDefinition
    {
        public static void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/albums", (IAlbumService albumService, PageFilter pageFilter) => albumService.GetAll(pageFilter));

            app.MapPost("/albums", (AlbumDTO album, IAlbumService albumService) => albumService.Add(album));

            app.MapGet("/albums/{id}", (IAlbumService albumService, int id) => albumService.GetById(id));

            app.MapGet("/albums/search/{userId}", (IAlbumService albumService, int userId, PageFilter pageFilter) => albumService.GetAllByUserId(userId, pageFilter));

            app.MapDelete("/albums/{id}", (IAlbumService albumService, int id) => albumService.Delete(id));

            app.MapPut("/albums", (AlbumDTO album, IAlbumService albumService) => albumService.Update(album));
        }
    }
}

using FacebookClone.BLL.DTO.Comment.Friendship;
using FacebookClone.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FacebookClone.Presentation.EndpointDefinitions
{
    public static class CommentEndpointDefinition
    {
        public static void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/comments", (ICommentService commentService, [FromQuery(Name = "pageSize")] int pageSize, [FromQuery(Name = "pageNumber")] int pageNumber) => commentService.GetAll(pageSize, pageNumber));

            app.MapPost("/comments", (CommentDTO comment, ICommentService commentService) => commentService.Add(comment));

            app.MapGet("/comments/{id}", (ICommentService commentService, int id) => commentService.GetById(id));

            app.MapGet("/comments/search/{userId}", (ICommentService commentService, int userId, [FromQuery(Name = "pageSize")] int pageSize, [FromQuery(Name = "pageNumber")] int pageNumber) => commentService.GetAllByUserId(userId, pageSize, pageNumber));

            app.MapGet("/comments/album/{albumId}", (ICommentService commentService, int albumId, [FromQuery(Name = "pageSize")] int pageSize, [FromQuery(Name = "pageNumber")] int pageNumber) => commentService.GetAllByAlbumId(albumId, pageSize, pageNumber));

            app.MapDelete("/comments/{id}", (ICommentService commentService, int id) => commentService.Delete(id));

            app.MapPut("/comments", (CommentDTO comment, ICommentService commentService) => commentService.Update(comment));
        }
    }
}
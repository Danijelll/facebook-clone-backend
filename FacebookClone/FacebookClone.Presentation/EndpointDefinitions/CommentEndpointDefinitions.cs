using FacebookClone.BLL.DTO;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Shared;
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

            app.MapGet("/comments/image/{imageId}", (ICommentService commentService, int imageId, [FromQuery(Name = "pageSize")] int pageSize, [FromQuery(Name = "pageNumber")] int pageNumber) => commentService.GetAllByImageId(imageId, pageSize, pageNumber));

            app.MapDelete("/comments/{id}", (ICommentService commentService, int id) => commentService.Delete(id));

            app.MapPut("/comments", (CommentDTO comment, ICommentService commentService) => commentService.Update(comment));
        }
    }
}
using FacebookClone.BLL.DTO;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Shared;

namespace FacebookClone.Presentation.EndpointDefinitions
{
    public static class CommentEndpointDefinition
    {
        public static void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/comments", (ICommentService commentService, PageFilter pageFilter) => commentService.GetAll(pageFilter));

            app.MapPost("/comments", (CommentDTO comment, ICommentService commentService) => commentService.Add(comment));

            app.MapGet("/comments/{id}", (ICommentService commentService, int id) => commentService.GetById(id));

            app.MapGet("/comments/search/{userId}", (ICommentService commentService, int userId, PageFilter pageFilter) => commentService.GetAllByUserId(userId, pageFilter));

            app.MapGet("/comments/image/{imageId}", (ICommentService commentService, int imageId, PageFilter pageFilter) => commentService.GetAllByImageId(imageId, pageFilter));

            app.MapDelete("/comments/{id}", (ICommentService commentService, int id) => commentService.Delete(id));

            app.MapPut("/comments", (CommentDTO comment, ICommentService commentService) => commentService.Update(comment));
        }
    }
}
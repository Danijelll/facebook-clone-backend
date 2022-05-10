﻿using FacebookClone.BLL.DTO.Comment.Friendship;
using FacebookClone.BLL.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FacebookClone.Presentation.EndpointDefinitions
{
    public static class CommentEndpointDefinition
    {
        public static void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/comments", [Authorize(Policy = "RequireId")] (ICommentService commentService) => commentService.GetAll());

            app.MapPost("/comments", [Authorize(Policy = "RequireId")] (CommentDTO comment, ICommentService commentService) => commentService.Add(comment));

            app.MapGet("/comments/{id}", [Authorize(Policy = "RequireId")] (ICommentService commentService, int id) => commentService.GetById(id));

            app.MapGet("/comments/search/{userId}", [Authorize(Policy = "RequireId")] (ICommentService commentService, int userId, [FromQuery(Name = "pageSize")] int pageSize, [FromQuery(Name = "pageNumber")] int pageNumber) => commentService.GetAllByUserId(userId, pageSize, pageNumber));

            app.MapGet("/comments/album/{albumId}", [Authorize(Policy = "RequireId")] (ICommentService commentService, int albumId, [FromQuery(Name = "pageSize")] int pageSize, [FromQuery(Name = "pageNumber")] int pageNumber) => commentService.GetAllByAlbumId(albumId, pageSize, pageNumber));

            app.MapDelete("/comments/{id}", [Authorize(Policy = "RequireId")] (ICommentService commentService, int id) => commentService.Delete(id));

            app.MapPut("/comments", [Authorize(Policy = "RequireId")] (CommentDTO comment, ICommentService commentService) => commentService.Update(comment));
        }
    }
}
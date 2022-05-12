using FacebookClone.BLL.DTO.Friendship;
using FacebookClone.BLL.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FacebookClone.Presentation.EndpointDefinitions
{
    public static class FriendshipEndpointDefinition
    {
        public static void DefineEndpoints(WebApplication app)
        {
            app.MapPost("/addFriend/{friendId}", [Authorize(Roles = "Admin,User", Policy = "RequireId")] (IFriendshipService friendshipService, HttpContext context, int friendId) => friendshipService.AddFriendRequest(Convert.ToInt32(context.User.Claims.SingleOrDefault(e => e.Type == "id").Value), friendId));

            app.MapGet("/friendRequests", [Authorize(Roles = "Admin,User", Policy = "RequireId")] (IFriendshipService friendshipService, HttpContext context, [FromQuery(Name = "pageSize")] int pageSize, [FromQuery(Name = "pageNumber")] int pageNumber) => friendshipService.GetAllIncomingFriendRequests(Convert.ToInt32(context.User.Claims.SingleOrDefault(e => e.Type == "id").Value), pageSize, pageNumber));

            app.MapDelete("/deleteRequest/{friendId}", [Authorize(Roles = "Admin,User", Policy = "RequireId")] (IFriendshipService friendshipService, HttpContext context, int friendId) => friendshipService.DeleteFriendRequest(Convert.ToInt32(context.User.Claims.SingleOrDefault(e => e.Type == "id").Value), friendId));

            app.MapPut("/confirmFriend/{friendId}", [Authorize(Roles = "Admin,User", Policy = "RequireId")] (IFriendshipService friendshipService, HttpContext context, int friendId) => friendshipService.Update(Convert.ToInt32(context.User.Claims.SingleOrDefault(e => e.Type == "id").Value), friendId));

            app.MapGet("/friendRequestStatus/{friendId}", [Authorize(Roles = "Admin,User", Policy = "RequireId")] (IFriendshipService friendshipService, HttpContext context, int friendId) => friendshipService.CheckFriendRequestStatus(Convert.ToInt32(context.User.Claims.SingleOrDefault(e => e.Type == "id").Value), friendId));

        }
    }
}
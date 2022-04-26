using FacebookClone.BLL.DTO.Friendship;
using FacebookClone.BLL.Services.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace FacebookClone.Presentation.EndpointDefinitions
{
    public static class FriendshipEndpointDefinition
    {
        public static void DefineEndpoints(WebApplication app)
        {
            app.MapPost("/addFriend/{friendId}", [Authorize(Policy = "RequireId")] (IFriendshipService friendshipService, HttpContext context, int friendId) => friendshipService.AddFriendRequest(Convert.ToInt32(context.User.Claims.SingleOrDefault(e => e.Type == "id").Value), friendId));

            app.MapPut("/confirmFriend/{friendRequestId}", (IFriendshipService friendshipService, int friendRequestId) => friendshipService.Update(friendRequestId));

            app.MapPost("/friendRequestStatus/{friendId}", [Authorize(Policy = "RequireId")] (IFriendshipService friendshipService, HttpContext context, int friendId) => friendshipService.CheckFriendRequestStatus(Convert.ToInt32(context.User.Claims.SingleOrDefault(e => e.Type == "id").Value), friendId));

        }
    }
}
using FacebookClone.BLL.DTO.Friendship;
using FacebookClone.BLL.Services.Abstract;

namespace FacebookClone.Presentation.EndpointDefinitions
{
    public static class FriendshipEndpointDefinition
    {
        public static void DefineEndpoints(WebApplication app)
        {
            app.MapPost("/addFriend/{friendId}", (IFriendshipService friendshipService, HttpContext context, int friendId) => friendshipService.AddFriendRequest(Convert.ToInt32(context.User.Claims.SingleOrDefault(e => e.Type == "id").Value), friendId));

            app.MapPut("/confirmFriend", (IFriendshipService friendshipService, FriendRequestDTO friendRequest) => friendshipService.Update(friendRequest));

        }
    }
}
using FacebookClone.BLL.DTO.Message;
using FacebookClone.BLL.Services.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace FacebookClone.Presentation.EndpointDefinitions
{
    public static class MessageEndpointDefiniton
    {
        public static void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/messages/{receiverId}", [Authorize(Roles = "Admin,User", Policy = "RequireId")] (IMessageService messageService, HttpContext context, int receiverId) => messageService.GetAllByBothUserId(Convert.ToInt32(context.User.Claims.SingleOrDefault(e => e.Type == "id").Value), receiverId));

            app.MapPost("/messages", [Authorize(Roles = "Admin,User", Policy = "RequireId")] (MessageDTO message, IMessageService messageService) => messageService.AddMessage(message));
           
        }
    }
}

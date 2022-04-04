using FacebookClone.BLL.DTO;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Shared;

namespace FacebookClone.Presentation.EndpointDefinitions
{
    public static class UserEndpointDefinition
    {
        public static void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/users", (IUserService userService, PageFilter pageFilter) => userService.GetAll(pageFilter));

            app.MapPost("/register", (UserDTO user, IUserService userService) => userService.Add(user));

            app.MapGet("/users/{id}", (IUserService userService, int id) => userService.GetById(id));

            app.MapGet("/users/search/{username}", (IUserService userService, string username) => userService.GetByUsername(username));

            app.MapDelete("/users/{id}", (IUserService userService, int id) => userService.Delete(id));

            app.MapPut("/update", (UserDTO user, IUserService userService) => userService.Update(user));
        }
    }
}

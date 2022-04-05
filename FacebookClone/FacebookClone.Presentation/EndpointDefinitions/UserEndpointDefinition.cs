using FacebookClone.BLL.DTO;
using FacebookClone.BLL.Mappers;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FacebookClone.Presentation.EndpointDefinitions
{
    public static class UserEndpointDefinition
    {
        public static void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/users", (IUserService userService, [FromQuery(Name = "pageSize")] int pageSize, [FromQuery(Name = "pageNumber")] int pageNumber) => userService.GetAll(pageSize, pageNumber));

            app.MapPost("/register", (UserDTO user, IUserService userService) => userService.Add(user));

            app.MapPost("/login", (UserDTO user, IJwtTokenService jwtTokenService) => jwtTokenService.GenerateJwt(user.ToEntity()));

            app.MapGet("/users/{id}", (IUserService userService, int id) => userService.GetById(id));

            app.MapGet("/users/search/{username}", (IUserService userService, string username) => userService.GetByUsername(username));

            app.MapDelete("/users/{id}", (IUserService userService, int id) => userService.Delete(id));

            app.MapPut("/update", (UserDTO user, IUserService userService) => userService.Update(user));
        }
    }
}

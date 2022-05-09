using FacebookClone.BLL.Constants;
using FacebookClone.BLL.DTO.Auth;
using FacebookClone.BLL.DTO.User;
using FacebookClone.BLL.Model;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.Presentation.Helpers;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace FacebookClone.Presentation.EndpointDefinitions
{
    public static class UserEndpointDefinition
    {
        public static void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/users", (IUserService userService) => userService.GetAll());

            app.MapPost("/register", (RegisterDTO userRegister, IUserService userService) => userService.Add(userRegister));

            app.MapPost("/login", (LoginDTO userLogin, IJwtTokenService jwtTokenService) => jwtTokenService.GenerateJwt(userLogin));

            app.MapGet("/home", [Authorize(Policy = "RequireId")] (IUserService userService, HttpContext context) =>
            {
                return Results.Ok(userService.GetById(Convert.ToInt32(context.User.Claims.SingleOrDefault(e => e.Type == "id").Value)));
            });

            app.MapGet("/users/{id}", (IUserService userService, int id) => userService.GetById(id));

            app.MapGet("/users/search/{username}", (IUserService userService, string username) => userService.SearchByUsername(username));

            app.MapDelete("/users/{id}", (IUserService userService, int id) => userService.Delete(id));

            app.MapPut("/updateProfileImage", [Authorize(Policy = "RequireId")] (HttpRequest request, HttpContext context, IUserService userService, IWebHostEnvironment environment) =>
            {
                int userId = Convert.ToInt32(context.User.Claims.SingleOrDefault(e => e.Type == "id").Value);

                if (request.Form.Files.Count == 0)
                {
                    throw BusinessExceptions.ImageNotUploadedException;
                }

                IFormFile image = request.Form.Files[0];

                string folderName = Path.Combine(ImageConstants.UserProfileImageFolder, userId.ToString());

                string imageUrl = ImageUploadHelper.UploadImage(folderName, image, environment.WebRootPath);

                return userService.UpdateProfileImage(userId, imageUrl,environment.WebRootPath);
            });

            app.MapPut("/updateCoverImage", [Authorize(Policy = "RequireId")] (HttpRequest request, HttpContext context, IUserService userService, IWebHostEnvironment environment) =>
            {
                int userId = Convert.ToInt32(context.User.Claims.SingleOrDefault(e => e.Type == "id").Value);

                if (request.Form.Files.Count == 0)
                {
                    throw BusinessExceptions.ImageNotUploadedException;
                }

                IFormFile image = request.Form.Files[0];

                string folderName = Path.Combine(ImageConstants.UserCoverImageFolder, userId.ToString());

                string imageUrl = ImageUploadHelper.UploadImage(folderName, image, environment.WebRootPath);

                return userService.UpdateCoverImage(userId, imageUrl, environment.WebRootPath);
            });

            app.MapGet("/confirmMail/{emailHash}", (HttpResponse response, IEmailConfirmService emailConfirmService, string emailHash) =>
            {
                emailConfirmService.ConfirmUserEmail(emailHash);
                response.Redirect("http://localhost:3000/");
            });
        }
    }
}
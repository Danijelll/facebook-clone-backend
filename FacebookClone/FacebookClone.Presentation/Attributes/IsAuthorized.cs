using FacebookClone.BLL.DTO;
using FacebookClone.BLL.Enums;
using FacebookClone.BLL.Model;
using FacebookClone.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;

namespace FacebookClone.Presentation.Attributes
{
    public class IsAuthorized : Attribute, IAuthorizationFilter
    {
        private IJwtTokenService _jwtTokenService;
        private IUserService _userService;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string authorizationHeader = context.HttpContext.Request.Headers["Authorization"];

            string tokenString = authorizationHeader.Substring("Bearer ".Length);

            _jwtTokenService = context.HttpContext.RequestServices.GetService(typeof(IJwtTokenService)) as IJwtTokenService;
            _userService = context.HttpContext.RequestServices.GetService(typeof(IUserService)) as IUserService;

            if (string.IsNullOrEmpty(authorizationHeader))
            {
                throw BusinessExceptions.NotAuthorizedException;
            }

            if(tokenString.ToLower() == "null" || tokenString.ToLower() == "undefined" || string.IsNullOrEmpty(tokenString))
            {
                throw BusinessExceptions.NotAuthorizedException;
            }

            try
            {
                JwtSecurityToken verifiedToken = _jwtTokenService.VerifyToken(tokenString);

                ClaimsDTO claimsDTO = _jwtTokenService.VerifyUser(verifiedToken);

                UserDTO userDTO = _userService.GetById(claimsDTO.Id);

                if((Roles)claimsDTO.Role == Roles.Admin)
                {
                    context.HttpContext.Items.Add("id", claimsDTO.Id);
                }
                else if(userDTO.IsBanned == false && userDTO.IsEmailConfirmed == true)
                {
                    context.HttpContext.Items.Add("id", claimsDTO.Id);
                    context.HttpContext.Items.Add("is_banned", claimsDTO.IsBanned);
                    context.HttpContext.Items.Add("is_email_confirmed", claimsDTO.IsEmailConfirmed);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
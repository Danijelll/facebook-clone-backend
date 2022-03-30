using FacebookClone.BLL.Exceptions;
using System.Net;

namespace FacebookClone.BLL.Model
{
    public static class BusinessExceptions
    {
        public static BusinessException EntityNotFoundByIdException(int entityId, string entityName) =>
            new BusinessException($"{entityName} with id {entityId} not found!", HttpStatusCode.NotFound);

        public static BusinessException NotAuthorizedException =>
            new BusinessException("Not Authorized!", HttpStatusCode.Unauthorized);

        public static BusinessException InvalidJwtTokenException =>
            new BusinessException("Invalid Jwt Token!", HttpStatusCode.Unauthorized);

        public static BusinessException EntityAlreadyExistsInDBEcxeption =>
            new BusinessException("Entity Already Exists In DB!", HttpStatusCode.BadRequest);

        public static BusinessException EntityDoesNotExistsInDBEcxeption =>
            new BusinessException("Entity Does Not Exists In DB!", HttpStatusCode.BadRequest);
    }
}
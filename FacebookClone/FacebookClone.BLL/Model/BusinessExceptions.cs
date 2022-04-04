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

        public static BusinessException EntityAlreadyExistsInDBException =>
            new BusinessException("Entity Already Exists In DB!", HttpStatusCode.BadRequest);

        public static BusinessException EntityDoesNotExistsInDBException =>
            new BusinessException("Entity Does Not Exists In DB!", HttpStatusCode.BadRequest);

        public static BusinessException ImageExtensionNotValidException =>
            new BusinessException("Image Extension Is Not Valid!", HttpStatusCode.BadRequest);

        public static BusinessException ImageSizeNotValidException =>
            new BusinessException("Image Size Is Not Valid!", HttpStatusCode.BadRequest);

        public static BusinessException ImageNotUploadedException =>
            new BusinessException("You Must Upload An Image!", HttpStatusCode.BadRequest);
    }
}
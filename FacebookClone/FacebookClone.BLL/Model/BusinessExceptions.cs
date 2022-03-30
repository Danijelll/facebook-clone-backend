using FacebookClone.BLL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FacebookClone.BLL.Model
{
    public static class BusinessExceptions
    {
        public static BusinessException EntityNotFoundByIdException(int entityId, string entityName) =>
            new BusinessException($"{entityName} with id {entityId} not found!", HttpStatusCode.NotFound);

    }
}

using System.Net;

namespace FacebookClone.BLL.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message, HttpStatusCode statuscode) : base(message)
        {
        }
    }
}
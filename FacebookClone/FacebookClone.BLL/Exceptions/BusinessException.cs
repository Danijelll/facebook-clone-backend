using System.Net;

namespace FacebookClone.BLL.Exceptions
{
    public class BusinessException : Exception
    {
        public HttpStatusCode StatusCode { get; set; } 
        public BusinessException(string message, HttpStatusCode statuscode) : base(message)
        {
            StatusCode = statuscode;
        }
    }
}
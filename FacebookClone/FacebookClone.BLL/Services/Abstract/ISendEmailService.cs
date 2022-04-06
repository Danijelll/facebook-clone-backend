using MimeKit;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface ISendEmailService
    {
        public void SendConfimCodeEmail(string emailReciver, string username, string emailHash);
    }
}
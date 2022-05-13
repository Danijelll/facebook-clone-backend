using MimeKit;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface ISendEmailService
    {
        void SendConfimCodeEmail(string emailReciver, string username, string emailHash);

        void Send2FACodeEmail(string emailReciver, string username, string twoFactorCode);
    }
}
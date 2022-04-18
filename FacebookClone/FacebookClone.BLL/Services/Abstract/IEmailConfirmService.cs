using FacebookClone.BLL.DTO.Auth;
using FacebookClone.BLL.DTO.User;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IEmailConfirmService
    {
        void Delete(int id);

        EmailConfirmDTO GetByUserId(int userId);

        EmailConfirmDTO GetByEmailHash(string emailHash);

        public void ConfirmUserEmail(string emailHash);

        EmailConfirmDTO Add(UserDTO userDTO);
    }
}
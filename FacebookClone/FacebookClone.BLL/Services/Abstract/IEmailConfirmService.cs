using FacebookClone.BLL.DTO;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IEmailConfirmService
    {
        void Delete(int id);

        EmailConfirmDTO GetByUserId(int userId);

        EmailConfirmDTO GetByEmailHash(string emailHash);

        EmailConfirmDTO Add(UserDTO userDTO);
    }
}
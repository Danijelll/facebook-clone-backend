using FacebookClone.BLL.DTO.Auth;
using FacebookClone.BLL.DTO.User;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IUserService
    {
        void Delete(int userId);

        IEnumerable<UserDTO> GetAll();

        UserDataDTO GetById(int userId);

        UserDataDTO GetByIdWithBanned(int userId);

        UserDTO Add(RegisterDTO userRegister);

        UserDTO UpdateProfileImage(int id, string imageUrl, string webRootPath);

        UserDTO UpdateCoverImage(int id, string imageUrl, string webRootPath);

        UserDTO GetByUsername(string username);

        UserDTO BanUserById(int id);

        UserDTO UnbanUserById(int id);

        IEnumerable<UserDTO> SearchByUsername(string username);

        IEnumerable<UserDTO> SearchByUsernameWithBanned(string username);

        public bool PasswordMatches(string userPass1, string userPass2);
    }
}
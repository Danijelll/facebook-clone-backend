using FacebookClone.BLL.DTO.Auth;
using FacebookClone.BLL.DTO.User;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IUserService
    {
        void Delete(int userId);

        IEnumerable<UserDTO> GetAll();

        UserDataDTO GetById(int userId);

        UserDTO GetByEmail(string email);

        UserDataDTO GetByIdWithBanned(int userId);

        UserDTO Add(RegisterDTO userRegister);

        UserDTO UpdateProfileImage(int id, string imageUrl, string webRootPath);

        UserDTO UpdateCoverImage(int id, string imageUrl, string webRootPath);

        UserDTO GetByUsername(string username);

        UserDTO BanUserById(int id);

        UserDTO UnbanUserById(int id);

        void Generate2FACode(LoginDTO userLogin);

        IEnumerable<UserDTO> SearchByUsername(string username, int pageSize, int pageNumber);

        IEnumerable<UserDTO> SearchByUsernameWithBanned(string username, int pageSize, int pageNumber);

        public bool PasswordMatches(string userPass1, string userPass2);

        IEnumerable<UserDataDTO> GetAllFriends(int id, int pageSize, int pageNumber);
    }
}
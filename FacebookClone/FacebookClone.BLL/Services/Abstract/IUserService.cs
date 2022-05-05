using FacebookClone.BLL.DTO.Auth;
using FacebookClone.BLL.DTO.User;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IUserService
    {
        void Delete(int userId);

        IEnumerable<UserDTO> GetAll();

        UserDataDTO GetById(int userId);

        UserDTO Add(RegisterDTO userRegister);

        UserDTO UpdateProfileImage(int id, string imageUrl);

        UserDTO UpdateCoverImage(int id, string imageUrl);

        UserDTO GetByUsername(string username);

        IEnumerable<UserDTO> SearchByUsername(string username);

        public bool PasswordMatches(string userPass1, string userPass2);
    }
}
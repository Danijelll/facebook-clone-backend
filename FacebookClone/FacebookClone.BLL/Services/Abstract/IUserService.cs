using FacebookClone.BLL.DTO.Auth;
using FacebookClone.BLL.DTO.User;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IUserService
    {
        void Delete(int userId);

        IEnumerable<UserDTO> GetAll(int pageSize, int pageNumber);

        UserDTO GetById(int userId);

        UserDTO Add(RegisterDTO userRegister);

        UserDTO Update(UserDTO userDTO);

        UserDTO GetByUsername(string username);

        public bool PasswordMatches(string userPass1, string userPass2);
    }
}
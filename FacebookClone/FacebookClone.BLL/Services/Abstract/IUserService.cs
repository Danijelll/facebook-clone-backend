using FacebookClone.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IUserService
    {
        void Delete(int userId);

        IEnumerable<UserDTO> GetAll();

        UserDTO GetById(int userId);

        UserDTO Add (UserDTO userDTO);

        UserDTO Update (UserDTO userDTO);

        UserDTO GetByUsername(string username);
    }
}

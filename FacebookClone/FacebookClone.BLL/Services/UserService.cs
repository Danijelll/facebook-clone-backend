using FacebookClone.BLL.Constants;
using FacebookClone.BLL.DTO.Auth;
using FacebookClone.BLL.DTO.User;
using FacebookClone.BLL.Mappers;
using FacebookClone.BLL.Model;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Shared;

namespace FacebookClone.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailConfirmService _emailConfirmService;
        private readonly ISendEmailService _sendEmailService;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IEmailConfirmService emailConfirmService, ISendEmailService sendEmailService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _emailConfirmService = emailConfirmService;
            _sendEmailService = sendEmailService;
            _unitOfWork = unitOfWork;
        }

        public UserDTO Add(RegisterDTO userRegister)
        {
            if (!ExistsWithName(userRegister.Username))
            {
                userRegister.Password = BCrypt.Net.BCrypt.HashPassword(userRegister.Password);

                User user = _userRepository.Add(userRegister.ToUserDTO().ToEntity());

                _unitOfWork.SaveChanges();

                UserDTO userDTO = user.ToDTO();

                EmailConfirmDTO emailConfirmDTO = _emailConfirmService.Add(userDTO);

                _unitOfWork.SaveChanges();

                _sendEmailService.SendConfimCodeEmail(userRegister.Email, userRegister.Username, emailConfirmDTO.EmailHash);

                return userDTO;
            }
            throw BusinessExceptions.EntityAlreadyExistsInDBException;
        }

        public void Delete(int userId)
        {
            User found = _userRepository.GetById(userId);

            if (found == null)
            {
                throw BusinessExceptions.EntityDoesNotExistsInDBException;
            }

            _userRepository.Delete(userId);
            _unitOfWork.SaveChanges();

            string profileImagePath = Path.Combine(ImageConstants.UserProfileImageFolder, found.ProfileImage);
            string coverImagePath = Path.Combine(ImageConstants.UserCoverImageFolder, found.CoverImage);

            if (File.Exists(coverImagePath))
            {
                File.Delete(coverImagePath);
            }

            if (File.Exists(profileImagePath))
            {
                File.Delete(profileImagePath);
            }
        }

        public IEnumerable<UserDTO> GetAll(int pageSize, int pageNumber)
        {
            PageFilter pageFilter = new PageFilter(pageSize, pageNumber);

            return _userRepository.GetAll(pageFilter)
                .ToDTOList();
        }

        public UserDataDTO GetById(int userId)
        {
            UserDTO found = _userRepository.GetById(userId).ToDTO();

            if (found == null)
            {
                throw BusinessExceptions.EntityDoesNotExistsInDBException;
            }

            if (found.IsBanned == true)
            {
                throw BusinessExceptions.UserBannedException;
            }

            return found.ToUserDataDTO();
        }

        public UserDTO GetByUsername(string username)
        {
            if (ExistsWithName(username))
            {
                return _userRepository.FindByUsername(username)
                    .ToDTO();
            }

            throw BusinessExceptions.EntityDoesNotExistsInDBException;
        }

        public bool PasswordMatches(string userPass1, string userPass2)
        {
            if (BCrypt.Net.BCrypt.Verify(userPass2, userPass1))
            {
                return true;
            }

            throw BusinessExceptions.NotAuthorizedException;
        }

        public IEnumerable<UserDTO> SearchByUsername(string username)
        {
            return _userRepository.SearchByUsername(username).ToDTOList();
        }

        public UserDTO Update(UserDTO userDTO)
        {
            User? found = _userRepository.GetById(userDTO.Id);

            if (found.Username.ToLower() == userDTO.Username.ToLower() && found.Id != userDTO.Id)
            {
                throw BusinessExceptions.EntityDoesNotExistsInDBException;
            }

            userDTO.Password = found.Password;
            userDTO.ProfileImage = found.ProfileImage;
            userDTO.CoverImage = found.CoverImage;

            User updated = _userRepository.Update(userDTO.ToEntity());
            _unitOfWork.SaveChanges();

            return updated.ToDTO();
        }

        private bool ExistsWithName(string username)
        {
            if (_userRepository.FindByUsername(username) != null)
            {
                return true;
            }
            return false;
        }
    }
}
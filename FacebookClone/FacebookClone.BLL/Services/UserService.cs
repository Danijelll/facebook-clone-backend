using FacebookClone.BLL.Constants;
using FacebookClone.BLL.DTO.Auth;
using FacebookClone.BLL.DTO.User;
using FacebookClone.BLL.Mappers;
using FacebookClone.BLL.Model;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;

namespace FacebookClone.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailConfirmService _emailConfirmService;
        private readonly ISendEmailService _sendEmailService;
        private readonly ITwoFactorAuthenticatorRepository _twoFactorAuthenticatorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IEmailConfirmService emailConfirmService, ISendEmailService sendEmailService, ITwoFactorAuthenticatorRepository twoFactorAuthenticatorRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _emailConfirmService = emailConfirmService;
            _sendEmailService = sendEmailService;
            _twoFactorAuthenticatorRepository = twoFactorAuthenticatorRepository;
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

        public IEnumerable<UserDTO> GetAll()
        {
            return _userRepository.GetAll()
                .ToDTOList();
        }

        public UserDataDTO GetById(int userId)
        {
            User found = _userRepository.GetById(userId);

            if (found == null)
            {
                throw BusinessExceptions.EntityDoesNotExistsInDBException;
            }

            if (found.IsBanned == true)
            {
                throw BusinessExceptions.UserBannedException;
            }

            return found.ToDTO().ToUserDataDTO();
        }

        public UserDataDTO GetByIdWithBanned(int userId)
        {
            User found = _userRepository.GetById(userId);

            if (found == null)
            {
                throw BusinessExceptions.EntityDoesNotExistsInDBException;
            }

            return found.ToDTO().ToUserDataDTO();
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

        public UserDTO GetByEmail(string email)
        {
            User found = _userRepository.GetByEmail(email);

            if (found == null)
            {
                throw BusinessExceptions.EntityDoesNotExistsInDBException;
            }

            return found.ToDTO();
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

        public void Generate2FACode(LoginDTO userLogin)
        {
            User found = _userRepository.FindByUsername(userLogin.Username);

            if (found == null)
            {
                throw BusinessExceptions.EntityDoesNotExistsInDBException;
            }

            PasswordMatches(found.Password, userLogin.Password);

            TwoFactorAuthenticationDTO twoFactorAuthentication = new TwoFactorAuthenticationDTO
            {
                UserEmail = found.Username,
                TwoFactorCode = Guid.NewGuid().ToString().Substring(0, 4)
            };

            _twoFactorAuthenticatorRepository.Add(twoFactorAuthentication.ToEntity());

            _unitOfWork.SaveChanges();

            _sendEmailService.Send2FACodeEmail(found.Email, found.Username, twoFactorAuthentication.TwoFactorCode);
        }

        public IEnumerable<UserDTO> SearchByUsernameWithBanned(string username)
        {
            return _userRepository.SearchByUsernameWithBanned(username).ToDTOList();
        }

        public UserDTO UpdateProfileImage(int id, string imageUrl, string webRootPath)
        {
            User? found = _userRepository.GetById(id);

            if (found == null)
            {
                throw BusinessExceptions.EntityDoesNotExistsInDBException;
            }

            DeleteImageByPath(id, found.ProfileImage, ImageConstants.UserProfileImageFolder, webRootPath);

            found.ProfileImage = imageUrl;

            User updated = _userRepository.Update(found);

            _unitOfWork.SaveChanges();

            return updated.ToDTO();
        }

        public UserDTO UpdateCoverImage(int id, string imageUrl, string webRootPath)
        {
            User? found = _userRepository.GetById(id);

            if (found == null)
            {
                throw BusinessExceptions.EntityDoesNotExistsInDBException;
            }

            DeleteImageByPath(id, found.CoverImage, ImageConstants.UserCoverImageFolder, webRootPath);

            found.CoverImage = imageUrl;

            User updated = _userRepository.Update(found);

            _unitOfWork.SaveChanges();

            return updated.ToDTO();
        }

        public UserDTO BanUserById(int id)
        {
            User? found = _userRepository.GetById(id);

            if (found == null)
            {
                throw BusinessExceptions.EntityDoesNotExistsInDBException;
            }

            found.IsBanned = true;

            User updated = _userRepository.Update(found);

            _unitOfWork.SaveChanges();

            return updated.ToDTO();
        }

        public UserDTO UnbanUserById(int id)
        {
            User? found = _userRepository.GetById(id);

            if (found == null)
            {
                throw BusinessExceptions.EntityDoesNotExistsInDBException;
            }

            found.IsBanned = false;

            User updated = _userRepository.Update(found);

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

        private void DeleteImageByPath(int userId, string imageUrl, string imageFolder, string webRootPath)
        {
            string imageWithFolder = Path.Combine(imageFolder, userId.ToString(), imageUrl);

            string path = Path.Combine(webRootPath, imageWithFolder);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
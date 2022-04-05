﻿using FacebookClone.BLL.Constants;
using FacebookClone.BLL.DTO;
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
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public UserDTO Add(UserDTO userDTO)
        {
            if (!ExistsWithName(userDTO.Username))
            {
                userDTO.Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
                User user = _userRepository.Add(userDTO.ToEntity());

                _unitOfWork.SaveChanges();
                return user.ToDTO();
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

        public UserDTO GetById(int userId)
        {
            UserDTO found = _userRepository.GetById(userId).ToDTO();

            if (found != null)
            {
                return found;
            }

            throw BusinessExceptions.EntityDoesNotExistsInDBException;
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

        public bool PasswordMatches(UserDTO userDTO, UserDTO user)
        {
            if (BCrypt.Net.BCrypt.Verify(user.Password, userDTO.Password))
            {
                return true;
            }

            throw BusinessExceptions.NotAuthorizedException;
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

        private bool ExistsWithID(int userId)
        {
            if (_userRepository.GetById(userId)?.Id == userId)
            {
                return true;
            }
            return false;
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
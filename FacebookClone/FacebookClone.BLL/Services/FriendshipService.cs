﻿using FacebookClone.BLL.DTO.Friendship;
using FacebookClone.BLL.Mappers;
using FacebookClone.BLL.Model;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;

namespace FacebookClone.BLL.Services
{
    public class FriendshipService : IFriendshipService
    {
        private readonly IFriendshipRepository _friendshipRepository;
        private readonly IFriendRequestRepository _friendRequestRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FriendshipService(IFriendshipRepository friendshipRepository, IFriendRequestRepository friendRequestRepository, IUnitOfWork unitOfWork)
        {
            _friendshipRepository = friendshipRepository;
            _friendRequestRepository = friendRequestRepository;
            _unitOfWork = unitOfWork;
        }

        private FriendshipDTO AddFriendship(FriendRequestDTO friendRequestDTO)
        {
            FriendshipDTO friendship = new FriendshipDTO
            {
                UserId = friendRequestDTO.SecondUserId,
                FriendId = friendRequestDTO.FirstUserId
            };

            if (_friendshipRepository.GetFriendshipByFirstAndSecondUserId(friendship.UserId, friendship.FriendId) == null &&
                _friendshipRepository.GetFriendshipByFirstAndSecondUserId(friendship.FriendId, friendship.UserId) == null)
            {
                _friendshipRepository.Add(friendship.ToEntity());

                friendship.UserId = friendRequestDTO.FirstUserId;
                friendship.FriendId = friendRequestDTO.SecondUserId;

                Friendship createdFriendship = _friendshipRepository.Add(friendship.ToEntity());

                _unitOfWork.SaveChanges();

                return createdFriendship.ToDTO();
            }

            throw BusinessExceptions.EntityAlreadyExistsInDBException;
        }

        public FriendRequestDTO AddFriendRequest(int currentUserId, int FriendId)
        {
            if(_friendRequestRepository.GetSentFriendRequest(currentUserId, FriendId) == null)
            {
            FriendRequestDTO friendRequest = new FriendRequestDTO();

            friendRequest.FirstUserId = currentUserId;
            friendRequest.SecondUserId = FriendId;

            FriendRequest createdFriendRequest = _friendRequestRepository.Add(friendRequest.ToEntity());

            _unitOfWork.SaveChanges();

            return createdFriendRequest.ToDTO();
            }

            throw BusinessExceptions.EntityAlreadyExistsInDBException;
        }

        public IEnumerable<FriendRequestDTO> GetAllIncomingFriendRequestsById(int userId, int pageSize, int pageNumber)
        {
            return _friendRequestRepository.GetAllIncomingFriendRequestsById(userId, pageSize, pageNumber).ToDTOList();
        }

        public FriendRequestDTO Update(int friendRequestId)
        {
            FriendRequestDTO found = _friendRequestRepository.GetById(friendRequestId).ToDTO();

            if (found != null)
            {
                found.IsAccepted = true;

                FriendRequest updated = _friendRequestRepository.Update(found.ToEntity());

                AddFriendship(updated.ToDTO());

                _unitOfWork.SaveChanges();

                return updated.ToDTO();
            }

            throw BusinessExceptions.EntityDoesNotExistsInDBException;
        }

        private bool ExistsWithID(int friendRequestId)
        {
            if (_friendRequestRepository.GetById(friendRequestId)?.Id == friendRequestId)
            {
                return true;
            }
            return false;
        }

        public void Delete(int id)
        {
            if (!ExistsWithID(id))
            {
                throw BusinessExceptions.EntityDoesNotExistsInDBException;
            }

            _friendRequestRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }
    }
}
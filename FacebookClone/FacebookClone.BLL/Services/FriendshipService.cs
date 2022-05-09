using FacebookClone.BLL.DTO.Friendship;
using FacebookClone.BLL.Enums;
using FacebookClone.BLL.Mappers;
using FacebookClone.BLL.Model;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;

namespace FacebookClone.BLL.Services
{
    public class FriendshipService : IFriendshipService
    {
        private readonly IFriendRequestRepository _friendRequestRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FriendshipService(IFriendRequestRepository friendRequestRepository, IUnitOfWork unitOfWork)
        {
            _friendRequestRepository = friendRequestRepository;
            _unitOfWork = unitOfWork;
        }

        public FriendRequestDTO AddFriendRequest(int currentUserId, int friendId)
        {
            if (_friendRequestRepository.GetSentFriendRequest(currentUserId, friendId) == null)
            {
                FriendRequestDTO friendRequest = new FriendRequestDTO();

                friendRequest.FirstUserId = currentUserId;
                friendRequest.SecondUserId = friendId;

                FriendRequest createdFriendRequest = _friendRequestRepository.Add(friendRequest.ToEntity());

                _unitOfWork.SaveChanges();

                return createdFriendRequest.ToDTO();
            }

            throw BusinessExceptions.EntityAlreadyExistsInDBException;
        }

        public void DeleteFriendRequest(int currentUserId, int FriendId)
        {
            FriendRequest found = _friendRequestRepository.GetSentFriendRequest(currentUserId, FriendId);

            if (found == null)
            {
                throw BusinessExceptions.EntityDoesNotExistsInDBException;
            }

            _friendRequestRepository.Delete(found.Id);
            _unitOfWork.SaveChanges();
            return;

            FriendRequest foundSecond = _friendRequestRepository.GetSentFriendRequest(FriendId, currentUserId);

            if (foundSecond == null)
            {
                throw BusinessExceptions.EntityDoesNotExistsInDBException;
            }

            _friendRequestRepository.Delete(foundSecond.Id);
            _unitOfWork.SaveChanges();
            return;
        }

        public Enum CheckFriendRequestStatus(int currentUserId, int friendId)
        {
            FriendRequest mySentRequest = _friendRequestRepository.GetSentFriendRequest(currentUserId, friendId);
            if (mySentRequest != null)
            {
                return mySentRequest.IsAccepted ? FriendRequestStatus.Friends : FriendRequestStatus.PendingOutgoing;
            }

            FriendRequest myReceivedRequest = _friendRequestRepository.GetSentFriendRequest(friendId, currentUserId);
            if (myReceivedRequest == null)
            {
                return FriendRequestStatus.NoRequest;
            }
            return myReceivedRequest.IsAccepted ? FriendRequestStatus.Friends : FriendRequestStatus.PendingIncoming;
        }

        public IEnumerable<FriendRequestDTO> GetAllIncomingFriendRequestsById(int userId, int pageSize, int pageNumber)
        {
            return _friendRequestRepository.GetAllIncomingFriendRequestsById(userId, pageSize, pageNumber).ToDTOList();
        }

        public FriendRequestDTO Update(int currentUserId, int friendId)
        {
            FriendRequestDTO found = _friendRequestRepository.GetSentFriendRequest(friendId, currentUserId).ToDTO();

            if (found != null)
            {
                found.IsAccepted = true;

                FriendRequest updated = _friendRequestRepository.Update(found.ToEntity());

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
using FacebookClone.BLL.DTO.Friendship;
using FacebookClone.BLL.Mappers;
using FacebookClone.BLL.Model;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Shared;

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

        public FriendRequestDTO Add(FriendRequestDTO friendRequest)
        {
            FriendRequest createdFriendRequest = _friendRequestRepository.Add(friendRequest.ToEntity());

            _unitOfWork.SaveChanges();

            return createdFriendRequest.ToDTO();
        }

        public IEnumerable<FriendRequestDTO> GetAllIncomingFriendRequestsById(int userId, int pageSize, int pageNumber)
        {
            PageFilter pageFilter = new PageFilter(pageSize, pageNumber);

            return _friendRequestRepository.GetAll(pageFilter).Where(f => f.SecondUserId == userId)
               .ToDTOList();
        }
        public FriendRequestDTO Update(FriendRequestDTO friendRequest)
        {
            if (ExistsWithID(friendRequest.Id))
            {
                FriendRequest updated = _friendRequestRepository.Update(friendRequest.ToEntity());

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
    }
}
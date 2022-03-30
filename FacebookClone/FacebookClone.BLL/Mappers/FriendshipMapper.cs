using FacebookClone.BLL.DTO;
using FacebookClone.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookClone.BLL.Mappers
{
    public static class FriendshipMapper
    {
        public static FriendshipDTO ToDTO(this Friendship friendship)
        {
            return new FriendshipDTO()
            {
                Id = friendship.Id,
                UserId = friendship.UserId,
                FriendId = friendship.FriendId,
                CreatedOn = friendship.CreatedOn,
                UpdatedOn = friendship.UpdatedOn,
            };
        }

        public static Friendship ToEntity(this FriendshipDTO friendship)
        {
            return new Friendship()
            {
                Id = friendship.Id,
                UserId = friendship.UserId,
                FriendId = friendship.FriendId,
                CreatedOn = friendship.CreatedOn,
                UpdatedOn = friendship.UpdatedOn,
            };
        }
    }
}

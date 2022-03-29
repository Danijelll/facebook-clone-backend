using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Entities.Context;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookClone.DAL.Repositories
{
    public class CommentRepository : EfCoreRepository<Comment, FacebookCloneDBContext>, ICommentRepository
    {
        public CommentRepository(FacebookCloneDBContext context) : base(context)
        {
        }

        public IEnumerable<Comment> GetAllByImageId(string imageId)
        {
            return GetAll().Where(c => c.ImageId.Equals(imageId));
        }
    }
}

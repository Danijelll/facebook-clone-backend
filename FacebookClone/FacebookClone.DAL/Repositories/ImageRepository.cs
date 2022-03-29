using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Entities.Context;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Repositories.Interface;

namespace FacebookClone.DAL.Repositories
{
    public class ImageRepository : EfCoreRepository<Image, FacebookCloneDBContext>, IImageRepository
    {
        public ImageRepository(FacebookCloneDBContext context) : base(context)
        {
        }

        public IEnumerable<Image> GetAllByAlbumId(int albumId)
        {
            return GetAll().Where(i => i.AlbumId == albumId);
        }
    }
}
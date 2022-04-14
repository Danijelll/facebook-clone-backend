using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Shared;

namespace FacebookClone.DAL.Repositories
{
    public class ImageRepository : EfCoreRepository<Image>, IImageRepository
    {
        public ImageRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Image> GetAllByAlbumId(int albumId)
        {
            return GetAll().Where(i => i.AlbumId == albumId);
        }

        public Image? GetByName(string name)
        {
            return GetAll().Find(a => a.Name == name);
        }
    }
}
using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Shared;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface IImageRepository : IRepository<Image>
    {
        IEnumerable<Image> GetAllByAlbumId(int albumId, PageFilter pageFilter);

        Image GetByName(string name);
    }
}
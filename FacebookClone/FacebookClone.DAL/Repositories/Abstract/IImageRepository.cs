using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface IImageRepository : IRepository<Image, int>
    {
        IEnumerable<Image> GetAllByAlbumId (int albumId);
    }
}

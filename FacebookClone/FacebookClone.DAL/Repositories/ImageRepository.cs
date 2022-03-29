﻿using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Entities.Context;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Repositories.Interface;

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
    }
}
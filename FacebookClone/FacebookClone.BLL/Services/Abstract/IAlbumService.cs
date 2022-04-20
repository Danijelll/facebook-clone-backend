﻿using FacebookClone.BLL.DTO.Albums;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IAlbumService
    {
        void Delete(int id);

        IEnumerable<AlbumDTO> GetAll(int pageSize, int pageNumber);

        IEnumerable<AlbumDTO> GetAllByUserId(int userId, int pageSize, int pageNumber);

        IEnumerable<AlbumWithImagesDTO> GetAllAlbumWithImagesByUserId(int userId, int pageSize, int pageNumber);

        AlbumDTO GetById(int id);

        AlbumWithImagesDTO Add(AlbumWithImagesDTO album);

        AlbumDTO Update(AlbumDTO album);
    }
}
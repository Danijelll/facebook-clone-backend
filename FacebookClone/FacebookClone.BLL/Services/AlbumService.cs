﻿using FacebookClone.BLL.DTO;
using FacebookClone.BLL.Mappers;
using FacebookClone.BLL.Model;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Shared;

namespace FacebookClone.BLL.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AlbumService(IAlbumRepository albumRepository, IUnitOfWork unitOfWork)
        {
            _albumRepository = albumRepository;
            _unitOfWork = unitOfWork;
        }

        public AlbumDTO Add(AlbumDTO album)
        {
            if (!ExistsWithName(album.Name))
            {
                Album albumResult = _albumRepository.Add(album.ToEntity());

                _unitOfWork.SaveChanges();

                return albumResult.ToDTO();
            }

            throw BusinessExceptions.EntityAlreadyExistsInDBException;
        }

        public void Delete(int id)
        {
            if (!ExistsWithID(id))
            {
                throw BusinessExceptions.EntityDoesNotExistsInDBException;
            }

            _albumRepository.Delete(id);

            _unitOfWork.SaveChanges();
        }

        public IEnumerable<AlbumDTO> GetAll(int pageSize, int pageNumber)
        {
            PageFilter pageFilter = new PageFilter(pageSize, pageNumber);

            return _albumRepository.GetAll(pageFilter)
                .ToDTOList();
        }

        public IEnumerable<AlbumDTO> GetAllByUserId(int userId, int pageSize, int pageNumber)
        {
            PageFilter pageFilter = new PageFilter(pageSize, pageNumber);

            return _albumRepository.GetAllByUserId(userId, pageFilter)
                .ToDTOList();
        }

        public AlbumDTO GetById(int id)
        {
            AlbumDTO found = _albumRepository.GetById(id).ToDTO();

            if (found != null)
            {
                return found;
            }

            throw BusinessExceptions.EntityDoesNotExistsInDBException;
        }

        public AlbumDTO Update(AlbumDTO album)
        {
            if(ExistsWithID(album.Id))
            {
                Album updated = _albumRepository.Update(album.ToEntity());

                _unitOfWork.SaveChanges();

                return updated.ToDTO();
            }

            throw BusinessExceptions.EntityDoesNotExistsInDBException;
        }

        private bool ExistsWithID(int albumId)
        {
            if (_albumRepository.GetById(albumId)?.Id == albumId)
            {
                return true;
            }
            return false;
        }

        private bool ExistsWithName(string name)
        {
            if (_albumRepository.GetByName(name) != null)
            {
                return true;
            }
            return false;
        }
    }
}
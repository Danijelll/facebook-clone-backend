using FacebookClone.BLL.DTO.Album;
using FacebookClone.BLL.DTO.Albums;
using FacebookClone.BLL.DTO.Image;
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
        private readonly IImageService _imageService;
        private readonly IUnitOfWork _unitOfWork;

        public AlbumService(IAlbumRepository albumRepository, IImageService imageService, IUnitOfWork unitOfWork)
        {
            _albumRepository = albumRepository;
            _imageService = imageService;
            _unitOfWork = unitOfWork;
        }

        public AlbumWithImagesDTO Add(AlbumWithImagesDTO dto)
        {
            AlbumDTO createdAlbum = this.Add(dto.ToBaseDTO());

            List<ImageDTO> imageList = new List<ImageDTO>();

            foreach (ImageDTO image in dto.Images)
            {
                image.AlbumId = createdAlbum.Id;

                ImageDTO createdImage = _imageService.Add(image, createdAlbum.UserId);
                imageList.Add(createdImage);
            }

            return createdAlbum.ToAlbumWithImagesDTO(imageList);
        }

        public IEnumerable<AlbumWithImagesWithUserDTO> GetAllFriendsWithAlbumsWithImages(int userId)
        {
            return _albumRepository.GetAllFriendsWithAlbumsWithImages(userId).ToAlbumWithImagesWithUserDTOList();
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

        public IEnumerable<AlbumDTO> GetAll()
        {
            return _albumRepository.GetAll()
                .ToDTOList();
        }

        public IEnumerable<AlbumDTO> GetAllByUserId(int userId, int pageSize, int pageNumber)
        {
            PageFilter pageFilter = new PageFilter(pageSize, pageNumber);

            return _albumRepository.GetAllByUserId(userId, pageFilter)
                .ToDTOList();
        }

        public IEnumerable<AlbumWithImagesDTO> GetAllAlbumWithImagesByUserId(int userId, int pageSize, int pageNumber)
        {
            PageFilter pageFilter = new PageFilter(pageSize, pageNumber);

            IEnumerable<Album> found = _albumRepository.GetAllAlbumWithImagesByUserId(userId, pageFilter);

            return found.ToAlbumWithImagesDTOList();
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
            AlbumDTO found = GetById(album.Id);

            AlbumDTO albumDto = found;

            albumDto.Caption = album.Caption;

            Album updated = _albumRepository.Update(albumDto.ToEntity());

            _unitOfWork.SaveChanges();

            return updated.ToDTO();
        }

        internal AlbumDTO Add(AlbumDTO album)
        {
            Album albumResult = _albumRepository.Add(album.ToEntity());

            _unitOfWork.SaveChanges();

            return albumResult.ToDTO();
        }

        private bool ExistsWithID(int albumId)
        {
            if (_albumRepository.GetById(albumId)?.Id == albumId)
            {
                return true;
            }
            return false;
        }
    }
}
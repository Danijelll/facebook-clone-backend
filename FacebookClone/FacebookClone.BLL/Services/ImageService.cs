using FacebookClone.BLL.Constants;
using FacebookClone.BLL.DTO;
using FacebookClone.BLL.Mappers;
using FacebookClone.BLL.Model;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Shared;

namespace FacebookClone.BLL.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ImageService(IImageRepository imageRepository, IUnitOfWork unitOfWork)
        {
            _imageRepository = imageRepository;
            _unitOfWork = unitOfWork;
        }

        public ImageDTO Add(ImageDTO imageDTO)
        {
                Image imageResult = _imageRepository.Add(imageDTO.ToEntity());

                _unitOfWork.SaveChanges();

                return imageResult.ToDTO();
        }

        public void Delete(int id, string webRootPath)
        {
            Image image = _imageRepository.GetById(id);

            if (image == null)
            {
                throw BusinessExceptions.EntityDoesNotExistsInDBException;
            }

            string imageWithFolder = Path.Combine(ImageConstants.ImageFolder ,image.AlbumId.ToString(), image.ImageUrl);

            string path = Path.Combine(webRootPath, imageWithFolder);

            if (File.Exists(path))
            {
                _imageRepository.Delete(id);

                _unitOfWork.SaveChanges();

                File.Delete(path);
            }
        }

        public IEnumerable<ImageDTO> GetAll(int pageSize, int pageNumber)
        {
            PageFilter pageFilter = new PageFilter(pageSize, pageNumber);

            return _imageRepository.GetAll(pageFilter)
                .ToDTOList();
        }

        public IEnumerable<ImageDTO> GetAllByAlbumId(int albumId, int pageSize, int pageNumber)
        {
            PageFilter pageFilter = new PageFilter(pageSize, pageNumber);

            return _imageRepository.GetAllByAlbumId(albumId, pageFilter)
                .ToDTOList();
        }

        public ImageDTO GetById(int id)
        {
            ImageDTO found = _imageRepository.GetById(id).ToDTO();

            if(found != null)
            {
                return found;
            }

            throw BusinessExceptions.EntityDoesNotExistsInDBException;
        }

        public ImageDTO Update(ImageDTO imageDTO)
        {
            if(ExistsWithID(imageDTO.Id))
            {
                Image updated = _imageRepository.Update(imageDTO.ToEntity());
                _unitOfWork.SaveChanges();

                return updated.ToDTO();
            }

            throw BusinessExceptions.EntityDoesNotExistsInDBException;
        }

        private bool ExistsWithID(int imageId)
        {
            if (_imageRepository.GetById(imageId)?.Id == imageId)
            {
                return true;
            }
            return false;
        }

        private bool ExistsWithName(string name)
        {
            if (_imageRepository.GetByName(name) != null)
            {
                return true;
            }
            return false;
        }
    }
}
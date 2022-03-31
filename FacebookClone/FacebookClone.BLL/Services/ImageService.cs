using FacebookClone.BLL.DTO;
using FacebookClone.BLL.Mappers;
using FacebookClone.BLL.Model;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;

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
            if (!ExistsWithName(imageDTO.Name))
            {
                Image imageResult = _imageRepository.Add(imageDTO.ToEntity());

                _unitOfWork.SaveChanges();

                return imageResult.ToDTO();
            }

            throw BusinessExceptions.EntityAlreadyExistsInDBEcxeption;
        }

        public void Delete(int id, string webRootPath)
        {
            Image image = _imageRepository.GetById(id);

            if (image == null)
            {
                throw BusinessExceptions.EntityDoesNotExistsInDBEcxeption;
            }

            string imageWithFolder = Path.Combine(image.AlbumId.ToString(), image.ImageUrl);

            string path = Path.Combine(webRootPath, imageWithFolder);

            if (File.Exists(path))
            {
                _imageRepository.Delete(id);

                _unitOfWork.SaveChanges();

                File.Delete(path);
            }
        }

        public IEnumerable<ImageDTO> GetAll()
        {
            return _imageRepository.GetAll()
                .ToDTOList();
        }

        public IEnumerable<ImageDTO> GetAllByAlbumId(int albumId)
        {
            return _imageRepository.GetAllByAlbumId(albumId)
                .ToDTOList();
        }

        public ImageDTO GetById(int id)
        {
            ImageDTO found = _imageRepository.GetById(id).ToDTO();

            if(found != null)
            {
                return found;
            }

            throw BusinessExceptions.EntityDoesNotExistsInDBEcxeption;
        }

        public ImageDTO Update(ImageDTO imageDTO)
        {
            Image found = _imageRepository.GetById(imageDTO.Id);

            if(found.Id == imageDTO.Id)
            {
                Image updated = _imageRepository.Update(imageDTO.ToEntity());
                _unitOfWork.SaveChanges();

                return updated.ToDTO();
            }

            throw BusinessExceptions.EntityDoesNotExistsInDBEcxeption;
        }

        private bool ExistsWithID(int imageId)
        {
            if (_imageRepository.GetById(imageId).Id == imageId)
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
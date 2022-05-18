using FacebookClone.BLL.Constants;
using FacebookClone.BLL.DTO.Image;
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

        public ImageDTO Add(ImageDTO imageDTO, int userId)
        {
            if(imageDTO == null)
            {
                throw BusinessExceptions.BadRequestException();
            }

            Image imageResult = _imageRepository.Add(imageDTO.ToEntity());

            _unitOfWork.SaveChanges();

            return imageResult.ToDTO(userId);
        }

        public void Delete(int id, string webRootPath)
        {
            Image image = _imageRepository.GetById(id);

            if (image == null)
            {
                throw BusinessExceptions.EntityDoesNotExistsInDBException;
            }

            string imageWithFolder = Path.Combine(ImageConstants.ImageFolder, image.AlbumId.ToString(), image.ImageUrl);

            string path = Path.Combine(webRootPath, imageWithFolder);

            if (File.Exists(path))
            {
                _imageRepository.Delete(id);

                _unitOfWork.SaveChanges();

                File.Delete(path);
            }
        }

        public IEnumerable<ImageDTO> GetAllByAlbumId(int albumId, int userId)
        {
            return _imageRepository.GetAllByAlbumId(albumId)
                .ToDTOList(userId);
        }
    }
}
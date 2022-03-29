using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookClone.BLL.Constants
{
    public static class ImageConstants
    {
        public static readonly string DefaultProfileImageName = "defaultProfile.png";

        public static readonly string DefaultCoverImageName = "defaultCover.png";

        public static readonly int MaxImageSize = 62914560;

        public static readonly IEnumerable<string> AllowedImageExtensions = new List<string>() { ".png", ".jpg", ".jpeg" };

        public static readonly string UserProfileImageFolder = "User/Profile";

        public static readonly string UserCoverImageFolder = "User/Cover";

        public static readonly string ImageFolder = "Images";
    }
}

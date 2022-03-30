namespace FacebookClone.BLL.Constants
{
    public static class ImageConstants
    {
        public static readonly string DefaultImageName = "default.png";

        public static readonly int MaxImageSize = 62914560;

        public static readonly IEnumerable<string> AllowedImageExtensions = new List<string>() { ".png", ".jpg", ".jpeg" };

        public static readonly string UserProfileImageFolder = "User/Profile";

        public static readonly string UserCoverImageFolder = "User/Cover";

        public static readonly string ImageFolder = "Images";
    }
}
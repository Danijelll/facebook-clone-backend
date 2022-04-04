namespace FacebookClone.DAL.Shared
{
    public class PageFilter
    {
        public PageFilter()
        {
            PageSize = 10;
            PageNumber = 0;
        }

        public PageFilter(int pageSize, int pageNumber)
        {
            if (pageSize <= 0)
            {
                pageSize = 10;
            }

            if (pageNumber <= 0)
            {
                pageNumber = 1;
            }

            PageSize = pageSize;
            PageNumber = pageNumber - 1;
        }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
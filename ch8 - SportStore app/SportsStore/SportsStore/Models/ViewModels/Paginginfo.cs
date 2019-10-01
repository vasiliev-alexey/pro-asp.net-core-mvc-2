namespace SportsStore.Models.ViewModels
{
    /// <summary>
    /// The paginginfo.
    /// </summary>
    public class PagingInfo
    {
        /// <summary>
        /// Gets or sets the totalitems.
        /// </summary>
        public int Totalitems { get; set; }

        /// <summary>
        /// Gets or sets the items per page.
        /// </summary>
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        public int CurrentPage { get; set; }
    }
}
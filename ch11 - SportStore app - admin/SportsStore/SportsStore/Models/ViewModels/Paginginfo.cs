namespace SportsStore.Models.ViewModels
{
    using System;

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

        public int TotalPages =>
            (int)Math.Ceiling((decimal)Totalitems / ItemsPerPage);
    }

}
 
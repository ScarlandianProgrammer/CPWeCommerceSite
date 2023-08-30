using CPWeCommerceSite.Controllers;

namespace CPWeCommerceSite.Models
{
    public class ProductCatalogViewModel
    {
        public ProductCatalogViewModel(List<Product> products, int lastPage, int currentPage)
        {
            Products = products;
            LastPage = lastPage;
            CurrentPage = currentPage;
        }

        public List<Product> Products { get; private set; }

        /// <summary>
        /// The last page of the catalog, calculated from
        /// the total number of products and the number
        /// of products per page.
        /// </summary>
        public int LastPage { get; private set; }

        /// <summary>
        /// The current page the user is on.
        /// </summary>
        public int CurrentPage { get; private set; }
    }
}

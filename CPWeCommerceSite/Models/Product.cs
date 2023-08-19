using System.ComponentModel.DataAnnotations;

namespace CPWeCommerceSite.Models
{
    /// <summary>
    /// Represents a product that this company sells.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The unique identifier for each product
        /// </summary>
        [Key]
        public int ProductId { get; set; }

        /// <summary>
        /// The name of a product that the company offers
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// The price of a product that the company offers.
        /// The product is discontinued if the price is null
        /// </summary>
        [Required]
        [Range(0, Double.MaxValue)]
        public double? Price { get; set; }
    }
}

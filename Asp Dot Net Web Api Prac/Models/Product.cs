using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp_Dot_Net_Web_Api_Prac.Models
{
    public class Product
    {
        [Key]
        [Column("Product_Id")]
        public int ProductId { get; set; }
        [Column("Product_Name")]
        public string? ProductName { get; set; }
        [Column("Product_Description")]
        public string? ProductDescription { get; set; }
        [Column("Product_Price")]
        public double ProductPrice { get; set; }
        [Column("Product_Image_Url")]
        public string? ProductImageUrl { get; set; }

       
    }
}

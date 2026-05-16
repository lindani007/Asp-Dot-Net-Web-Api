using System;
using System.Collections.Generic;
using System.Text;

namespace Asp_Dot_Net_Maui_Prac_Client_Two.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public string? ProductImageUrl { get; set; }
    }
}

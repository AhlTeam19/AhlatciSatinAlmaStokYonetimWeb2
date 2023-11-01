using System.ComponentModel.DataAnnotations;

namespace SatinAlmaStokYonetim.Web.Models
{
    public class ProductItem
    {
        public int Id { get; set; }
        public byte CategoryId { get; set; }
        public byte UnitId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
    }
}

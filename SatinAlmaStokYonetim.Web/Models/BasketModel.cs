namespace SatinAlmaStokYonetim.Web.Models
{
    public class BasketModel
    {
        public long UserId { get; set; }       //Sessiondan gelecek.
        public long CompanyId { get; set; }    //Sessiondan gelecek.
        // public long DepartmentId { get; set; } Yine sessiondan gelecek bu property eklenecek.
        public List<Product> Basket { get; set; }
    }

    public class Product
    {
        public long ProductId { get; set; }
        public long ProductQuantity { get; set; }
        public long ProductUnitId { get; set; }
        public long ProductUnitQuantity { get; set; }
    }
}

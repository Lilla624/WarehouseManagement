namespace WarehouseManagement.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Stock {  get; set; }
        public int SupplierId { get; set; }

        public Suppliers Suppliers { get; set; }
    }
}

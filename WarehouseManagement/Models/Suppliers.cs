namespace WarehouseManagement.Models
{
    public class Suppliers
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public ICollection<Products> Products { get; set; } = new List<Products>();
    }
}

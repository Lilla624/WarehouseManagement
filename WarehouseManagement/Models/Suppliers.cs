namespace WarehouseManagement.Models
{
    public class Suppliers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string Phone { get; set; }

        public ICollection<Products> Products { get; set; } = new List<Products>();
    }
}

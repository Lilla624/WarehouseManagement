namespace WarehouseManagement.Models
{
    public class StockMovements
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        public Products Products { get; set; }
    }
}

namespace MyApi.Models
{

    public class ProductModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
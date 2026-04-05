namespace MyApi.DTOs
{
    public class UpdateProductDto
    {
        public required string Name { get; set; }
        public int Price {get; set;}
        public bool IsAvailable {get; set;}

    }
}
namespace MyApi.DTOs
{
    public class CreateProductDto
    {
        public required string Name { get; set; }
        public int Price {get; set;}
        public bool IsAvailable {get; set;}

    }
}
namespace MyApi.DTOs
{
    public class UpdateUserDto
    {
        public required string Name { get; set; }
        public required string Email {get; set;}
        public bool IsActive {get; set;}

    }
}
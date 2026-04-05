namespace MyApi.DTOs
{
    public class CreateUserDto
    {
        public required string Name { get; set; }
        public required string Email {get; set;}
        public bool IsActive {get; set;}

    }
}
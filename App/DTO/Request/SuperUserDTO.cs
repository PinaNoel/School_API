namespace School_API.App.DTO
{
    public class SuperUserDTO : UserDTO
    {
        public required string Title { get; set; }

        public required string Speciality { get; set; }

        public required string Role { get; set; }
    }
}
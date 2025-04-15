

namespace School_API.App.DTO
{
    public class StudentRegisterDTO
    {
        public required string Name { get; set; }

        public required string SecondNames { get; set; }

        public required string Email { get; set; }

        public required string Enrollment { get; set; }

        public required string Password { get; set; }

        public required int CareerId { get; set; }
    }
}
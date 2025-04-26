

namespace School_API.App.DTO
{
    public class GroupResponseDTO
    {
        public required int Id { get; set; }
        public required string Group { get; set; }
    }

    public class PeriodResponseDTO
    {
        public required int Id { get; set; }
        public required string Period { get; set; }
    }
}
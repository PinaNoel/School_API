

namespace School_API.App.DTO
{
    public class SubjectAddDTO
    {
        public required int SemesterId { get; set; }
        public required List<string> Subjects { get; set; }
    }
}
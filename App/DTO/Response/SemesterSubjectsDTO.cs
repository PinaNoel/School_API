
namespace School_API.App.DTO
{
    public class SemesterSubjectsDTO
    {
        public required string Semester { get; set; }
        public required List<string> Subjects { get; set; }
    }
}
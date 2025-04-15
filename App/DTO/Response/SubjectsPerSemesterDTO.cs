
namespace School_API.App.DTO
{
    public class SubjectsPerSemesterDTO
    {
        public required string Semester { get; set; }
        public required List<string> Subjects { get; set; }
    }
}
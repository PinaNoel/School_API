
namespace School_API.App.DTO
{
    public class SubjectsWithId
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }


    public class SubjectsPerSemesterDTO
    {
        public required string Semester { get; set; }
        public required List<SubjectsWithId> Subjects { get; set; }
    }
}


namespace School_API.App.DTO
{
    public class SubjectDTO
    {
        public required string Semester { get; set; }
        public required int Id { get; set; }
        public required string Name { get; set; }
    }

    public class SubjectsByPeriodDTO
    {
        public required string Period { get; set; }
        public required string Curiculum { get; set; }
    }
}
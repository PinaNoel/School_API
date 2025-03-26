
namespace School_API.App.DTO
{
    public class CurriculumSubjecsDTO
    {
        public required string Curriculum { get; set; }
        public required List<SemesterSubjectsDTO> Subjects { get; set; }
    }
}
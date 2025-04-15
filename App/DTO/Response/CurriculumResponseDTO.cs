
namespace School_API.App.DTO
{
    public class CurriculumResponseDTO
    {
        public required string Curriculum { get; set; }
        public required List<SubjectsPerSemesterDTO> Subjects { get; set; }
    }
}
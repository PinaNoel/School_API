

namespace School_API.App.DTO
{
    public class CurriculumDTO{

        public required string Name { get; set; }
        public required string Career { get; set; }
        public required List<SubjectsListDTO> SubjectsList{ get; set; }
    }
}
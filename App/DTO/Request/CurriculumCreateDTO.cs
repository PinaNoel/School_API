

namespace School_API.App.DTO
{
    public class CurriculumCreateDTO{

        public required string Name { get; set; }
        
        public required int CareerId { get; set; }
        
        public required List<SubjectAddDTO> SubjectsList{ get; set; }
    }
}
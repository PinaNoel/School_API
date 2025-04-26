

namespace School_API.App.DTO
{
    public class TeacherAssignSubjectDTO
    {
        public required string Enrollment { get; set; }
        public required int SubjectId { get; set; }
        public required int GroupPeriodId { get; set; }
    }
}
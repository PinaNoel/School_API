using System;
using System.Collections.Generic;

namespace School_API.Core.Models;

public partial class CurriculumSubject
{
    public int Id { get; set; }

    public int? CurriculumId { get; set; }

    public int? SubjectId { get; set; }

    public int? SemesterId { get; set; }

    public virtual Curriculum? Curriculum { get; set; }

    public virtual Semester? Semester { get; set; }

    public virtual Subject? Subject { get; set; }
}

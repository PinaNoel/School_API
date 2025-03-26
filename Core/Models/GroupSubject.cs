using System;
using System.Collections.Generic;

namespace School_API.Core.Models;

public partial class GroupSubject
{
    public int Id { get; set; }

    public int? SubjectId { get; set; }

    public int? GradesId { get; set; }

    public int? StudentGroupId { get; set; }

    public int? TeacherId { get; set; }

    public virtual Grade? Grades { get; set; }

    public virtual StudentsGroup? StudentGroup { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual Teacher? Teacher { get; set; }
}

using System;
using System.Collections.Generic;

namespace School_API.Core.Models;

public partial class TeacherSubject
{
    public int Id { get; set; }

    public int? TeacherId { get; set; }

    public int? SubjectId { get; set; }

    public virtual ICollection<ActualPeriodSubject> ActualPeriodSubjects { get; set; } = new List<ActualPeriodSubject>();

    public virtual Subject? Subject { get; set; }

    public virtual Teacher? Teacher { get; set; }
}

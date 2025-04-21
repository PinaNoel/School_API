using System;
using System.Collections.Generic;

namespace School_API.Core.Models;

public partial class ActualPeriodSubject
{
    public int Id { get; set; }

    public int? TeacherSubjectsId { get; set; }

    public int? GroupPeriodsId { get; set; }

    public virtual GroupPeriod? GroupPeriods { get; set; }

    public virtual ICollection<StudentsGroup> StudentsGroups { get; set; } = new List<StudentsGroup>();

    public virtual TeacherSubject? TeacherSubjects { get; set; }
}

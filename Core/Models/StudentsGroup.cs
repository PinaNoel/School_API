using System;
using System.Collections.Generic;

namespace School_API.Core.Models;

public partial class StudentsGroup
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? GroupId { get; set; }

    public int? PeriodId { get; set; }

    public virtual Group? Group { get; set; }

    public virtual ICollection<GroupSubject> GroupSubjects { get; set; } = new List<GroupSubject>();

    public virtual Period? Period { get; set; }

    public virtual Student? Student { get; set; }
}

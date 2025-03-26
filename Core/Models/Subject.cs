using System;
using System.Collections.Generic;

namespace School_API.Core.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<CurriculumSubject> CurriculumSubjects { get; set; } = new List<CurriculumSubject>();

    public virtual ICollection<GroupSubject> GroupSubjects { get; set; } = new List<GroupSubject>();
}

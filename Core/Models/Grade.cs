using System;
using System.Collections.Generic;

namespace School_API.Core.Models;

public partial class Grade
{
    public int Id { get; set; }

    public decimal? Unit1 { get; set; }

    public decimal? Unit2 { get; set; }

    public decimal? Unit3 { get; set; }

    public virtual ICollection<GroupSubject> GroupSubjects { get; set; } = new List<GroupSubject>();
}

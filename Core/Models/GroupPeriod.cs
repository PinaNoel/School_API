using System;
using System.Collections.Generic;

namespace School_API.Core.Models;

public partial class GroupPeriod
{
    public int Id { get; set; }

    public int? PeriodId { get; set; }

    public int? GroupId { get; set; }

    public virtual ICollection<ActualPeriodSubject> ActualPeriodSubjects { get; set; } = new List<ActualPeriodSubject>();

    public virtual Group? Group { get; set; }

    public virtual Period? Period { get; set; }
}

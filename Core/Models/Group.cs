using System;
using System.Collections.Generic;

namespace School_API.Core.Models;

public partial class Group
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<GroupPeriod> GroupPeriods { get; set; } = new List<GroupPeriod>();
}

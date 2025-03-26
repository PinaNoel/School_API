﻿using System;
using System.Collections.Generic;

namespace School_API.Core.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Speciality { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<GroupSubject> GroupSubjects { get; set; } = new List<GroupSubject>();

    public virtual User? User { get; set; }
}

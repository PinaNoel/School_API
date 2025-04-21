using System;
using System.Collections.Generic;

namespace School_API.Core.Models;

public partial class StudentsGroup
{
    public int Id { get; set; }

    public int? GradesId { get; set; }

    public int? StudentId { get; set; }

    public int? ActualPeriodSubjectsId { get; set; }

    public virtual ActualPeriodSubject? ActualPeriodSubjects { get; set; }

    public virtual Grade? Grades { get; set; }

    public virtual Student? Student { get; set; }
}

﻿using System.ComponentModel.DataAnnotations;

namespace MultiJoinEF.Models;

public class Student
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public virtual List<Enrollment>? Enrollments { get; set; }
}

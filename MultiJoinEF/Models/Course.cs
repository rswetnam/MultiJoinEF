using System.ComponentModel.DataAnnotations;

namespace MultiJoinEF.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<Enrollment>? Enrollments { get; set; }
}

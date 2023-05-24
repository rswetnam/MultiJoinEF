namespace MultiJoinEF.Models;

public class Enrollment
{
    public int Id { get; set; }
    public string StudentId { get; set; } = string.Empty;
    public virtual Student Student { get; set; } = new Student();

    public int CourseId { get; set; }
    public virtual Course Course { get; set; } = new Course();

    public string Name { get; set; } = string.Empty;
}

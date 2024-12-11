using System;

public class Student
{
    public int StudentID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int? AdvisorID { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public Advisor Advisor { get; set; }
    public ICollection<StudentCourseSelection> CourseSelections { get; set; }
    public ICollection<Transcript> Transcripts { get; set; }
}

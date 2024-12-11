using System;

public class Course
{
    public int CourseID { get; set; }
    public string CourseCode { get; set; }
    public string CourseName { get; set; }
    public bool IsMandatory { get; set; }
    public int Credit { get; set; }
    public string Department { get; set; }
    public ICollection<StudentCourseSelection> CourseSelections { get; set; }
    public ICollection<Transcript> Transcripts { get; set; }
}

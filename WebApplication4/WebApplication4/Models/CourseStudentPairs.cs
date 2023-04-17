namespace WebApplication4.Models
{
    public class CourseStudentPairs
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }   
        public Course Course { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Data
{
    // many to many relationShip
    public class Teachers
    {
        [Key]
        public int TeacherID { get; set; }
        public string Name { get; set; }

        // public ICollection<Course> courses { get; set; }// this work for Enitiy before Core 
       
        public ICollection<Teacher_Course> Course_Relation { get; set; }

    }

    public class Course

    {
        [Key]
        public int CourseId { get; set; }
        public string Name { get; set; }

        // public ICollection<Teachers> teachers { get; set; }// this work for Enitiy before Core 
        public ICollection<Teacher_Course> Teachers_Relation { get; set; }

    }

    public class Teacher_Course
    {
        [Key]
        public int Id { get; set; }
        public int TeacherIdFK { get; set; }
        public int CourseIdFK { get; set; }

        [ForeignKey(nameof(TeacherIdFK))]
        public Teachers teachers { get; set; }

        [ForeignKey(nameof(CourseIdFK))]
        public  Course Course { get; set; }
        public  float Hours { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Data
{
    //one to maany RelationShip
    public class Student
    {
        public int Id    { get; set; }
        public string Name { get; set; }

        public StudentAddress StudentAddress { get; set; }

    }
    public class StudentAddress
    {
        public int StudentAddressId { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public int city { get; set; }
        public string State { get; set; }


        public int StudentIdPK { get; set; }


        [ForeignKey(nameof(StudentIdPK))]
        public  Student Student { get; set; }
    }



}

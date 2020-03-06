using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Data
{
    //On to many relationship 
    public class Human
    {
        public int HumanId { get; set; }
        public string Name { get; set; }
        public ICollection<Car> cars { get; set; }

    }

    public class Car
    {
        public int CarId { get; set; }
        public string Name { get; set; }
        public Human human { get; set; }
    }


}

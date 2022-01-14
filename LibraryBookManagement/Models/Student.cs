using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBookManagement.Models
{
    public class Student : User
    {

        public int Level { get; set;  }
        public string Course { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityEventsManagement
{
    public class Student : IStudent
    {
        public string Name { get; set; }

        public Student(string name)
        {
            Name = name;
        }

        public void GetNotified(Event evt)
        {
            Console.WriteLine($"{Name} get notified: Event \"{evt.Name}\" has started!");
        }

        public void GetNotified(Event evt, double daysLeft)
        {
            Console.WriteLine($"{Name} get notified: Only {daysLeft} days left until event \"{evt.Name}\"!");
        }
    }
}

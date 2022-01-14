using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityEventsManagement
{
    public class Event : IEvent
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }

        List<Student> students;

        public Event(string name, DateTime date)
        {
            Name = name;
            Date = date;
            this.students = new List<Student>();
        }

        public void NotifyDaysLeft()
        {
            int daysLeft = (int)Math.Floor((Date - DateTime.Now).TotalDays);
            foreach (Student student in students)
            {
                student.GetNotified(this, daysLeft);
            }
        }

        public void Start()
        {
            Notify();
        }

        public void Notify()
        {
            foreach (Student student in students)
            {
                student.GetNotified(this);
            }
        }

        public void Subscribe(Student student)
        {
            students.Add(student);
        }

        public void Unsubsribe(Student student)
        {
            students.Remove(student);
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Name: {Name} -- Date: {Date} -- Subscribers: {students.Count}");
        }
    }
}

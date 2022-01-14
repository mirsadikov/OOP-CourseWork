using System;

namespace UniversityEventsManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ICalendar calendar = Calendar.GetInstance;

            Event evt1 = new Event("Book Club", DateTime.Parse("01-01-2022 13:00"));
            Event evt2 = new Event("Basketball Club", DateTime.Parse("10-01-2022 19:00"));

            Student st1 = new Student("John Doe");
            Student st2 = new Student("Harry Potter");

            evt1.Subscribe(st1);
            evt1.Subscribe(st2);
            calendar.AddEvent(evt1);
            calendar.AddEvent(evt2);

            calendar.ShowEvents();

            evt1.NotifyDaysLeft();
            evt1.Start();

            Console.ReadKey();
        }
    }
}

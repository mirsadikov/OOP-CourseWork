using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityEventsManagement
{
    public sealed class Calendar : ICalendar
    {
        private static Calendar instance = null;
        private static List<Event> Events;
        public static Calendar GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Calendar();
                    Events = new List<Event>();
                }
                return instance;
            }
        }

        public void AddEvent(Event evt)
        {
            Events.Add(evt);
        }

        public void RemoveEvent(Event evt)
        {
            Events.Remove(evt);
        }

        public void ShowEvents()
        {
            Console.WriteLine("------ ALL EVENTS ------");

            foreach (Event evt in Events)
            {
                evt.DisplayDetails();
            }
            Console.WriteLine("------------------------\n");

        }
    }
}

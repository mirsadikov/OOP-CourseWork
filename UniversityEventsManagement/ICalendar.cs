using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityEventsManagement
{
    public interface ICalendar
    {
        void AddEvent(Event evt);
        void RemoveEvent(Event evt);
        void ShowEvents();
    }
}

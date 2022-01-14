using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityEventsManagement
{
    public interface IEvent
    {
        void Subscribe(Student student);
        void Unsubsribe(Student student);
        void Notify();
        void NotifyDaysLeft();
        void DisplayDetails();

    }
}

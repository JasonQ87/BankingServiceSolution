using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingServiceApp
{
    internal enum AppointmentStatus { Opened, closed }
    internal class Appointment
    {

        public Appointment(int appointmentId)
        {
            this.AppointmentID = appointmentId;
        }
        public int AppointmentID { get; private set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Purpose { get; set; }

        public AppointmentStatus Status { get; set; }

    }
}

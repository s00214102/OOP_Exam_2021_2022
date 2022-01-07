using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam_2021_2022
{
    class Member
    {
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
        public decimal Fee { get; set; }
        public enum PaymentSchedule { Annual, Biannual, monthly }
        public PaymentSchedule schedule { get; set; }

        public Member(string Name, DateTime JoinDate, decimal Fee, PaymentSchedule schedule)
        {
            this.Name = Name;
            this.JoinDate = JoinDate;
            this.Fee = Fee;
            this.schedule = schedule;
        }

        //calculate the regular charge based on payment schedule
        public decimal CalculateFees()
        {
            switch (schedule)
            {
                case (PaymentSchedule.Annual):
                    return Fee;

                case (PaymentSchedule.Biannual):
                    return Fee * 2;

                case (PaymentSchedule.monthly):
                    return Fee / 12;

                default:
                    return 0;
            }
        }

        // override ToString to print name of the member in the list box
        public override string ToString()
        {
            return $"{Name}";
        }

        // display member details
        public string DisplayDetails()
        {
            return $"{Name}\n" +
                $"Join date: {JoinDate}\n" +
                $"Basic fee: {Fee}\n" +
                $"Payment schedule: {schedule} - {CalculateFees()}\n" +
                $"Renewal date:\n" +
                $"Days to renewal: \n" +
                $"Member Type: ";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam_2021_2022
{
    public class Member
    {
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
        public decimal Fee { get; set; }
        public enum PaymentSchedule { Annual, Biannual, monthly }
        public PaymentSchedule schedule { get; set; }
        public string memberType { get; set; }

        private DateTime renewalDate
        {
            get
            {
                if (DateTime.Today.Month > JoinDate.Month)
                {
                    // next year
                    return new DateTime(DateTime.Today.Year + 1, JoinDate.Month, JoinDate.Day);
                }
                else if (DateTime.Today.Month == JoinDate.Month && DateTime.Today.Day > JoinDate.Day)
                {
                    // month is the same, has the day gone by?
                    // yes? next year
                    return new DateTime(DateTime.Today.Year + 1, JoinDate.Month, JoinDate.Day);
                }
                else
                {
                    // the day/month has not occured, there fore the next occurance is this year
                    return new DateTime(DateTime.Today.Year, JoinDate.Month, JoinDate.Day);
                }
            }
        }

        private int daysToRenewal { get { return (renewalDate - DateTime.Today).Days;} }

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public Member(string Name, DateTime JoinDate, decimal Fee, PaymentSchedule schedule, string memberType)
        {
            this.Name = Name;
            this.JoinDate = JoinDate;
            this.Fee = Fee;
            this.schedule = schedule;
            this.memberType = memberType;
        }

        //calculate the regular charge based on payment schedule
        // i interpretted biannually as once every two years fyi
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
                $"Join date: {JoinDate.ToShortDateString()}\n" +
                $"Basic fee: {Fee:C}\n" +
                $"Payment schedule: {schedule} - {CalculateFees():C}\n" +
                $"Renewal date:{renewalDate.ToShortDateString()}\n" +
                $"Days to renewal: {daysToRenewal}\n" +
                $"Member Type: {memberType}";
        }
    }
}

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

    }
}

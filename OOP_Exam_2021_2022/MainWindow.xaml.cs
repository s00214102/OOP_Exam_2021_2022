using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOP_Exam_2021_2022
{
    /// <summary>
    /// Github: https://github.com/s00214102/OOP_Exam_2021_2022
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] FirstNames = new string[] { "Marc", "John", "Joe", "Billy", "Bob", "Tom", "Drew", "Cleetus" };
        string[] SurNames = new string[] { "McCabe", "McCullagh", "Brehany", "Hart", "Burns", "Simpson", "Bob", "O'Loughlin" };
        Random rand = new Random();
        List<Member> allMembersList = new List<Member>();
        List<Member> regularsList = new List<Member>();
        List<Member> seniorsList = new List<Member>();
        List<Member> juniorsList = new List<Member>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rbAll.IsChecked = true;

            txbkMemberDetails.Text = null;

            // create 9 members with different payment schedules

            // regulars
            CreateRegularMember(Member.PaymentSchedule.Annual);
            CreateRegularMember(Member.PaymentSchedule.Biannual);
            CreateRegularMember(Member.PaymentSchedule.monthly);

            // juniors
            CreateJuniorMember(Member.PaymentSchedule.Annual);
            CreateJuniorMember(Member.PaymentSchedule.Biannual);
            CreateJuniorMember(Member.PaymentSchedule.monthly);

            //seniors
            CreateSeniorMember(Member.PaymentSchedule.Annual);
            CreateSeniorMember(Member.PaymentSchedule.Biannual);
            CreateSeniorMember(Member.PaymentSchedule.monthly);


            UpdateListBoxAllMembers();
        }

        // update the list box item source to show contents of the members list
        void UpdateListBoxAllMembers()
        {
            lbMembers.ItemsSource = null;
            lbMembers.ItemsSource = allMembersList;
        }
        void UpdateListBoxSeniorMembers()
        {
            lbMembers.ItemsSource = null;
            lbMembers.ItemsSource = seniorsList;
        }
        void UpdateListBoxJuniorMembers()
        {
            lbMembers.ItemsSource = null;
            lbMembers.ItemsSource = juniorsList;
        }
        void UpdateListBoxRegularMembers()
        {
            lbMembers.ItemsSource = null;
            lbMembers.ItemsSource = regularsList;
        }

        // create members
        void CreateSeniorMember(Member.PaymentSchedule schedule)
        {
            Member newMember = new SeniorMember(RandomName(), RandomAge(), RandomFee(), schedule, "senior");
            allMembersList.Add(newMember);
            seniorsList.Add(newMember);
        }
        void CreateJuniorMember(Member.PaymentSchedule schedule)
        {
            Member newMember = new JuniorMember(RandomName(), RandomAge(), RandomFee(), schedule, "junior");
            allMembersList.Add(newMember);
            juniorsList.Add(newMember);
        }
        void CreateRegularMember(Member.PaymentSchedule schedule)
        {
            Member newMember = new Member(RandomName(), RandomAge(), RandomFee(), schedule, "regular");
            allMembersList.Add(newMember);
            regularsList.Add(newMember);
        }

        // randomization
        string RandomName()
        {
            string firstName = FirstNames[rand.Next(0, FirstNames.Length)];
            string surName = SurNames[rand.Next(0, SurNames.Length)];
            return $"{firstName} {surName}";
        }
        DateTime RandomAge()
        {
            int age = rand.Next(12, 90);

            int randomMonth = rand.Next(1, 12);
            int randomDay = rand.Next(1, DateTime.DaysInMonth(2021, randomMonth));

            DateTime doB = new DateTime(DateTime.Today.Year - age, randomMonth, randomDay);

            return doB;
        }
        decimal RandomFee()
        {
            // i had a random number but decided to change it to a constant 500 to test the member types discounts
            return 500;
            //return rand.Next(100, 900);
        }

        // event handlers
        private void LbMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbMembers.SelectedItem != null)
            {
                Member selectedMember = lbMembers.SelectedItem as Member;
                txbkMemberDetails.Text = selectedMember.DisplayDetails();
            }
        }
        private void RbAll_Checked(object sender, RoutedEventArgs e)
        {
            UpdateListBoxAllMembers();
        }

        private void RbRegular_Checked(object sender, RoutedEventArgs e)
        {
            UpdateListBoxRegularMembers();
        }

        private void RbSenior_Checked(object sender, RoutedEventArgs e)
        {
            UpdateListBoxSeniorMembers();
        }

        private void RbJunior_Checked(object sender, RoutedEventArgs e)
        {
            UpdateListBoxJuniorMembers();
        }


    }
}

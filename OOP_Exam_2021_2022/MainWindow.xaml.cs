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
        List<Member> membersList = new List<Member>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                CreateMember();
            }

            Console.WriteLine(membersList);

            UpdateListBox();
        }
        void UpdateListBox()
        {
            lbMembers.ItemsSource = null;
            lbMembers.ItemsSource = membersList;
        }

        void CreateMember()
        {
            Member newMember = new Member(RandomName(), RandomAge(), RandomFee(), Member.PaymentSchedule.Annual);
            membersList.Add(newMember);
        }
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
            return rand.Next(100, 900);
        }
        private void LbMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void RbAll_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RbRegular_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RbSenior_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RbJunior_Checked(object sender, RoutedEventArgs e)
        {

        }


    }
}

using System.Windows;
using System.Windows.Controls;
using WpfDMS.BAL.Admin;
using WpfDMS.DAL;

namespace WpfDMS.PatientProfile
{
    /// <summary>
    /// Interaction logic for PatientProfilePage.xaml
    /// </summary>
    public partial class PatientProfilePage : Page
    {
        MainWindow mw = new MainWindow();
        Admin ad = new Admin();
        private static string patLogin = "";

        public PatientProfilePage()
        {
            InitializeComponent();

            TestList.ItemsSource = ad.GetTestsTable();
            ProfileDetails();
        }

        public static void PatLogin(string str)
        {
            patLogin = str;
        }

        private void ProfileDetails()
        {
            var list = ad.CheckLogin(patLogin);

            foreach (Patient pt in list)
            {
                NameBox.Text = pt.p_name;
                AgeBox.Text = pt.p_age.ToString();
                GenderBox.Text = pt.p_gender;
                AdressBox.Text = pt.p_adress;
                PhoneBox.Text = pt.p_phone;
                LoginBox.Text = pt.p_login;
                PassBox.Text = pt.p_password;
            }
        }

        private void OrderTest_OnClick(object sender, RoutedEventArgs e)
        {
            if (TestNameBox.Text == "" && TestPriceBox.Text == "")
            {
                MessageBox.Show("Чтобы заказать тест выберите его из списка");
            }
            else
            {
                OrderGrid.Visibility = Visibility.Visible;
            }
        }

        private void PayBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (NumBox.Text == "" || MonthBox.Text == "" || YearBox.Text == "" || CvvBox.Text == "")
            {
                MessageBox.Show("Для оплаты введите данные вашей кредитной карты");
            }
            else
            {
                MessageBox.Show("Оплата произведена успешно!");
            }

        }
    }
}

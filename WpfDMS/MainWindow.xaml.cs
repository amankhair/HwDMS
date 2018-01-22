using System;
using System.Windows;
using System.Windows.Controls;
using WpfDMS.BAL.Admin;
using WpfDMS.DAL;

namespace WpfDMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Admin ad = new Admin();
        public static Frame fr = new Frame();

        public MainWindow()
        {
            InitializeComponent();
            fr = MainFrame;
        }

        private void BtnEnter_OnClick(object sender, RoutedEventArgs e)
        {
            //fr.Source = new Uri("Administrator/AdminPanel.xaml", UriKind.RelativeOrAbsolute);
            var list = ad.CheckLogin(LoginTextBox.Text);
            string str = "";
            string str2 = "";

            string adminLog = "admin";
            string adminPass = "admin";

            foreach (Patient pt in list)
            {
                str = pt.p_login;
                str2 = pt.p_password;
            }

            if (LoginTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                MessageBox.Show("Введите данные");
            }
            //else if (LoginTextBox.Text != str || PasswordTextBox.Text != str2 || LoginTextBox.Text != adminLog || PasswordTextBox.Text != adminPass)
            //{
            //    MessageBox.Show("Данные не верны!");
            //}
            else if (LoginTextBox.Text == str && PasswordTextBox.Text == str2)
            {
                MessageBox.Show("Приветствую!");
                fr.Source = new Uri("/PatientProfile/PatientProfilePage.xaml", UriKind.RelativeOrAbsolute);
                PatientProfile.PatientProfilePage.PatLogin(Login());
                LogRegPanel.Visibility = Visibility.Hidden;
                ExitBtn.Visibility = Visibility.Visible;
            }
            else if (LoginTextBox.Text == adminLog && PasswordTextBox.Text == adminPass)
            {
                MessageBox.Show("Добро пожаловать, Админ!");
                fr.Source = new Uri("Administrator/AdminPanel.xaml", UriKind.RelativeOrAbsolute);
                LogRegPanel.Visibility = Visibility.Hidden;
                ExitBtn.Visibility = Visibility.Visible;
                AdminBtn.Visibility = Visibility.Visible;
            }
        }

        private void BtnRegistration_OnClick(object sender, RoutedEventArgs e)
        {
            fr.Source = new Uri("Registration/RegistrationForm.xaml", UriKind.RelativeOrAbsolute);
        }

        public static void PatientProfilePage()
        {
            fr.Source = new Uri("/PatientProfile/PatientProfilePage.xaml", UriKind.RelativeOrAbsolute);
        }

        public string Login()
        {
            string login = LoginTextBox.Text;
            return login;
        }

        private void ExitBtn_OnClick(object sender, RoutedEventArgs e)
        {
            LoginTextBox.Text = null;
            PasswordTextBox.Text = null;
            LogRegPanel.Visibility = Visibility.Visible;
            ExitPanel.Visibility = Visibility.Hidden;
        }

        private void AdminBtn_OnClick(object sender, RoutedEventArgs e)
        {
            fr.Source = new Uri("Administrator/AdminPanel.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}

using System;
using System.Windows;
using System.Windows.Controls;
using WpfDMS.BAL.Admin;
using WpfDMS.DAL;
using WpfDMS.PatientProfile;

namespace WpfDMS.Registration
{
    /// <summary>
    /// Interaction logic for RegistrationForm.xaml
    /// </summary>
    public partial class RegistrationForm : Page
    {
        Admin ad = new Admin();
        static MainWindow mw = new MainWindow();
        PatientProfilePage pf = new PatientProfilePage();

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void BtnConfirm_OnClick(object sender, RoutedEventArgs e)
        {
            string gender = Gender();
            string password = CheckPassword();

            if (NameBox.Text == "" || AgeBox.Text == "" || AdressBox.Text == "" || PhoneBox.Text == ""
                || LoginBox.Text == "" || PassBox1.Text == "" || PassBox2.Text == ""
                || (MaleRadBtn.IsChecked == false && FemaleRadBtn.IsChecked == false))
            {
                MessageBox.Show("Не все поля заполнены.");
            }
            else if (PassBox1.Text != PassBox2.Text)
            {
                MessageBox.Show("Пароли не совпадают.");
            }
            else
            {
                Patient pt = new Patient();

                pt.p_name = NameBox.Text;
                pt.p_age = int.Parse(AgeBox.Text);
                pt.p_gender = gender;
                pt.p_login = LoginBox.Text;
                pt.p_password = password;
                pt.p_adress = AdressBox.Text;
                pt.p_phone = PhoneBox.Text;

                try
                {
                    ad.AddNewPatient(pt);
                    PatientProfilePage.PatLogin(pt.p_login);
                    MessageBox.Show("Регистрация пошла успешно.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ClearRegForm();

                    RegFromFrame.Source = new Uri("/PatientProfile/PatientProfilePage.xaml", UriKind.RelativeOrAbsolute);
                }
            }

        }

        private string CheckPassword()
        {
            string pass = "";

            if (PassBox1.Text == PassBox2.Text)
                pass = PassBox1.Text;

            return pass;
        }

        private string Gender()
        {
            string gender = "";

            if (MaleRadBtn.IsChecked == true)
            {
                gender = "Мужчина";
            }
            else if (FemaleRadBtn.IsChecked == true)
            {
                gender = "Женщина";
            }

            return gender;
        }

        private void ClearRegForm()
        {
            NameBox.Clear();
            AgeBox.Clear();
            AdressBox.Clear();
            PhoneBox.Clear();
            LoginBox.Clear();
            PassBox1.Clear();
            PassBox2.Clear();
            MaleRadBtn.IsChecked = false;
            MaleRadBtn.IsChecked = false;
        }
    }
}

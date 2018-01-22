using System;
using System.Windows;
using System.Windows.Controls;
using WpfDMS.BAL.Admin;
using WpfDMS.DAL;

namespace WpfDMS.View
{
    /// <summary>
    /// Interaction logic for PatientTable.xaml
    /// </summary>
    public partial class PatientTable : Page
    {
        Admin ad = new Admin();

        public PatientTable()
        {
            InitializeComponent();
            PatientList.ItemsSource = ad.GetPatientsTable();
        }

        private void AddPatient_OnClick(object sender, RoutedEventArgs e)
        {
            if (PatNameBox.Text == "" || PatAgeBox.Text == "" || PatGenBox.Text == ""
                || PatGenBox.Text == "" || PatAdressBox.Text == "" || PatPhoneBox.Text == ""
                || PatLoginBox.Text == "" || PatPassBox.Text == "")
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                Patient pt = new Patient();
                pt.p_name = PatNameBox.Text;
                pt.p_age = int.Parse(PatAgeBox.Text);
                pt.p_gender = PatGenBox.Text;
                pt.p_adress = PatAdressBox.Text;
                pt.p_phone = PatPhoneBox.Text;
                pt.p_login = PatLoginBox.Text;
                pt.p_password = PatPassBox.Text;

                try
                {
                    ad.AddNewPatient(pt);
                    MessageBox.Show("Пациент успешно добавлен");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ClearPatientBox();
                    PatientList.ItemsSource = ad.GetPatientsTable();
                }
            }
        }

        private void DeletePatient_OnClick(object sender, RoutedEventArgs e)
        {
            int id = GetId();

            if (PatNameBox.Text == "" || PatAgeBox.Text == "" || PatGenBox.Text == ""
                || PatGenBox.Text == "" || PatAdressBox.Text == "" || PatPhoneBox.Text == ""
                || PatLoginBox.Text == "" || PatPassBox.Text == "")
            {
                MessageBox.Show("Выберите пациента чтобы удалить его из списка");
            }
            else
            {
                var list = ad.FindPatient(PatNameBox.Text);

                try
                {
                    foreach (Patient pt in list)
                    {
                        if (pt.p_name == PatNameBox.Text && pt.p_id == id)
                            ad.DeletePatient(pt);
                    }
                    MessageBox.Show("Пациент из списка успешно удален");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ClearPatientBox();
                    PatientList.ItemsSource = ad.GetPatientsTable();
                }
            }
        }

        private void UpdateBtn_OnClick(object sender, RoutedEventArgs e)
        {
            PatientList.ItemsSource = ad.GetPatientsTable();
        }

        private void ClearPatientBox()
        {
            PatNameBox.Clear();
            PatAgeBox.Clear();
            PatGenBox.Clear();
            PatAdressBox.Clear();
            PatPhoneBox.Clear();
            PatLoginBox.Clear();
            PatPassBox.Clear();
        }

        private int GetId()
        {
            int id = 0;
            var list = ad.GetPatientsTable();

            foreach (Patient pt in list)
            {
                if (pt.p_name == PatNameBox.Text && pt.p_login == PatLoginBox.Text)
                {
                    id = pt.p_id;
                }
            }
            return id;
        }
    }
}

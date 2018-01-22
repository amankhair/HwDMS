using System;
using System.Windows;
using System.Windows.Controls;
using WpfDMS.BAL.Admin;
using WpfDMS.DAL;

namespace WpfDMS.View
{
    /// <summary>
    /// Interaction logic for DoctorTable.xaml
    /// </summary>
    public partial class DoctorTable : Page
    {
        Admin ad = new Admin();

        public DoctorTable()
        {
            InitializeComponent();
            DoctorList.ItemsSource = ad.GetDoctorsTable();
        }

        private void AddDoctor_OnClick(object sender, RoutedEventArgs e)
        {
            if (DocNameBox.Text == "" || DocAgeBox.Text == "" || DocGenBox.Text == ""
                || DocGenBox.Text == "" || DocAdressBox.Text == "" || DocPhoneBox.Text == ""
                || DocLoginBox.Text == "" || DocPassBox.Text == "")
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                Doctor doc = new Doctor();
                doc.d_name = DocNameBox.Text;
                doc.d_age = int.Parse(DocAgeBox.Text);
                doc.d_gender = DocGenBox.Text;
                doc.d_adress = DocAdressBox.Text;
                doc.d_phone = DocPhoneBox.Text;
                doc.d_login = DocLoginBox.Text;
                doc.d_password = DocPassBox.Text;

                try
                {
                    ad.AddNewDoctor(doc);
                    MessageBox.Show("Доктор успешно добавлен");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ClearDocBox();
                }
            }
        }

        private void DeletePatient_OnClick(object sender, RoutedEventArgs e)
        {
            int id = GetId();

            if (DocNameBox.Text == "" || DocAgeBox.Text == "" || DocGenBox.Text == ""
                || DocGenBox.Text == "" || DocAdressBox.Text == "" || DocPhoneBox.Text == ""
                || DocLoginBox.Text == "" || DocPassBox.Text == "")
            {
                MessageBox.Show("Выберите сотрудника чтобы удалить его из списка");
            }
            else
            {
                var list = ad.FindDoctor(DocNameBox.Text);

                try
                {
                    foreach (Doctor doc in list)
                    {
                        if (doc.d_name == DocNameBox.Text && doc.d_id == id)
                            ad.DeleteDoctor(doc);
                    }
                    MessageBox.Show("Сотрудник из списка успешно удален");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ClearDocBox();
                }
            }
        }

        private void ClearDocBox()
        {
            DocNameBox.Clear();
            DocAgeBox.Clear();
            DocGenBox.Clear();
            DocAdressBox.Clear();
            DocPhoneBox.Clear();
            DocLoginBox.Clear();
            DocPassBox.Clear();
        }

        private int GetId()
        {
            int id = 0;
            var list = ad.GetDoctorsTable();

            foreach (Doctor doc in list)
            {
                if (doc.d_name == DocNameBox.Text && doc.d_login == DocLoginBox.Text)
                {
                    id = doc.d_id;
                }
            }
            return id;
        }

        private void DeleteDoctor_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void UpdateBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }

}

using System;
using System.Windows;
using System.Windows.Controls;
using WpfDMS.BAL.Admin;
using WpfDMS.DAL;

namespace WpfDMS.View
{
    /// <summary>
    /// Interaction logic for LaboratoryTable.xaml
    /// </summary>
    public partial class LaboratoryTable : Page
    {
        Admin ad = new Admin();

        public LaboratoryTable()
        {
            InitializeComponent();

            LaboratoryList.ItemsSource = ad.GetLaboratoryTable();
        }

        private void AddLaboratory_OnClick(object sender, RoutedEventArgs e)
        {
            var list = ad.GetLaboratoryTable();

            if (LabNameBox.Text == "" || LabAdressBox.Text == "" || LabPhoneBox.Text == ""
                                        || LabTimingsBox.Text == "" || LabTestBox.Text == "")
            {
                MessageBox.Show("Не все поля заполнены.");
            }
            else
            {
                Laboratory lb = new Laboratory();

                lb.lab_name = LabNameBox.Text;
                lb.lab_adress = LabAdressBox.Text;
                lb.lab_phone = LabPhoneBox.Text;
                lb.lab_timings = LabTimingsBox.Text;
                lb.lab_tests = LabTestBox.Text;

                try
                {
                    ad.AddLaboratory(lb);
                    MessageBox.Show("Лаборатория успешно добавлена.");
                    LaboratoryList.ItemsSource = ad.GetLaboratoryTable();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DeleteLaboratory_OnClick(object sender, RoutedEventArgs e)
        {
            int id = GetId();
            var testList = ad.GetTestsTable();

            if (LabNameBox.Text == "" || LabAdressBox.Text == "" || LabPhoneBox.Text == ""
                || LabTimingsBox.Text == "" || LabTestBox.Text == "")
            {
                MessageBox.Show("Чтобы удалить \nвыберите лаборатрию.");
            }
            else
            {
                var list = ad.FindLaboratory(LabNameBox.Text);

                try
                {
                    foreach (Laboratory lb in list)
                    {
                        if (lb.lab_name == LabNameBox.Text && lb.lab_id == id)

                            foreach (Test tt in testList)
                            {
                                if (tt.t_lab_id == lb.lab_id)
                                    ad.DeleteTest(tt);
                            }
                        ad.DeleteLaboratory(lb);
                    }
                    MessageBox.Show("Лаборатория успешно удалена.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    LabNameBox.Text = "";
                    LabAdressBox.Text = "";
                    LabPhoneBox.Text = "";
                    LabTimingsBox.Text = "";
                    LabTestBox.Text = "";
                    LaboratoryList.ItemsSource = ad.GetLaboratoryTable();
                }
            }
        }

        private void UpdateBtn_OnClick(object sender, RoutedEventArgs e)
        {
            LabNameBox.Text = "";
            LabAdressBox.Text = "";
            LabPhoneBox.Text = "";
            LabTimingsBox.Text = "";
            LabTestBox.Text = "";
            LaboratoryList.ItemsSource = ad.GetLaboratoryTable();
        }

        public int GetId()
        {
            int id = 0;
            var list = ad.GetLaboratoryTable();

            foreach (Laboratory lb in list)
            {
                if (lb.lab_name == LabNameBox.Text)
                {
                    id = lb.lab_id;
                }
            }
            return id;
        }
    }
}

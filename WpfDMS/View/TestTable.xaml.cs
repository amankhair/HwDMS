using System;
using System.Windows;
using System.Windows.Controls;
using WpfDMS.BAL.Admin;
using WpfDMS.DAL;

namespace WpfDMS.View
{
    /// <summary>
    /// Interaction logic for TestTable.xaml
    /// </summary>
    public partial class TestTable : Page
    {
        Admin ad = new Admin();
        Laboratory lb = new Laboratory();

        public TestTable()
        {
            InitializeComponent();
            TestList.ItemsSource = ad.GetTestsTable();
        }

        private void AddTest_OnClick(object sender, RoutedEventArgs e)
        {
            var list = ad.GetLaboratoryTable();

            if (TestNameBox.Text == "" || TestPriceBox.Text == "")
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                Test ts = new Test();
                ts.t_name = TestNameBox.Text;
                ts.t_price = int.Parse(TestPriceBox.Text);

                foreach (Laboratory ll in list)
                {
                    if (ll.lab_tests == TestNameBox.Text)
                    {
                        ts.t_lab_id = ll.lab_id;
                    }
                }

                try
                {
                    ad.AddNewTest(ts);
                    MessageBox.Show("Тест успешно добавлен");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ClearTestBox();
                    TestList.ItemsSource = ad.GetTestsTable();
                }
            }
        }

        private void DeleteTest_OnClick(object sender, RoutedEventArgs e)
        {
            if (TestNameBox.Text == "" || TestPriceBox.Text == "")
            {
                MessageBox.Show("Чтобы удалиьт тест выберите его из спичка");
            }
            else
            {
                var list = ad.FindTest(TestNameBox.Text);

                try
                {
                    foreach (Test tt in list)
                    {
                        if (tt.t_name == TestNameBox.Text) ;
                        ad.DeleteTest(tt);
                    }
                    MessageBox.Show("Тест успешно удален");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ClearTestBox();
                    TestList.ItemsSource = ad.GetTestsTable();
                }
            }
        }

        private void UpdateBtn_OnClick(object sender, RoutedEventArgs e)
        {
            TestList.ItemsSource = ad.GetTestsTable();
        }

        private void ClearTestBox()
        {
            TestNameBox.Clear();
            TestPriceBox.Clear();
            TestList.ItemsSource = ad.GetTestsTable();
        }
    }
}

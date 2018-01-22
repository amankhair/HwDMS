using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfDMS.Administrator
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Page
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void PrintLaboratoryTable_OnClick(object sender, RoutedEventArgs e)
        {
            AdminFrame.Source = new Uri("/View/LaboratoryTable.xaml", UriKind.RelativeOrAbsolute);
        }

        private void PrintTestsTable_OnClick(object sender, RoutedEventArgs e)
        {
            AdminFrame.Source = new Uri("/View/TestTable.xaml", UriKind.RelativeOrAbsolute);
        }

        private void PrintDoctorTable_OnClick(object sender, RoutedEventArgs e)
        {
            AdminFrame.Source = new Uri("/View/DoctorTable.xaml", UriKind.RelativeOrAbsolute);
        }

        private void PrintPatientTable_OnClick(object sender, RoutedEventArgs e)
        {
            AdminFrame.Source = new Uri("/View/PatientTable.xaml", UriKind.RelativeOrAbsolute);
        }

        private void PrintBillTable_OnClick(object sender, RoutedEventArgs e)
        {
            AdminFrame.Source = new Uri("/View/BillTable.xaml", UriKind.RelativeOrAbsolute);
        }

    }
}

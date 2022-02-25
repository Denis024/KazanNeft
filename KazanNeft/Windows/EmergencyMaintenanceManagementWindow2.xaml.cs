using KazanNeft.Model;
using System.Linq;
using System.Windows;

namespace KazanNeft.Windows
{
    public partial class EmergencyMaintenanceManagementWindow2 : Window
    {
        public EmergencyMaintenanceManagementWindow2()
        {
            InitializeComponent();
            DataGridAssets2.ItemsSource = IgishevKazanNeft2Entities.GetContext().EmergencyMaintenances.ToList();
        }

        private void BtnRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBlockID.DataContext = DataGridAssets2.SelectedItem;
                EmergencyMaintenances test = IgishevKazanNeft2Entities.GetContext().EmergencyMaintenances.Find(int.Parse(TextBlockID.Text));
                EmergencyMaintenanceRequestDetailsWindow emergencyMaintenanceRequestDetailsWindow = new EmergencyMaintenanceRequestDetailsWindow(int.Parse(TextBlockID.Text));
                emergencyMaintenanceRequestDetailsWindow.Show();
            }
            catch
            {
                MessageBox.Show("Выберите");
            }
        }
    }
}

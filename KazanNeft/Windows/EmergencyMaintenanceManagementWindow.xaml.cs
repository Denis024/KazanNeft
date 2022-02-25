using KazanNeft.Model;
using System.Linq;
using System.Windows;

namespace KazanNeft.Windows
{
    public partial class EmergencyMaintenanceManagementWindow : Window
    {

        public EmergencyMaintenanceManagementWindow()
        {
            InitializeComponent();
            DataGridAssets.ItemsSource = IgishevKazanNeft2Entities.GetContext().Assets.ToList();
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBlockID.DataContext = DataGridAssets.SelectedItem;
                Assets test = IgishevKazanNeft2Entities.GetContext().Assets.Find(int.Parse(TextBlockID.Text));
                EmergencyMaintenanceRequestWindow emergencyMaintenanceRequest = new EmergencyMaintenanceRequestWindow(int.Parse(TextBlockID.Text));
                emergencyMaintenanceRequest.Show();
            }
            catch
            {
                MessageBox.Show("Выберите");
            }
        }
    }
}

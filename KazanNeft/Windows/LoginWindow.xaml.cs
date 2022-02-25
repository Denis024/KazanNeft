using KazanNeft.Model;
using System.Linq;
using System.Windows;

namespace KazanNeft.Windows
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Выход",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                return;
            Close();
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text;
            string password = TextBoxPassword.Password;

            EmergencyMaintenanceManagementWindow emergencyMaintenanceManagementWindow = new EmergencyMaintenanceManagementWindow();
            EmergencyMaintenanceManagementWindow2 emergencyMaintenanceManagementWindow2 = new EmergencyMaintenanceManagementWindow2();

            Employees AuthEmployees = null;

            using (IgishevKazanNeft2Entities db = new IgishevKazanNeft2Entities())
            {
                AuthEmployees = db.Employees.Where(b => b.Username == login && b.Password == password).FirstOrDefault();
            }

            if (AuthEmployees != null)
                if (AuthEmployees.isAdmin == true)
                {
                    emergencyMaintenanceManagementWindow.Show();
                }
                else
                if (AuthEmployees.isAdmin == false)
                {
                    emergencyMaintenanceManagementWindow2.Show();
                }
            else
            {
                MessageBox.Show("Проверьте правильность введенных данных", "Уведомление",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

using KazanNeft.Model;
using System;
using System.Linq;
using System.Text;
using System.Windows;

namespace KazanNeft.Windows
{
    public partial class EmergencyMaintenanceRequestWindow : Window
    {
        private Assets MyAssets = new Assets();

        public EmergencyMaintenanceRequestWindow(int id)
        {
            InitializeComponent();

            ComboBoxPrioritet.ItemsSource = IgishevKazanNeft2Entities.GetContext().Priorities.ToList();

            Assets currentAssets = IgishevKazanNeft2Entities.GetContext().Assets.Find(id);

            if (currentAssets != null)
            {
                MyAssets = currentAssets;
            }

            DataContext = MyAssets;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            DateTime now = DateTime.Now;

            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            EmergencyMaintenances order = new EmergencyMaintenances
            {
                AssetID = MyAssets.ID,
                PriorityID = ComboBoxPrioritet.SelectedIndex + 1,
                DescriptionEmergency = TextBoxDescriptionEmergency.Text,
                OtherConsiderations = TextBoxOtherConsiderations.Text,
                EMReportDate = now
            };

            if (order.ID == 0)
                IgishevKazanNeft2Entities.GetContext().EmergencyMaintenances.Add(order);

            try
            {
                IgishevKazanNeft2Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Выход",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                return;
            Close();
        }
    }
}

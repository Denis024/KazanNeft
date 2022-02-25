using KazanNeft.Model;
using System;
using System.Linq;
using System.Text;
using System.Windows;

namespace KazanNeft.Windows
{
    public partial class EmergencyMaintenanceRequestDetailsWindow : Window
    {
        private EmergencyMaintenances MyTest = new EmergencyMaintenances();

        public EmergencyMaintenanceRequestDetailsWindow(int id)
        {
            InitializeComponent();

            ComboBoxParts.ItemsSource = IgishevKazanNeft2Entities.GetContext().Parts.ToList();

            EmergencyMaintenances current = IgishevKazanNeft2Entities.GetContext().EmergencyMaintenances.Find(id);

            if (current != null)
            {
                MyTest = current;
            }

            DataContext = MyTest;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            ChangedParts order = new ChangedParts
            {
                EmergencyMaintenanceID = MyTest.ID,
                PartID = 3,
                Amount = Convert.ToInt32(TextBoxAmount.Text)
            };


            if (MyTest.ID == 0)
                IgishevKazanNeft2Entities.GetContext().EmergencyMaintenances.Add(MyTest);

            if (order.ID == 0)
                IgishevKazanNeft2Entities.GetContext().ChangedParts.Add(order);

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

        private void BtnAddToList_Click(object sender, RoutedEventArgs e)
        {
            DataGridDetails.Items.Add(new
            {
                NameParts = ComboBoxParts.Text,
                Amount = TextBoxAmount.Text                
            });
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            DataGridDetails.Items.RemoveAt(DataGridDetails.SelectedIndex);
        }
    }
}
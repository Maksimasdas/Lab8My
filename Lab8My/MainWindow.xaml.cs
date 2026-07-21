using Lab8My.Models;
using System.Data.Entity;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab8My
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EntityContext context;
        public MainWindow()
        {
            InitializeComponent();
            context = new EntityContext();
            context.Cars.Load();//загружаем данные из базы
            dGrid.ItemsSource = context.Cars.Local.ToBindingList(); //привязка датагрида
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Car car = new Car();
            WindowEdit windowEdit = new WindowEdit(car);
            if (windowEdit.ShowDialog() == false) return;

            var newCar = windowEdit.EditedCar;
            context.Cars.Add(newCar);
            context.SaveChanges();
            windowEdit.Close();
        }

        private void btnDeleete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Удаление записей", MessageBoxButton.YesNo, MessageBoxImage.Question)
            == MessageBoxResult.Yes)
            {
                if (dGrid.SelectedItems.Count == 0) return;
                for(int i = dGrid.SelectedItems.Count - 1; i >= 0; i--)
                {
                    Car car = dGrid.SelectedItems[i] as Car;
                    if(car != null)
                    {
                        context.Cars.Remove(car);
                    }
                }
                context.SaveChanges();
            }

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(dGrid.SelectedItems.Count != 1)
            {
                MessageBox.Show("Выберите один автоомбиль");
            }
            Car car = dGrid.SelectedItem as Car;
            if (car == null) return;
            WindowEdit windowEdit = new WindowEdit(car);

            var editedCar = windowEdit.EditedCar;

            car.Name = editedCar.Name;
            car.Model = editedCar.Model;
            car.Vin = editedCar.Vin;
            car.Number = editedCar.Number;
            car.CarId = editedCar.CarId;

            context.Entry(car).State = EntityState.Modified;
            context.SaveChanges();
            dGrid.Items.Refresh();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            context.Dispose();
        }
        private void dGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}
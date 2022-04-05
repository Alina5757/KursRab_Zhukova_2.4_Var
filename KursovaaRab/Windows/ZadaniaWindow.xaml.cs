using KursContracts.BindingModels;
using KursContracts.BusinessLogicInterfases;
using KursContracts.ViewModels;
using System;
using System.Windows;
using Unity;

namespace KursovaaRab.Windows
{
    /// <summary>
    /// Логика взаимодействия для ZadaniaWindow.xaml
    /// </summary>
    public partial class ZadaniaWindow : Window
    {
        private readonly ITaskLogic _logic;
       
        public ZadaniaWindow(ITaskLogic logic)
        {
            InitializeComponent();
            _logic = logic;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _logic.Read(null);
                if (list != null)
                {
                    DataGridView.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var form = Programm.Container.Resolve<ChangeZadanieWindow>();
            form.ShowDialog();
            LoadData();
        }

        private void ButtonRender_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridView.SelectedItems.Count == 1)
            {
                var form = Programm.Container.Resolve<ChangeZadanieWindow>();
                form.Id = Convert.ToInt32(((TaskViewModel)DataGridView.SelectedItem).Id);
                form.ShowDialog();
                if (form.DialogResult == true)
                {
                    LoadData();
                }
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridView.SelectedItems.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int id = Convert.ToInt32(((TaskViewModel)DataGridView.SelectedItem).Id);
                    try
                    {
                        _logic.Delete(new TaskBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LoadData();
                }
            }
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}

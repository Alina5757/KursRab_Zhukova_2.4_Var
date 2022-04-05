using KursContracts.BindingModels;
using KursContracts.BusinessLogicInterfases;
using KursContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Unity;

namespace KursovaaRab.Windows
{
    /// <summary>
    /// Логика взаимодействия для ZanatiaWindow.xaml
    /// </summary>
    public partial class ZanatiaWindow : Window
    {
        private readonly IClassLogic _logic;

        public ZanatiaWindow(IClassLogic logic)
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
            var form = Programm.Container.Resolve<ChangeZanatieWindow>();
            form.ShowDialog();
            LoadData();
        }

        private void ButtonRender_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridView.SelectedItems.Count == 1)
            {
                var form = Programm.Container.Resolve<ChangeZanatieWindow>();
                form.Id = Convert.ToInt32(((ClassViewModel)DataGridView.SelectedItem).Id);
                form.ShowDialog();
                LoadData();
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridView.SelectedItems.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int id = Convert.ToInt32(((ClassViewModel)DataGridView.SelectedItem).Id);
                    try
                    {
                        _logic.Delete(new ClassBindingModel { Id = id });
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

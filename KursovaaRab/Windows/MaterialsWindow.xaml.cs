using KursContracts.BindingModels;
using KursContracts.BusinessLogicInterfases;
using KursContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using Unity;

namespace KursovaaRab.Windows
{
    /// <summary>
    /// Логика взаимодействия для MaterialsWindow.xaml
    /// </summary>
    public partial class MaterialsWindow : Window
    {
        private readonly IMaterialLogic _logic;

        public MaterialsWindow(IMaterialLogic logic)
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
            var form = Programm.Container.Resolve<ChangeMaterialWindow>();
            form.ShowDialog();
            LoadData();
        }

        private void ButtonRender_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridView.SelectedItems.Count == 1)
            {
                var form = Programm.Container.Resolve<ChangeMaterialWindow>();
                form.Id = Convert.ToInt32(((MaterialViewModel)DataGridView.SelectedItem).Id);
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
                    int id = Convert.ToInt32(((MaterialViewModel)DataGridView.SelectedItem).Id);
                    try
                    {
                        _logic.Delete(new MaterialBindingModel { Id = id });
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

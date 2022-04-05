using KursContracts.BindingModels;
using KursContracts.BusinessLogicInterfases;
using KursContracts.ViewModels;
using KursModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Unity;

namespace KursovaaRab.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChangeZadanieWindow.xaml
    /// </summary>
    public partial class ChangeZadanieWindow : Window
    {
        private readonly ITaskLogic _taskLogic;
        private int? id;
        public int Id { set { id = value; } }
        private Dictionary<int, (string, int)> materials;

        public ChangeZadanieWindow(ITaskLogic taskLogic)
        {
            InitializeComponent();
            _taskLogic = taskLogic;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TextBoxName.Text))
                {
                    MessageBox.Show("Заполните поле Название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (string.IsNullOrEmpty(DatePickerStart.Text))
                {
                    MessageBox.Show("Заполните поле Дата Выдачи задания", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (string.IsNullOrEmpty(DatePickerPass.Text))
                {
                    MessageBox.Show("Заполните поле Дата сдачи задания", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (materials == null || materials.Count == 0)
                {
                    MessageBox.Show("Выберите обязательный материал", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                using var context = new KursDataBase();
                _taskLogic.CreateOrUpdate(new TaskBindingModel
                {
                    Name = TextBoxName.Text,
                    DateCreate = Convert.ToDateTime(DatePickerStart.Text),
                    DateComplete = Convert.ToDateTime(DatePickerPass.Text),
                    TeacherId = MainWindow.CurrentTeacherId,
                    Materials = materials,
                    Id = id > 0 ? id : null
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            DialogResult = true;
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = _taskLogic.Read(new TaskBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        TextBoxName.Text = view.Name;
                        DatePickerStart.Text = Convert.ToString(view.DateCreate);
                        DatePickerPass.Text = Convert.ToString(view.DateComplete);
                        materials = view.Materials;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                materials = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (materials != null)
                {
                    DataGridView.ItemsSource = materials;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var form = Programm.Container.Resolve<MaterialAddWindow>();

            if (form.ShowDialog() == true)
            {
                if (materials.ContainsKey(form.Id))
                {
                    materials[form.Id] = (form.MaterialName, form.Count);
                }
                else
                {
                    materials.Add(form.Id, (form.MaterialName, form.Count));
                }
                LoadData();
            }
        }

        private void ButtonRender_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridView.SelectedItems.Count == 1)
            {
                var form = Programm.Container.Resolve<MaterialAddWindow>();
                int id = Convert.ToInt32(((MaterialViewModel)DataGridView.SelectedItems).Id);
                form.Id = id;
                form.Count = materials[id].Item2;

                if(form.ShowDialog() == true)
                {
                    materials[form.Id] = (form.MaterialName, form.Count);
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
                    try
                    {
                        materials.Remove(Convert.ToInt32(((MaterialViewModel)DataGridView.SelectedItems).Id));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LoadData();
                }
            }
        }
    }
}
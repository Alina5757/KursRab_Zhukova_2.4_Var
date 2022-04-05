using KursContracts.BindingModels;
using KursContracts.BusinessLogicInterfases;
using System;
using System.Windows;

namespace KursovaaRab.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChangeMaterialWindow.xaml
    /// </summary>
    public partial class ChangeMaterialWindow : Window
    {
        private readonly IMaterialLogic _materialLogic;
        private int? id;
        public int Id { set { id = value; } }

        public ChangeMaterialWindow(IMaterialLogic materialLogic)
        {
            InitializeComponent();
            _materialLogic = materialLogic;
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
                if (string.IsNullOrEmpty(TextBoxGroup.Text))
                {
                    MessageBox.Show("Заполните поле Группа Материала", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _materialLogic.CreateOrUpdate(new MaterialBindingModel
                {
                    Name = TextBoxName.Text,
                    GroupMaterials = TextBoxGroup.Text,
                    Id = id > 0 ? id : null
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Close();
        }

        private void ButtonCansel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = _materialLogic.Read(new MaterialBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        TextBoxName.Text = view.Name;
                        TextBoxGroup.Text = view.GroupMaterials;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

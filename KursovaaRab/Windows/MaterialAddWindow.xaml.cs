using KursContracts.BindingModels;
using KursContracts.BusinessLogicInterfases;
using KursContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace KursovaaRab.Windows
{
    /// <summary>
    /// Логика взаимодействия для MaterialAddWindow.xaml
    /// </summary>
    public partial class MaterialAddWindow : Window
    {
        private readonly IMaterialLogic _materialLogic;
        public int Id
        {
            get { return Convert.ToInt32(ComboBoxMaterial.SelectedValue); }
            set { ComboBoxMaterial.SelectedValue = value; }
        }
        public string MaterialName { get { return ComboBoxMaterial.Text; } }
        public int Count
        {
            get { return Convert.ToInt32(TextBoxCount.Text); }
            set { TextBoxCount.Text = value.ToString(); }
        }

        public MaterialAddWindow(IMaterialLogic logic)
        {
            InitializeComponent();

            List<MaterialViewModel> list = logic.Read(null);
            if(list != null)
            {
                ComboBoxMaterial.DisplayMemberPath = "Name";
                ComboBoxMaterial.SelectedValuePath = "Id";
                ComboBoxMaterial.ItemsSource = list;
                ComboBoxMaterial.SelectedItem = null;
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DialogResult = true;
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}

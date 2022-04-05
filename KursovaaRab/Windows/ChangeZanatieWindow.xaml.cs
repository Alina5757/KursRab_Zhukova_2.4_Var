using KursContracts.BindingModels;
using KursContracts.BusinessLogicInterfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KursovaaRab.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChangeZanatieWindow.xaml
    /// </summary>
    public partial class ChangeZanatieWindow : Window
    {
        private readonly IClassLogic _classLogic;
        private int? id;
        public int Id { set { id = value; } }

        public ChangeZanatieWindow(IClassLogic classLogic)
        {
            InitializeComponent();
            _classLogic = classLogic;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TextBoxNumber.Text))
                {
                    MessageBox.Show("Заполните поле Номер занятия", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (string.IsNullOrEmpty(TextBoxName.Text))
                {
                    MessageBox.Show("Заполните поле Название изделия", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (string.IsNullOrEmpty(DatePicker.Text))
                {
                    MessageBox.Show("Заполните поле Дата проведения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _classLogic.CreateOrUpdate(new ClassBindingModel
                {
                    Number = Convert.ToInt32(TextBoxNumber.Text),
                    Theme = TextBoxName.Text,
                    Date = Convert.ToDateTime(DatePicker.Text),
                    TeacherId = MainWindow.CurrentTeacherId,
                    Id = id > 0 ? id : null
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = _classLogic.Read(new ClassBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        TextBoxNumber.Text = Convert.ToString(view.Number);
                        TextBoxName.Text = view.Theme;
                        DatePicker.Text = Convert.ToString(view.Date);
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

using KursContracts.BindingModels;
using KursContracts.BusinessLogicInterfases;
using System;
using System.Windows;

namespace KursovaaRab.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistraziaWindow.xaml
    /// </summary>
    public partial class RegistraziaWindow : Window
    {
        private readonly ITeacherLogic _teacherLogic;
        public RegistraziaWindow(ITeacherLogic teacherLogic)
        {
            InitializeComponent();
            _teacherLogic = teacherLogic;
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxLogin.Text))
            {
                MessageBox.Show("Заполните поле Логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(TextBoxFIO.Text))
            {
                MessageBox.Show("Заполните поле ФИО", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(TextBoxElPochta.Text))
            {
                MessageBox.Show("Заполните поле Электронная почта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(TextBoxPassword.Text))
            {
                MessageBox.Show("Заполните поле Пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(TextBoxRepitePassword.Text))
            {
                MessageBox.Show("Заполните поле Повторите пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                _teacherLogic.Create(new TeacherBindingModel
                {
                    Login = TextBoxLogin.Text,
                    FIO = TextBoxFIO.Text,
                    Email = TextBoxElPochta.Text,
                    Password = TextBoxPassword.Text
                });
                MessageBox.Show("Пользователь успешно создан", "Пользователь создан", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

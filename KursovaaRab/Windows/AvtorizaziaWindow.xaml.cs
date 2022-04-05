using KursContracts.BindingModels;
using KursContracts.BusinessLogicInterfases;
using KursContracts.ViewModels;
using System;
using System.Windows;

namespace KursovaaRab.Windows
{
    /// <summary>
    /// Логика взаимодействия для AvtorizaziaWindow.xaml
    /// </summary>
    public partial class AvtorizaziaWindow : Window
    {
        private readonly ITeacherLogic _teacherLogic;
        public AvtorizaziaWindow(ITeacherLogic teacherLogic)
        {
            InitializeComponent();
            _teacherLogic = teacherLogic;
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxLogin.Text))
            {
                MessageBox.Show("Заполните поле Логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (string.IsNullOrEmpty(TextBoxPassword.Text))
            {
                MessageBox.Show("Заполните поле Пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            try
            {
                var teacher = _teacherLogic.Enter(new TeacherBindingModel { Login = TextBoxLogin.Text, Password = TextBoxPassword.Text });
                MainWindow.CurrentTeacherId = teacher.Id;
                MainWindow.CurrentTeacherLogin = teacher.Login;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            MessageBoxResult result = MessageBoxResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

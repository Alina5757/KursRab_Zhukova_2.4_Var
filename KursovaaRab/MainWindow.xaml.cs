using System.Windows;
using Unity;

namespace KursovaaRab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int CurrentTeacherId { get; set; }
        public static string CurrentTeacherLogin { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FormMaterial_Click(object sender, RoutedEventArgs e)
        {
            var form = Programm.Container.Resolve<Windows.MaterialsWindow>();
            form.ShowDialog();
        }

        private void FormTask_Click(object sender, RoutedEventArgs e)
        {
            var form = Programm.Container.Resolve<Windows.ZadaniaWindow>();
            form.ShowDialog();
        }

        private void FormClass_Click(object sender, RoutedEventArgs e)
        {
            var form = Programm.Container.Resolve<Windows.ZanatiaWindow>();
            form.ShowDialog();
        }

        private void FormCraft_Click(object sender, RoutedEventArgs e)
        {
            var form = Programm.Container.Resolve<Windows.SpisokWindow>();
            form.ShowDialog();
        }

        private void FormReport_Click(object sender, RoutedEventArgs e)
        {
            var form = Programm.Container.Resolve<Windows.OtchetWindow>();
            form.ShowDialog();
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            var form = Programm.Container.Resolve<Windows.RegistraziaWindow>();
            form.ShowDialog();
        }

        private void ButtonAvtorize_Click(object sender, RoutedEventArgs e)
        {
            var form = Programm.Container.Resolve<Windows.AvtorizaziaWindow>();
            form.ShowDialog();
        }

        private void CheckProfile(object sender, RoutedEventArgs e)
        {
            if (CurrentTeacherLogin != null)
            {
                Menu.IsEnabled = true;
                LabelProfile.Content = CurrentTeacherLogin;
                ButtonChangeProfile.Visibility = Visibility.Visible;
            }
            else
            {
                Menu.IsEnabled = false;
                LabelProfile.Content = "Вход не выполнен";
                ButtonChangeProfile.Visibility = Visibility.Hidden;
            }
        }

        private void ButtonChangeProfile_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bankyep
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public static MainWindow Instance { get; private set; } // тут будет форма

        public List<string> Names = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserContext db = new UserContext();
            db.Users.Load();
            DataBaseGrid.ItemsSource = db.Users.Local.ToBindingList<User>();

        }

        private void RegisterCaller_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
        }

        private void EnterCaller_Click(object sender, RoutedEventArgs e) // Вызов окна входа
        {
            EnterFiled enterFiled = new EnterFiled();
            enterFiled.Show();
        }

      

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainRoomFeild.IsEnabled = false;
            LabelEventler.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Perevod perevod = new Perevod();
            perevod.Show();

        }
    }
}

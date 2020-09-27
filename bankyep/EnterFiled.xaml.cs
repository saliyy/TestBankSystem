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
using System.Windows.Shapes;

namespace bankyep
{
    /// <summary>
    /// Логика взаимодействия для EnterFiled.xaml
    /// </summary>
    public partial class EnterFiled : Window
    {
        UserContext context;
        public User temp;
        public static EnterFiled Instance { get; private set; } // тут будет форма
        public EnterFiled()
        {
            InitializeComponent();
            context = new UserContext();
            temp = new User();
            Instance = this;
            
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            temp = Enter.is_Entered(LoginEnter.Text, PasswordEnterField.Text, NameEnter.Text, context.Users, this);
        }
    }
    public static class Enter
    {
        public static User is_Entered(string Login, string Password, string Name, DbSet<User> users, EnterFiled enterField)
        {
            bool entered = false;

            User user = new User();

            using(UserContext data = new UserContext())
            {
                foreach (var client in users)
                {
                    if (client.Login == Login & client.Password == Password & client.Name == Name)
                    {
                        entered = true;
                        user = client;
                        break;
                    }
                }

            }

            if (entered == true)
            {
                MessageBox.Show($"Здравствуйте {user.Name}, теперь вы можете перейти в личный кабинет");


                MainWindow.Instance.LabelEventler.Visibility = Visibility.Visible;
                MainWindow.Instance.MainRoomFeild.IsEnabled = true;
                MainWindow.Instance.NameLabel.Content = $"Имя: {user.Name}";
                MainWindow.Instance.PersonMoneyLabel.Content = $"Счёт: {user.Cash}";
                MainWindow.Instance.FaceLabel.Content = $"Лицо: {user.Face}";
                MainWindow.Instance.CreditHistoryLabel.Content = $"Кр.История: {user.creditHistory}";
                MainWindow.Instance.EnterCaller.Visibility = Visibility.Collapsed;

                enterField.Close();

              

            }
            else
            {

                MessageBox.Show("Такого пользователя не существует");
            }
            return user;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public static List<string> Names = new List<string>();

     

        public Registration()
        {
            InitializeComponent();
        }

        private void Reguster_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(NameField.Text) || String.IsNullOrWhiteSpace(LoginField.Text) ||
               String.IsNullOrWhiteSpace(PasswordField.Text) || SetFaceField.SelectedIndex == -1)
            {
                MessageBox.Show("Заполните все поля!");
            }
            else if (Names.Contains(NameField.Text))
            {
                MessageBox.Show("Это имя занято, введите другое имя");
            }
            else
            {
                Names.Add(NameField.Text);

             

                using(UserContext db = new UserContext())
                {
                    db.Users.Add(new User(NameField.Text, SetFaceField.SelectedIndex, 0, 100, LoginField.Text, PasswordField.Text));
                    db.SaveChangesAsync();
                    MessageBox.Show("Регистрация прошла успешно!");
                }
            }
                   
            
        }
    }
}

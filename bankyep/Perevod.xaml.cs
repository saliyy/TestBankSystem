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
    /// Логика взаимодействия для Perevod.xaml
    /// </summary>
    public partial class Perevod : Window
    {
        
        public Perevod()
        {
            InitializeComponent();
            
          
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            PerevodClass.SendMoney(AccepterName.Text, Summa.Text, EnterFiled.Instance.temp);
        }
    }
    public static class PerevodClass
    {

        public static void SendMoney(string AccepterName, string Summa, User SenderUser)
        {

            decimal money = Convert.ToDecimal(Summa);

            string mes = $"Вы действительно хотите перевести {Summa} на счёт {AccepterName} ?";

            var result = MessageBox.Show(mes, "Подтвердите действие", MessageBoxButton.OKCancel);

            UserContext userContext = new UserContext(); 

            if (result == MessageBoxResult.OK)
            {
                if (String.IsNullOrWhiteSpace(AccepterName) || String.IsNullOrWhiteSpace(Summa))
                {
                    MessageBox.Show("Заполните все поля!");
                }

                if (money <= 0 || SenderUser.Cash < money)
                {
                    MessageBox.Show("У вас недостаточно средств!");
                }
                else
                {
                    try
                    {
                        foreach(var item in userContext.Set<User>())
                        {
                            if(item.Name == AccepterName)
                            {
                                item.Cash += money;

                                SenderUser.Cash -= money;

                                userContext.SaveChangesAsync();

                                MessageBox.Show($"{money} успешно переведены на счёт {item.Name}");

                                
                            }
                        }

                       
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            if (result == MessageBoxResult.Cancel)
            {
                MessageBox.Show("Действие отменено");
            }

        }


    }
}

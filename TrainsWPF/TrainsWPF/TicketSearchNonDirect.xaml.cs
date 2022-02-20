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

namespace TrainsWPF
{
    /// <summary>
    /// Логика взаимодействия для TicketSearchNonDirect.xaml
    /// </summary>
    public partial class TicketSearchNonDirect : Window
    {
        string userNumber = "";
        public TicketSearchNonDirect(string _userNumber)
        {
            InitializeComponent();
            userNumber = _userNumber;
            if (userNumber != "None")
            {
                LogIn_LogOut.Content = "Выйти";
                SignUp_Cabinet.Content = "Личный кабинет";
            }
            ShowAltLabel.Visibility = Visibility.Collapsed;
            ShowAlt.Visibility = Visibility.Collapsed;
        }
        private void BuyTicket_Click(object sender, RoutedEventArgs e)
        {
            if (userNumber != "None")
            {
                if ((Id1.Text != "")&&(Id2.Text != ""))
                {
                    MessageBox.Show("Покупка успешна");
                }
                else MessageBox.Show("Пожалуйста, укажите ID поездов, на которые хотите купить билеты", "Ошибка");
            }
            else
            {
                MessageBox.Show("Пожалуйста, войдите в аккаунт", "Ошибка");
                LogIn login = new LogIn();
                login.Show();
                this.Close();
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if ((Origin.Text != "") && (Destination.Text != ""))
            {
                MessageBox.Show("Функционал поиска");
                ShowAltLabel.Visibility = Visibility.Visible;
                ShowAlt.Visibility = Visibility.Visible;
            }
            else MessageBox.Show("Пожалуйста, введите город отбытия и город назначения", "Ошибка");
        }

        private void ShowAlt_Click(object sender, RoutedEventArgs e)
        {
            TicketSearchMain ticketSearchMain = new TicketSearchMain(userNumber);
            ticketSearchMain.Show();
            this.Close();
        }

        private void LogIn_LogOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            this.Close();
        }

        private void SignUp_Cabinet_Click(object sender, RoutedEventArgs e)
        {
            if (userNumber == "None")
            {
                SignUp signup = new SignUp();
                signup.Show();
                this.Close();
            }
            else
            {
                Cabinet cabinet = new Cabinet(userNumber);
                cabinet.Show();
                this.Close();
            }
        }
    }
}

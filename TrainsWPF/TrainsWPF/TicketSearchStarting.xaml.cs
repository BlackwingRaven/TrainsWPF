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
    /// Логика взаимодействия для TicketSearchStarting.xaml
    /// </summary>
    public partial class TicketSearchStarting : Window
    {
        public TicketSearchStarting()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            this.Close();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp signup = new SignUp();
            signup.Show();
            this.Close();
        }

        private void TicketSearch_Click(object sender, RoutedEventArgs e)
        {
            if ((Origin.Text != "") && (Destination.Text != ""))
            {
                TicketSearchMain ticketSearch = new TicketSearchMain("None", Origin.Text, Destination.Text);
                ticketSearch.Show();
                this.Close();
            }
            else MessageBox.Show("Пожалуйста, введите город отбытия и город назначения", "Ошибка");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

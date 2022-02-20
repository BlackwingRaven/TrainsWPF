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
    /// Логика взаимодействия для Cabinet.xaml
    /// </summary>
    public partial class Cabinet : Window
    {
        string userNumber = "";
        public Cabinet(string _userNumber)
        {
            InitializeComponent();
            userNumber = _userNumber;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            TicketSearchMain ticketSearchMain = new TicketSearchMain(userNumber);
            ticketSearchMain.Show();
            this.Close();
        }

        private void CancelTicket_Click(object sender, RoutedEventArgs e)
        {
            if (Id.Text != "")
            {
                MessageBox.Show("Отмена успешна");
            }
            else MessageBox.Show("Пожалуйста, укажите ID билета, покупку которого хотите отменить", "Ошибка");
        }
    }
}

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
        List<TicketInfo> gridSource = new List<TicketInfo>();
        TrainsDBEntities db = new TrainsDBEntities();
        string userNumber = "";
        public Cabinet(string _userNumber)
        {
            InitializeComponent();
            userNumber = _userNumber;
            foreach (Buyer buyer in db.Buyer)
            {
                if (buyer.TelNum == userNumber)
                {
                    Greeting.Content = "Здравствуйте, " + buyer.FirstName + "!";
                    break;
                }
            }
            gridSource.Clear();
            foreach (TicketInfo ticket in db.TicketInfo)
            {
                if (ticket.UserTelNum==userNumber)
                {
                    gridSource.Add(ticket);
                }
            }
            DG.ItemsSource = gridSource;
            DG.Items.Refresh();
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
                bool checkIDs = false;
                foreach (TicketInfo ticket in gridSource)
                {
                    if (Convert.ToString(ticket.TicketID) == Id.Text)
                    {
                        checkIDs = true;
                        break;
                    }
                }
                if (checkIDs)
                {
                    Ticket ticket = new Ticket();
                    foreach (Ticket _ticket in db.Ticket)
                    {
                        if (_ticket.ID == Convert.ToInt32(Id.Text))
                        {
                            ticket = _ticket;
                            break;
                        }
                    }
                    db.Ticket.Remove(ticket);
                    db.SaveChanges();
                    MessageBox.Show("Отмена успешна");
                    gridSource.Clear();
                    foreach (TicketInfo _ticket in db.TicketInfo)
                    {
                        if (_ticket.UserTelNum == userNumber)
                        {
                            gridSource.Add(_ticket);
                        }
                    }
                    DG.ItemsSource = gridSource;
                    DG.Items.Refresh();
                }
                else MessageBox.Show("Пожалуйста, введите корректный ID билета, покупку которого хотите отменить", "Ошибка");
            }
            else MessageBox.Show("Пожалуйста, укажите ID билета, покупку которого хотите отменить", "Ошибка");
        }
    }
}

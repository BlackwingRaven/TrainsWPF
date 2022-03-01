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
        TrainsDBEntities db = new TrainsDBEntities();
        string userNumber = "";
        List<IndirectTrains> gridSource = new List<IndirectTrains>();
        public TicketSearchNonDirect(string _userNumber, string _origin, string _destination)
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
            Origin.Text = _origin;
            Destination.Text = _destination;
            //поиск
            gridSource.Clear();
            DateTime currDateTime = DateTime.Now;
            foreach (IndirectTrains train in db.IndirectTrains)
            {
                if ((train.Origin1 == Origin.Text) && (train.Dest2 == Destination.Text) && (train.DepTime1 > currDateTime))
                {
                    gridSource.Add(train);
                }
            }
            DG.ItemsSource = gridSource;
            DG.Items.Refresh();
            bool directTrainCheck = false;
            foreach (Train train in db.Train)
            {
                if ((train.Origin == Origin.Text) && (train.Destination == Destination.Text) && (train.DepartTime > currDateTime))
                {
                    directTrainCheck = true;
                    break;
                }
            }
            if (directTrainCheck)
            {
                ShowAltLabel.Visibility = Visibility.Visible;
                ShowAlt.Visibility = Visibility.Visible;
            }
        }
        private void BuyTicket_Click(object sender, RoutedEventArgs e)
        {
            if (userNumber != "None")
            {
                if ((Id1.Text != "")&&(Id2.Text != ""))
                {
                    bool checkID1 = false;
                    bool checkID2 = false;
                    foreach (IndirectTrains train in gridSource)
                    {
                        if (Convert.ToString(train.Id1) == Id1.Text) checkID1 = true;
                        if (Convert.ToString(train.Id2) == Id2.Text) checkID2 = true;
                        if (checkID1 && checkID2) break;
                    }
                    if (checkID1&&checkID2)
                    {
                        Ticket ticket1 = new Ticket();
                        Ticket ticket2 = new Ticket();
                        int maxID = 0;
                        foreach (Ticket _ticket in db.Ticket)
                        {
                            if (_ticket.ID > maxID) maxID = _ticket.ID;
                        }
                        maxID++;
                        ticket1.ID = maxID;
                        ticket1.UserTelNum = userNumber;
                        ticket1.TrainID = Convert.ToInt32(Id1.Text);
                        db.Ticket.Add(ticket1);
                        maxID++;
                        ticket2.ID = maxID;
                        ticket2.UserTelNum = userNumber;
                        ticket2.TrainID = Convert.ToInt32(Id2.Text);
                        db.Ticket.Add(ticket2);
                        db.SaveChanges();
                        MessageBox.Show("Покупка успешна");
                    }
                    else MessageBox.Show("Пожалуйста, введите корректные ID поездов, на которые хотите купить билет", "Ошибка");
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
                gridSource.Clear();
                DateTime currDateTime = DateTime.Now;
                foreach (IndirectTrains train in db.IndirectTrains)
                {
                    if ((train.Origin1 == Origin.Text) && (train.Dest2 == Destination.Text) && (train.DepTime1 > currDateTime))
                    {
                        gridSource.Add(train);
                    }
                }
                DG.ItemsSource = gridSource;
                DG.Items.Refresh();
                bool directTrainCheck = false;
                foreach (Train train in db.Train)
                {
                    if ((train.Origin == Origin.Text) && (train.Destination == Destination.Text) && (train.DepartTime > currDateTime))
                    {
                        directTrainCheck = true;
                        break;
                    }
                }
                if (directTrainCheck)
                {
                    ShowAltLabel.Visibility = Visibility.Visible;
                    ShowAlt.Visibility = Visibility.Visible;
                }
            }
            else MessageBox.Show("Пожалуйста, введите город отбытия и город назначения", "Ошибка");
        }

        private void ShowAlt_Click(object sender, RoutedEventArgs e)
        {
            TicketSearchMain ticketSearchMain = new TicketSearchMain(userNumber, Origin.Text, Destination.Text);
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

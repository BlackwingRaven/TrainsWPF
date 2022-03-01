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
    /// Логика взаимодействия для TicketSearchMain.xaml
    /// </summary>
    public partial class TicketSearchMain : Window
    {
        TrainsDBEntities db = new TrainsDBEntities();
        string userNumber = "";
        List<Train> gridSource = new List<Train>();
        public TicketSearchMain(string _userNumber)
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

        public TicketSearchMain(string _userNumber, string _origin, string _destination)
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
            foreach (Train train in db.Train)
            {
                if ((train.Origin == Origin.Text) && (train.Destination == Destination.Text) && (train.DepartTime > currDateTime))
                {
                    gridSource.Add(train);
                }
            }
            DG.ItemsSource = gridSource;
            DG.Items.Refresh();
            bool indirectTrainCheck = false;
            foreach (IndirectTrains train in db.IndirectTrains)
            {
                if ((train.Origin1 == Origin.Text) && (train.Dest2 == Destination.Text) && (train.DepTime1 > currDateTime))
                {
                    indirectTrainCheck = true;
                    break;
                }
            }
            if (indirectTrainCheck)
            {
                ShowAltLabel.Visibility = Visibility.Visible;
                ShowAlt.Visibility = Visibility.Visible;
            }
        }

        private void BuyTicket_Click(object sender, RoutedEventArgs e)
        {
            if (userNumber != "None")
            {
                if (Id.Text != "")
                {
                    bool checkIDs = false;
                    foreach (Train train in gridSource)
                    {
                        if (Convert.ToString(train.ID) == Id.Text)
                        {
                            checkIDs = true;
                            break;
                        }
                    }
                    if (checkIDs)
                    {
                        Ticket ticket = new Ticket();
                        int maxID = 0;
                        foreach (Ticket _ticket in db.Ticket)
                        {
                            if (_ticket.ID > maxID) maxID = _ticket.ID;
                        }
                        maxID++;
                        ticket.ID = maxID;
                        ticket.UserTelNum = userNumber;
                        ticket.TrainID = Convert.ToInt32(Id.Text);
                        db.Ticket.Add(ticket);
                        db.SaveChanges();
                        MessageBox.Show("Покупка успешна");
                    }
                    else MessageBox.Show("Пожалуйста, введите корректный ID поезда, на который хотите купить билет", "Ошибка");
                }
                else MessageBox.Show("Пожалуйста, укажите ID поезда, на который хотите купить билет", "Ошибка");
            }
            else
            {
                MessageBox.Show("Пожалуйста, войдите в аккаунт","Ошибка");
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
                foreach (Train train in db.Train)
                {
                    if ((train.Origin == Origin.Text) && (train.Destination == Destination.Text) && (train.DepartTime > currDateTime))
                    {
                        gridSource.Add(train);
                    }
                }
                DG.ItemsSource = gridSource;
                DG.Items.Refresh();
                bool indirectTrainCheck = false;
                foreach (IndirectTrains train in db.IndirectTrains)
                {
                    if ((train.Origin1 == Origin.Text) && (train.Dest2 == Destination.Text) && (train.DepTime1 > currDateTime))
                    {
                        indirectTrainCheck = true;
                        break;
                    }
                }
                if (indirectTrainCheck)
                {
                    ShowAltLabel.Visibility = Visibility.Visible;
                    ShowAlt.Visibility = Visibility.Visible;
                }
            }
            else MessageBox.Show("Пожалуйста, введите город отбытия и город назначения", "Ошибка");
        }

        private void ShowAlt_Click(object sender, RoutedEventArgs e)
        {
            TicketSearchNonDirect ticketSearchNonDirect = new TicketSearchNonDirect(userNumber, Origin.Text, Destination.Text);
            ticketSearchNonDirect.Show();
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

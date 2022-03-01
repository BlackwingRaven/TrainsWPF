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

namespace TrainsWPF_Employee
{
    /// <summary>
    /// Логика взаимодействия для TrainsView.xaml
    /// </summary>
    public partial class TrainsView : Window
    {
        List<Train> gridSource = new List<Train>();
        TrainsDBEntities db = new TrainsDBEntities();
        public TrainsView()
        {
            InitializeComponent();
            foreach(Train train in db.Train)
            {
                gridSource.Add(train);
            }
            DG.ItemsSource = gridSource;
            DG.Items.Refresh();
        }

        private void DeleteTrain_Click(object sender, RoutedEventArgs e)
        {
            if (Id.Text != "")
            {
                bool checkID = false;
                Train toDelete = new Train();
                foreach (Train train in db.Train)
                {
                    if (Convert.ToString(train.ID) == Id.Text)
                    {
                        toDelete = train;
                        checkID = true;
                        break;
                    }
                }
                if (checkID)
                {
                    bool checkTickets = true;
                    foreach (Ticket ticket in db.Ticket)
                    {
                        if (ticket.TrainID == toDelete.ID)
                        {
                            checkTickets = false;
                            break;
                        }
                    }
                    if (checkTickets)
                    {
                        db.Train.Remove(toDelete);
                        db.SaveChanges();
                        MessageBox.Show("Поезд успешно удалён");
                        gridSource.Clear();
                        foreach (Train train in db.Train)
                        {
                            gridSource.Add(train);
                        }
                        DG.ItemsSource = gridSource;
                        DG.Items.Refresh();
                    }
                    else MessageBox.Show("Ошибка: невозможно удалить поезд, на который куплены билеты");
                }
                else MessageBox.Show("Ошибка: некорректный ID");
            }
            else MessageBox.Show("Введите ID");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Close();
        }

        private void AddTrain_Click(object sender, RoutedEventArgs e)
        {
            TrainAdd trainAdd = new TrainAdd();
            trainAdd.Show();
            this.Close();
        }
    }
}

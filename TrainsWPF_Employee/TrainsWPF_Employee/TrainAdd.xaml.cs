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
    /// Логика взаимодействия для TrainAdd.xaml
    /// </summary>
    public partial class TrainAdd : Window
    {
        TrainsDBEntities db = new TrainsDBEntities();
        public TrainAdd()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            TrainsView trainsView = new TrainsView();
            trainsView.Show();
            this.Close();
        }

        private void AddTrain_Click(object sender, RoutedEventArgs e)
        {
            if (originBox.Text != "" && destBox.Text != "" && capBox.Text != "" && depBox.Text != "" && arrBox.Text != "" && costBox.Text != "")
            {
                int maxID = 0;
                foreach (Train _train in db.Train)
                {
                    if (_train.ID > maxID) maxID = _train.ID;
                }
                maxID++;
                Train train = new Train();
                train.ID = maxID;
                train.Origin = originBox.Text;
                train.Destination = destBox.Text;
                train.DepartTime = Convert.ToDateTime(depBox.Text);
                train.ArriveTime = Convert.ToDateTime(arrBox.Text);
                train.MaxCapacity = Convert.ToInt32(capBox.Text);
                train.TicketCost = Convert.ToInt32(costBox.Text);
                db.Train.Add(train);
                db.SaveChanges();
                MessageBox.Show("Поезд добавлен");
                TrainsView trainsView = new TrainsView();
                trainsView.Show();
                this.Close();
            }
        }
    }
}

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
        public TrainsView()
        {
            InitializeComponent();
        }

        private void DeleteTrain_Click(object sender, RoutedEventArgs e)
        {

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

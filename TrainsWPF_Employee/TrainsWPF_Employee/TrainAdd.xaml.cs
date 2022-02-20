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
    }
}

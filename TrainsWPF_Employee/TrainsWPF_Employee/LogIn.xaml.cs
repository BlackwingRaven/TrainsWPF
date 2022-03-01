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
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        TrainsDBEntities db = new TrainsDBEntities();
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text != "" && password.Text != "")
            {
                bool check = false;
                foreach (Employee employee in db.Employee)
                {
                    if (employee.Login == login.Text && employee.Password == password.Text)
                    {
                        check = true;
                        break;
                    }
                }
                if (check)
                {
                    TrainsView trainsView = new TrainsView();
                    trainsView.Show();
                    this.Close();
                }
                else MessageBox.Show("Неверный логин и/или пароль");
            }
            else MessageBox.Show("Заполните все поля");
        }
    }
}

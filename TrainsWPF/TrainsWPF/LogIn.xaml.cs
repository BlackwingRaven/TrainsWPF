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
            if ((telNum.Text != "") && (password.Text != ""))
            {
                bool checkUser = false;
                foreach (Buyer buyer in db.Buyer)
                {
                    if ((telNum.Text==buyer.TelNum)&&(password.Text==buyer.Password))
                    {
                        checkUser = true;
                        break;
                    }
                }
                if (checkUser)
                {
                    TicketSearchMain ticketSearchMain = new TicketSearchMain(telNum.Text);
                    ticketSearchMain.Show();
                    this.Close();
                }
                else MessageBox.Show("Пожалуйста, проверьте, правильно ли введены номер телефона и пароль", "Ошибка");
            }
            else MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            TicketSearchStarting starting = new TicketSearchStarting();
            starting.Show();
            this.Close();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp signup = new SignUp();
            signup.Show();
            this.Close();
        }
    }
}

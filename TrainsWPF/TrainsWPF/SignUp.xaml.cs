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
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        TrainsDBEntities db = new TrainsDBEntities();
        public SignUp()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            TicketSearchStarting starting = new TicketSearchStarting();
            starting.Show();
            this.Close();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            if ((telNum.Text != "") && (firstName.Text != "") && (lastName.Text != "") && (email.Text != "") && (password.Text != ""))
            {
                bool checkUser = true;
                foreach (Buyer buyer in db.Buyer)
                {
                    if (buyer.TelNum == telNum.Text)
                    {
                        checkUser = false;
                        break;
                    }
                }
                if (checkUser)
                {
                    Buyer buyer = new Buyer();
                    buyer.TelNum = telNum.Text;
                    buyer.FirstName = firstName.Text;
                    buyer.LastName = lastName.Text;
                    buyer.Email = email.Text;
                    buyer.Password = password.Text;
                    db.Buyer.Add(buyer);
                    db.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно. Вы будете перенаправлены на страницу авторизации.");
                    LogIn login = new LogIn();
                    login.Show();
                    this.Close();
                }
                else MessageBox.Show("Данный телефон уже зарегистрирован", "Ошибка");
            }
            else MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка");
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            this.Close();
        }
    }
}

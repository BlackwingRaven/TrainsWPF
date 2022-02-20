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
                MessageBox.Show("Регистрация успешна");
                LogIn login = new LogIn();
                login.Show();
                this.Close();
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

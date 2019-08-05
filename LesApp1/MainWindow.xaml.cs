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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LesApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Дані для перевірки логіна
        /// </summary>
        private string dataStrLogin = "0123456789qwertyuiopasdfghjklzxcvbnm";
        private string dataStrPassword = ",.-!@#$%^&*()";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // сохранение даных
            string login = tbLogin.Text;
            string password = tbPassword.Text;

            // проверка логина
            try
            {
                for (int i = 0; i < login.Length; i++)
                {
                    if (!dataStrLogin.Contains(login[i]))
                    {
                        throw new NotValidLoginExeption();
                    }
                }
                tbExeption.Text = "Все ОК";
            }
            catch (NotValidLoginExeption)
            {
                tbExeption.Text = "Недопустимые символы в логине";
                return;
            }
            catch (FalseLoginExeption)
            {

            }

            string dataStr = dataStrLogin + dataStrPassword;

            // проверка логина
            try
            {
                for (int i = 0; i < password.Length; i++)
                {
                    if (!dataStr.Contains(password[i]))
                    {
                        throw new NotValidPasswordExeption();
                    }

                }
                tbExeption.Text = "Все ОК";
            }
            catch (NotValidPasswordExeption)
            {
                tbExeption.Text = "Недопустимые символы в пароле";
                return;
            }

        }

    }

    class NotValidLoginExeption : Exception
    {
    }

    class NotValidPasswordExeption : Exception
    {

    }

    class FalseLoginExeption : Exception
    {
    }

    class FalsePasswordExeption : Exception
    {

    }
}

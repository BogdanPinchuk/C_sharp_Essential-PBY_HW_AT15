#define MessageBox
//#define StatusBar

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        /// <summary>
        /// Авиризація
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // збереження даних
            string login = tbLogin.Text.ToLower();
            string password = tbPassword.Text.ToLower();

            // перевірка авторизації
            try
            {
                // перевірка логіна
                for (int i = 0; i < login.Length; i++)
                {
                    if (!dataStrLogin.Contains(login[i]))
                    {
                        throw new NotValidLoginExeption();
                    }
                }

                // перевірка пароля
                for (int i = 0; i < password.Length; i++)
                {
                    if (!(dataStrLogin + dataStrPassword).Contains(password[i]))
                    {
                        throw new NotValidPasswordExeption();
                    }
                }

                // якщо успішно
                Singal("Все ОК"); 

            }
            catch (NotValidLoginExeption ex)
            {
                Singal(ex.Message);
            }
            catch (NotValidPasswordExeption ex)
            {
                Singal(ex.Message);
            }
        }

        /// <summary>
        /// Аналіз лише логіна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbLogin_KeyDown(object sender, KeyEventArgs e)
        {
            // при натисканні Enter перевіряє правильність
            if (e.Key == Key.Enter)
            {
                // збереження даних
                string login = tbLogin.Text.ToLower();

                try
                {
                    // перевірка логіна
                    for (int i = 0; i < login.Length; i++)
                    {
                        if (!dataStrLogin.Contains(login[i]))
                        {
                            throw new NotValidLoginExeption();
                        }
                    }

                    // якщо успішно
                    Singal("З логіном все ОК");
                }
                catch (NotValidLoginExeption ex)
                {
                    Singal(ex.Message);
                }
            }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            // при натисканні Enter перевіряє правильність
            if (e.Key == Key.Enter)
            {
                // збереження даних
                string password = tbPassword.Text.ToLower();

                // перевірка авторизації
                try
                {
                    // перевірка пароля
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (!(dataStrLogin + dataStrPassword).Contains(password[i]))
                        {
                            throw new NotValidPasswordExeption();
                        }
                    }

                    // якщо успішно
                    Singal("З паролем все ОК");
                }
                catch (NotValidPasswordExeption ex)
                {
                    Singal(ex.Message);
                }
            }
        }

        /// <summary>
        /// Сигнал, що символи відповідають обмеженням
        /// </summary>
        private void Singal(string s)
        {
            // якщо немає введених недопустимих символів
#if StatusBar
            tbExeption.Visibility = Visibility.Visible;
            tbExeption.Text = s;
#endif
#if MessageBox
            MessageBox.Show(s, "Registration",
                    MessageBoxButton.OK, MessageBoxImage.Information); 
#endif
        }
    }

    /// <summary>
    /// Помилка введення символів в логіні
    /// </summary>
    class NotValidLoginExeption : Exception
    {
        public override string Message { get; }
            = "Введені недопустимі символи в логіні";
    }

    /// <summary>
    /// Помилка введення символів в паролі
    /// </summary>
    class NotValidPasswordExeption : Exception
    {
        public override string Message { get; }
            = "Введені недопустимі символи в паролі";
    }
}

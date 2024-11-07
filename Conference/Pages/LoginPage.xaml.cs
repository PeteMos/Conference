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

namespace Conference.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                if (string.IsNullOrEmpty(IdNumberTextBox.Text))
                {
                    errors.AppendLine("Заполните Id номер");
                }
                if (string.IsNullOrEmpty(PasswordBox.Password))
                {
                    errors.AppendLine("Заполните пароль");
                }
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                // Преобразуем IdNumberTextBox.Text в int
                if (int.TryParse(IdNumberTextBox.Text, out int idNumber))
                {
                    // Проверяем, есть ли пользователь с таким Id и паролем
                    if (Data.ConferenceDataEntities.GetContext().General.Any(d => d.Id == idNumber && d.Password == PasswordBox.Password))
                    {
                        var user = Data.ConferenceDataEntities.GetContext().General.FirstOrDefault(d => d.Id == idNumber && d.Password == PasswordBox.Password);
                        // Здесь вы можете добавить логику для успешного входа
                    }
                    else
                    {
                        MessageBox.Show("Неверный ID или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("ID номер должен быть числом", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}

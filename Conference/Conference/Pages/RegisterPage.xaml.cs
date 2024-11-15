using System;
using System.Linq;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Conference.Data;

namespace Conference.Pages
{
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            IdTextBox.Visibility = Visibility.Hidden;
            IdLabel.Visibility = Visibility.Hidden;
            GenderComboBox.ItemsSource = Data.ConferenceDataEntities.GetContext().Gender.ToList();
            RoleComboBox.ItemsSource = Data.ConferenceDataEntities.GetContext().Roles.ToList();
            DirectionComboBox.ItemsSource = Data.ConferenceDataEntities.GetContext().Direction.ToList();
            EventComboBox.ItemsSource = Data.ConferenceDataEntities.GetContext().Event_act.ToList();
        }

            private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Валидация данных
            if (string.IsNullOrWhiteSpace(FullNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
                string.IsNullOrWhiteSpace(PhoneTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Password) ||
                PasswordBox.Password != ConfirmPasswordBox.Password)
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля и убедитесь, что пароли совпадают.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!IsValidPhoneNumber(PhoneTextBox.Text))
            {
                MessageBox.Show("Телефон должен быть в формате +7(999)-099-90-90.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!IsValidPassword(PasswordBox.Password))
            {
                MessageBox.Show("Пароль должен содержать не менее 6 символов, включая заглавные и строчные буквы, цифры и специальные символы.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            // Переход на другую страницу или очистка формы
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.GoBack();
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            var regex = new Regex(@"^\+7\(\d{3}\)-\d{3}-\d{2}-\d{2}$");
            return regex.IsMatch(phoneNumber);
        }

        private bool IsValidPassword(string password)
        {
            return password.Length >= 6 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsDigit) &&
                   password.Any(ch => !char.IsLetterOrDigit(ch));
        }

        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void GenderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DirectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EventComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Conference.Pages
{
    public partial class OrganizatorPage : Page
    {
        public OrganizatorPage(string userName, string userPhotoPath)
        {
            InitializeComponent();

            UserNameLabel.Content = string.IsNullOrEmpty(userName) ? "Неизвестный пользователь" : userName;

            if (!string.IsNullOrEmpty(userPhotoPath))
            {
                UserImage.Source = new BitmapImage(new Uri(userPhotoPath, UriKind.RelativeOrAbsolute));
            }

            GreetUser();
        }

        private void GreetUser()
        {
            string greeting = "Доброе утро/день/вечер";
            var currentTime = DateTime.Now;

            if (currentTime.Hour >= 9 && currentTime.Hour < 11)
            {
                greeting = "Доброе утро!";
            }
            else if (currentTime.Hour >= 11 && currentTime.Hour < 18)
            {
                greeting = "Добрый день!";
            }
            else
            {
                greeting = "Добрый вечер!";
            }

            GreetingLabel.Content = greeting;
        }

        private void EventButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.RegisterPage());
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.RegisterPage());
        }

        private void JuryButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.RegisterPage());
        }
    }
}

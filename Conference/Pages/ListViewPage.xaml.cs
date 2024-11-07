using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
namespace Conference.Pages
{
    public partial class ListViewPage : Page
    {
        public ListViewPage()
        {
            InitializeComponent();
            Init();
            LoadEvents();
        }
        private void Init()
        {
            var directionList = Data.ConferenceDataEntities.GetContext().Direction.ToList();
            directionList.Insert(0, new Data.Direction { Direction1 = "Все направления" });
            DirectionComboBox.ItemsSource = directionList;
            DirectionComboBox.SelectedIndex = 0;
        }
        private void LoadEvents()
        {
            Classes.Manager.GetImageData();
            EventListView.ItemsSource = Data.ConferenceDataEntities.GetContext().General.ToList();
        }
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var data = Convert.ToDateTime(DatePicker.SelectedDate).ToShortDateString();
            MessageBox.Show(data);
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.LoginPage());
        }
        private void Update()
        {
            try
            {
                var selected = DirectionComboBox.SelectedItem as Data.Direction;
                if (selected != null && selected.Direction1 != "Все направления")
                {
                    // Логика обновления данных
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        public class Event
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public DateTime Date { get; set; }
            public int DirectionId { get; set; }
            public byte[] Image { get; set; }

            public BitmapImage ImageSource
            {
                get
                {
                    if (Image != null)
                    {
                        using (var stream = new MemoryStream(Image))
                        {
                            var bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.StreamSource = stream;
                            bitmap.CacheOption = BitmapCacheOption.OnLoad;
                            bitmap.EndInit();
                            bitmap.Freeze();
                            return bitmap;
                        }
                    }
                    return null;
                }
            }
        }

    }
}

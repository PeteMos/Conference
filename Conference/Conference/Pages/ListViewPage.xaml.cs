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
            directionList.Insert(0, new Data.Direction { Id_dir = 0, Direction1 = "Все направления" }); // Добавляем опцию "Все направления"
            DirectionComboBox.ItemsSource = directionList;
            DirectionComboBox.SelectedIndex = 0;
        }

        private void LoadEvents()
        {
            // Загрузка всех мероприятий
            var events = Data.ConferenceDataEntities.GetContext().Events.ToList();
            EventListView.ItemsSource = events.Select(e => new Event
            {
                Id = e.Id_ev,
                Title = e.Name_events,
                Date = e.Date,
                Image = e.Image
            }).ToList();
        }

        private void DirectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DirectionComboBox.SelectedItem is Data.Direction selectedDirection)
            {
                LoadFilteredEvents(selectedDirection.Id_dir);
            }
        }

        private void LoadFilteredEvents(int directionId)
        {
            // Получаем идентификаторы пользователей, связанных с выбранным направлением
            var userIds = Data.ConferenceDataEntities.GetContext().General
                .Where(g => g.IdDirection == directionId || directionId == 0) // Если выбрано "Все направления", берем всех пользователей
                .Select(g => g.Id);

            // Загружаем мероприятия, связанные с этими пользователями
            var events = Data.ConferenceDataEntities.GetContext().Events
                .Where(e => userIds.Contains(e.Id_ev)) // Предполагается, что IdEvent в General ссылается на мероприятие
                .ToList();

            EventListView.ItemsSource = events.Select(e => new Event
            {
                Id = e.Id_ev,
                Title = e.Name_events,
                Date = e.Date,
                Image = e.Image
            }).ToList();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DatePicker.SelectedDate.HasValue)
            {
                var data = DatePicker.SelectedDate.Value.ToShortDateString();
                MessageBox.Show(data);
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.LoginPage());
        }

        public class Event
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public DateTime Date { get; set; }
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

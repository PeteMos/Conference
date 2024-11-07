using System;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
namespace Conference.Classes
{
    public static class Manager
    {
        public static Frame MainFrame { get; set; }
        public static void GetImageData()
        {
            try
            {
                var list = Data.ConferenceDataEntities.GetContext().Events.ToList();
                foreach (var item in list)
                {
                    // Попробуем загрузить изображение в зависимости от его формата
                    string[] formats = { "jpeg", "jpg", "png", "bmp" }; // Здесь вы можете добавить другие форматы
                    foreach (var format in formats)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "img", $"{item.Id_ev}.{format}");
                        if (File.Exists(path))
                        {
                            item.Image = File.ReadAllBytes(path);
                            break; // Если изображение найдено, выходим из цикла
                        }
                    }
                }
                Data.ConferenceDataEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public static void PopulateListView(ListView listView)
        {
            try
            {
                listView.Items.Clear(); // Очистка ListView перед добавлением новых элементов
                var events = Data.ConferenceDataEntities.GetContext().Events.ToList();
                foreach (var eventItem in events)
                {
                    StackPanel stackPanel = new StackPanel { Orientation = Orientation.Vertical };
                    Image image = new Image();
                    string[] formats = { "jpeg", "jpg", "png", "bmp" }; // Форматы изображений
                    bool imageFound = false;
                    foreach (var format in formats)
                    {
                        string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "img", $"{eventItem.Id_ev}.{format}");
                        if (File.Exists(imagePath))
                        {
                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.UriSource = new Uri(imagePath);
                            bitmap.EndInit();
                            image.Source = bitmap;
                            imageFound = true;
                            break; // Выход из цикла, если изображение найдено
                        }
                    }
                    // Если изображение не найдено, можно установить изображение по умолчанию или обработать случай
                    if (!imageFound)
                    {
                        // Здесь можно установить изображение по умолчанию или оставить пустым
                        image.Source = new BitmapImage(new Uri("path/to/default/image.png", UriKind.Relative)); // Замените на путь к изображению по умолчанию
                    }
                    // Используйте нужное свойство для отображения текста
                    TextBlock textBlock = new TextBlock { Text = eventItem.ImageName }; // или eventItem.Description, если такое свойство существует
                    stackPanel.Children.Add(image);
                    stackPanel.Children.Add(textBlock);
                    ListViewItem listViewItem = new ListViewItem { Content = stackPanel };
                    listView.Items.Add(listViewItem);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}

using System.Windows;


namespace Lab2_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //метод вызывается при нажатии на кнопку "Add", он проверяет, что текстовое поле сообщения
        //не пустое,
        //если это так, то добавляет текст в список чата и очищает текстовое поле сообщения,
        //переводя фокус на него
        private void AddText_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Message.Text))
                return;
            Chat.Items.Add(Message.Text);
            Message.Clear();
            Message.Focus();
        }
    }
}

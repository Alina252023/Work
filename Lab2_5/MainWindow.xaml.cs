using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Lab2_5
{
    // Разработайте и реализуйте приложение WPF, которое:
    //- содержит меню и текстовый список
    //- содержит в меню два пункта, позволяющие загрузить текст из выбранного, с помощью диалога открытия, 
    //      файла текст в текстовый список,
    //      и сохранить текст из текстового списка в выбранный, при помощи диалога сохранения, файл
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Обработчик клика по пункту меню "Открыть"
        private void MnuOpen_Click(object sender, RoutedEventArgs e)
        {
            //Создаём диалог открытия файла
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //Устанавливаем фильтр файлов, чтобы можно было открывать только текстовые файлы
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files(*.*)|*.*";
            //если пользователь выбрал файл и нажал кнопку "Открыть"
            if (openFileDialog.ShowDialog() == true)
            {
                //Считываем содержимое файла
                string fileText = System.IO.File.ReadAllText(openFileDialog.FileName);
                //Загружаем содержимое в текстовый список
                txtEditor.Text = fileText;
            }
        }
        // Обработчик клика по пункту меню "Сохранить"
        private void MnuSave_Click(object sender, RoutedEventArgs e)
        {
            //Создаём диалог сохранения файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //Устанавливаем фильтр файлов, чтобы можно было открывать только текстовые файлы
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files(*.*)|*.*";
            //если пользователь выбрал имя файла и нажал кнопку "Сохранить"
            if (saveFileDialog.ShowDialog() == true)
            {
                // Записываем содержимое текстового списка в файл с выбранным именем
                System.IO.File.WriteAllText(saveFileDialog.FileName, txtEditor.Text);
            }
        }
    }
}
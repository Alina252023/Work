using System;
using System.Windows;


namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double num1;
        double num2;
        double totalNumber;// переменная totalNumber, которая будет использоваться для отображения результата расчёта

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            num1 = Convert.ToDouble(EnterA.Text); // извлечение текста из текстового поля EnterА и преобразование в двойной тип данных
            num2 = Convert.ToDouble(EnterB.Text); // извлечение текста из текстового поля EnterB и преобразование в двойной тип данных
            totalNumber = num1 + num2; // сложение двух чисел вместе и помещение их в переменную totalNumber

            Result.Content = totalNumber.ToString(); // показать общее число окне результата
        }

        private void Subtract_Click(object sender, RoutedEventArgs e)
        {
            num1 = Convert.ToDouble(EnterA.Text); 
            num2 = Convert.ToDouble(EnterB.Text); 
            totalNumber = num1 - num2; // вычитание двух чисел и помещение их в переменную totalNumber

            Result.Content = totalNumber.ToString(); 
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            num1 = Convert.ToDouble(EnterA.Text); 
            num2 = Convert.ToDouble(EnterB.Text); 
            totalNumber = num1 * num2; // умножение двух чисел и помещение их в переменную totalNumber

            Result.Content = totalNumber.ToString(); 
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            num1 = Convert.ToDouble(EnterA.Text); 
            num2 = Convert.ToDouble(EnterB.Text); 
            totalNumber = num1 / num2; // деление двух чисел и помещение их в переменную totalNumber
            totalNumber = Math.Round(totalNumber, 2); // округление числа в меньшую сторону на 2 десятичных знака

            Result.Content = totalNumber.ToString(); 
        }
    }
}

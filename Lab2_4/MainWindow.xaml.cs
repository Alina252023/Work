using System.Windows;
using System.Windows.Controls;
using System;

namespace Lab2_4  // Разработайте и реализуйте приложение WPF, которое:
//- содержит три выпадающих списка, с помощью которых можно выбрать год, месяц и день
//- количество дней в месяце определяется только после выбора года и месяца, до этого, 
//    выпадающий список с выбором дня должен быть не активен
//- после выбора всех трёх параметров, должно появляться сообщение с информацией о том, 
//    сколько лет, месяцев и дней прошло с выбранной даты до текущего момента
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Заполняем список годов
            for (int i = 1900; i <= DateTime.Now.Year; i++)
            {
                YearCombobox.Items.Add(i);
            }

            // Заполняем список месяцев
            for (int i = 1; i <= 12; i++)
            {
                MonthCombobox.Items.Add(i);
            }
            DayCombobox.IsEnabled = false; // дни недоступны для выбора года и месяца
        }
        private void YearCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DayCombobox.IsEnabled = true;
            DayCombobox.Items.Clear();
            int year = (int)YearCombobox.SelectedItem;
            int month = MonthCombobox.SelectedIndex + 1;
            int daysInMonth = DateTime.DaysInMonth(year, month);
            for (int i= 1; i <= daysInMonth; i++)
            {
                DayCombobox.Items.Add(i);
            }
        }
        private void MonthCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (YearCombobox.SelectedItem == null)
            {
                DayCombobox.IsEnabled = false;
                return;
            }
            DayCombobox.IsEnabled = true;
            DayCombobox.Items.Clear();
            int year = (int)YearCombobox.SelectedItem;
            int month = (int)MonthCombobox.SelectedItem;
            int daysInMonth = DateTime.DaysInMonth(year, month);
            for (int i = 1; i <= daysInMonth; i++)
            {
                DayCombobox.Items.Add(i);
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedMonth = -1;
            if (MonthCombobox.SelectedItem != null)
                selectedMonth = (int)MonthCombobox.SelectedItem;
            if (YearCombobox.SelectedItem == null || selectedMonth == -1 || DayCombobox.SelectedItem == null)
            {
                MessageBox.Show("Please select a valid date");
                return;
            }
            DateTime selectedDate = new DateTime((int)YearCombobox.SelectedItem, selectedMonth, (int)DayCombobox.SelectedItem);
            TimeSpan timeSince = DateTime.Now - selectedDate;
            int years = timeSince.Days / 365;
            int months = timeSince.Days % 365 / 30;
            int days = timeSince.Days % 365 % 30;
            MessageBox.Show($"{years} Years, {months} Months, {days} Days have passed since {selectedDate.ToShortDateString()}");
        }
    }
}
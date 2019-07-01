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

namespace Equipment_Log {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private readonly DateTime minDate = new DateTime(2019, 6, 26, 0, 0, 0, 0);
        public MainWindow() {
            InitializeComponent();
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject {
            if (depObj != null) {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++) {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T) {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child)) {
                        yield return childOfChild;
                    }
                }
            }
        }

        /// <summary>
        /// Disables all TextBoxes in the current log
        /// Called when user submits the log so changes cannot be made afterwards
        /// </summary>
        private void EnabledTextBoxes(Boolean enabled, Boolean visible) {
            var controls = FindVisualChildren<TextBox>(this);
            foreach (TextBox text in controls) {
                text.IsReadOnly = !enabled;
                if (!visible)
                    text.Visibility = Visibility.Hidden;
                else
                    text.Visibility = Visibility.Visible;
            }
        }
        private void EnabledDatePickers(Boolean enabled) {
            var controls = FindVisualChildren<DatePicker>(this);
            foreach (DatePicker picker in controls) {
                if (!picker.Name.Equals("navDate")) {
                    picker.IsEnabled = enabled;
                }
            }

        }
        private void Submit(object sender, RoutedEventArgs e) {
            string message = "Are you sure you want to submit?\nYou will not be able to edit the form once it is submitted";
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show( message, "Submission Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
                Console.WriteLine("Submitted");
        }

        private void NavPrev_Click(object sender, RoutedEventArgs e) {
            var datePickers = FindVisualChildren<DatePicker>(this);
            foreach(DatePicker picker in datePickers) {
                if (picker.Name == "navDate")
                    picker.SelectedDate = picker.SelectedDate.Value.AddDays(-1);
            }
        }

        private void NavNext_Click(object sender, RoutedEventArgs e) {
            var datePickers = FindVisualChildren<DatePicker>(this);
            foreach (DatePicker picker in datePickers) {
                if (picker.Name == "navDate")
                    picker.SelectedDate = picker.SelectedDate.Value.AddDays(1);
            }
        }

        private void NavDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e) {
            var buttons = FindVisualChildren<Button>(this);
            foreach (Button button in buttons) {
                if (button.Name == "navPrev") {
                    button.IsEnabled = !((DatePicker)sender).SelectedDate.Value.Equals(minDate);
                }
                if (button.Name == "navNext") {
                    button.IsEnabled = !((DatePicker)sender).SelectedDate.Value.Equals(DateTime.Today);
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (((ComboBox)sender).SelectedValue.Equals("Shift...")) {
                EnabledTextBoxes(false,true);
                EnabledDatePickers(false);
            }
            else {
                EnabledTextBoxes(true,true);
                EnabledDatePickers(true);
            }
        }
    }
}

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
        private void DisableComponents() {
            Console.WriteLine("Disable Event Fired");
            var lstControl = FindVisualChildren<TextBox>(this);

            foreach (TextBox control in lstControl) {
                ///Disable Control if it is a textbox
                control.IsReadOnly = true;
            }
        }

        private void EnableComponents() {
            Console.WriteLine("Enable Event Fired");

            var lstControl = FindVisualChildren<TextBox>(this);

            foreach (TextBox control in lstControl) {
                //Renable Textboxes
                control.IsReadOnly = false;
            }
        }

        private void Submit(object sender, RoutedEventArgs e) {

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

            //Disable Previous Navigation Button if at the Minimum Date
            if (((DatePicker)sender).SelectedDate.Value.Equals(minDate)) {
                var buttons = FindVisualChildren<Button>(this);
                foreach (Button button in buttons) {
                    if (button.Name == "navPrev") {
                        button.IsEnabled = false;
                    }
                }
            }
            else { //Make sure previous button is enabled otherwise
                var buttons = FindVisualChildren<Button>(this);
                foreach (Button button in buttons) {
                    if (button.Name == "navPrev") {
                        button.IsEnabled = true;
                    }
                }
            }
            //Disable next navigation button if the date is set to today
            if (((DatePicker)sender).SelectedDate.Value.Equals(DateTime.Today)) {
                var buttons = FindVisualChildren<Button>(this);
                foreach (Button button in buttons) {
                    if (button.Name == "navNext") {
                        button.IsEnabled = false;
                    }
                }
            }
            else { //enable otherwise
                var buttons = FindVisualChildren<Button>(this);
                foreach (Button button in buttons) {
                    if (button.Name == "navNext") {
                        button.IsEnabled = true;
                    }
                }
            }
        }

    }
}

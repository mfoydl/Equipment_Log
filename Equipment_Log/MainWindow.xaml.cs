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
            ContentRendered += new EventHandler(Page_Load);
        }

        protected void Page_Load(object sender, EventArgs e) {
            LogViewModel.FindShift();
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
        private void EnabledTextBoxes(Boolean enabled) {
            var controls = FindVisualChildren<TextBox>(this);
            foreach (TextBox text in controls) {
                text.IsReadOnly = !enabled;
            }
        }
        private void Submit(object sender, RoutedEventArgs e) {
            string message = "Are you sure you want to submit?\nYou will not be able to edit the form once it is submitted";
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show( message, "Submission Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
                Console.WriteLine("Submitted");
        }

        private void NavPrev_Click(object sender, RoutedEventArgs e) {
            var shiftBox=FindVisualChildren<ComboBox>(this);
            foreach(ComboBox box in shiftBox) {
                if(box.Name.Equals("shiftBox")&&box.SelectedIndex!=1) {
                    box.SelectedIndex -= 1;
                }
                else {
                    var datePickers = FindVisualChildren<DatePicker>(this);
                    foreach (DatePicker picker in datePickers) {
                        if (picker.Name == "navDate")
                            picker.SelectedDate = picker.SelectedDate.Value.AddDays(-1);
                    }
                    box.SelectedIndex = box.Items.Count - 1;
                }
            }


            
        }

        private void NavNext_Click(object sender, RoutedEventArgs e) {
            var shiftBox = FindVisualChildren<ComboBox>(this);
            foreach (ComboBox box in shiftBox) {
                if (box.Name.Equals("shiftBox") && box.SelectedIndex != box.Items.Count-1) {
                    box.SelectedIndex += 1;
                }
                else {
                    var datePickers = FindVisualChildren<DatePicker>(this);
                    foreach (DatePicker picker in datePickers) {
                        if (picker.Name == "navDate")
                            picker.SelectedDate = picker.SelectedDate.Value.AddDays(1);
                    }
                    box.SelectedIndex = 1;
                }
            }
        }

        private void NavDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e) {
            var buttons = FindVisualChildren<Button>(this);
            var comboboxes = FindVisualChildren<ComboBox>(this);
            ;
            foreach(ComboBox box in comboboxes) {
                if (box.Name.Equals("shiftBox")) {
                    ComboBox shiftBox = box;
                }
            }
            foreach (Button button in buttons) {
                if (button.Name == "navPrev") {
                    button.IsEnabled = !(shiftBox.SelectedIndex == 1 && ((DatePicker)sender).SelectedDate.Value.Equals(minDate));
                }
                if (button.Name == "navNext") {
                    button.IsEnabled = !(shiftBox.SelectedIndex == shiftBox.Items.Count-1 && ((DatePicker)sender).SelectedDate.Value.Equals(DateTime.Today));
                }
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        }
        
    }
}

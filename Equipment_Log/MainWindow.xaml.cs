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
        private DateTime currentDate;
        private DatePicker mainDate;
        Boolean loaded = false;
        public MainWindow() {
            InitializeComponent();
            ContentRendered += new EventHandler(Page_Load);
        }

        protected void Page_Load(object sender, EventArgs e) {
            LogViewModel.FindShift();
            loaded = true;
            currentDate = DateTime.Today;
            
            var datepicker = FindVisualChildren<DatePicker>(this);
            foreach(DatePicker control in datepicker) {
                if (control.Name.Equals("navDate")) {
                    mainDate = control;
                }
            }
            mainDate.SelectedDate = currentDate;

            EnabledNavButtons();
            LogViewModel.InitialLoad(currentDate, LogViewModel.FindShift());
            EnabledTextBoxes(!LogViewModel.CurrentLog.Submitted);
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
        private void EnabledNavButtons() {
            var buttons = FindVisualChildren<Button>(this);
            foreach (Button button in buttons) {
                if (button.Name == "navPrev") {
                    button.IsEnabled = !(shiftBox.SelectedIndex == 1 && currentDate.Equals(minDate));
                }
                if (button.Name == "navNext") {
                    button.IsEnabled = !(shiftBox.SelectedIndex == shiftBox.Items.Count - 1 && currentDate.Equals(DateTime.Today));
                }
            }
        }
        private void Submit(object sender, RoutedEventArgs e) {
            string message = "Are you sure you want to submit?\nYou will not be able to edit the form once it is submitted";
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show( message, "Submission Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes) {
                if (LogViewModel.CurrentLog.Submitted == false) {
                    LogViewModel.Submit();
                }
                else {
                    //allow post-submit updates?
                }
            }
                
            var buttons = FindVisualChildren<Button>(this);
            foreach (Button button in buttons) {
                if (button.Name == "submit") {
                    button.IsEnabled = false;
                }
            }
        }

        private void NavPrev_Click(object sender, RoutedEventArgs e) {
            var shiftBox=FindVisualChildren<ComboBox>(this);
            foreach(ComboBox box in shiftBox) {
                if (box.Name.Equals("shiftBox")) {
                    string shift;
                    if (box.SelectedIndex != 0) {
                        ComboBoxItem item = (ComboBoxItem)box.Items.GetItemAt(box.SelectedIndex-1);
                        shift = item.Content.ToString();
                    }
                    else {
                        currentDate = currentDate.AddDays(-1);
                        ComboBoxItem item = (ComboBoxItem)box.Items.GetItemAt(box.Items.Count-1);
                        shift= item.Content.ToString();
                        mainDate.SelectedDate = currentDate;
                    }
                    LogViewModel.Load(currentDate,shift);
                    EnabledNavButtons();
                    EnabledTextBoxes(!LogViewModel.CurrentLog.Submitted);
                }
            }


            
        }

        private void NavNext_Click(object sender, RoutedEventArgs e) {
            var shiftBox = FindVisualChildren<ComboBox>(this);
            foreach (ComboBox box in shiftBox) {
                if (box.Name.Equals("shiftBox")) {
                    DateTime date;
                    string shift;
                    if (box.SelectedIndex != box.Items.Count - 1) {
                        ComboBoxItem item = (ComboBoxItem)box.Items.GetItemAt(box.SelectedIndex + 1);
                        shift = item.Content.ToString();
                    }
                    else {
                        currentDate = currentDate.AddDays(1);
                        ComboBoxItem item = (ComboBoxItem)box.Items.GetItemAt(0);
                        shift = item.Content.ToString();
                        mainDate.SelectedDate = currentDate;
                    }
                    LogViewModel.Load(currentDate,shift);
                    EnabledNavButtons();
                    EnabledTextBoxes(!LogViewModel.CurrentLog.Submitted);
                }
            }
        }

        private void NavDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e) {
            var comboboxes = FindVisualChildren<ComboBox>(this);
            foreach(ComboBox box in comboboxes) {
                if (box.Name.Equals("shiftBox")) {
                    ComboBox shiftBox = box;
                }
            }
            if (loaded) {
                string shift = shiftBox.Text;
                DateTime date = (DateTime)((DatePicker)sender).SelectedDate;
                LogViewModel.Load(date, shift);
                currentDate = date;
            }
            EnabledNavButtons();
            EnabledTextBoxes(!LogViewModel.CurrentLog.Submitted);
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            Boolean submitted = LogViewModel.CurrentLog.Submitted;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) {
            
            if (Keyboard.Modifiers == ModifierKeys.Control  && e.Key == Key.U) {
                Console.WriteLine("Unlock");
                EnabledTextBoxes(true);
                var buttons = FindVisualChildren<Button>(this);
                foreach (Button button in buttons) {
                    if (button.Name == "submit") {
                        button.IsEnabled = true;
                    }
                }
            }
        }
    }
}

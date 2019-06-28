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
        private void DisableComponents(object sender, RoutedEventArgs e) {
            Console.WriteLine("Disable Event Fired");
            var lstControl = FindVisualChildren<TextBox>(this);

            foreach (TextBox control in lstControl) {
                ///Disable Control if it is a textbox
                control.IsReadOnly = true;
            }
        }

        private void EnableComponents(object sender, RoutedEventArgs e) {
            Console.WriteLine("Enable Event Fired");

            var lstControl = FindVisualChildren<TextBox>(this);

            foreach (TextBox control in lstControl) {
                //Renable Textboxes
                control.IsReadOnly = false;
            }
        }

        private void TestEvent(object sender, RoutedEventArgs e) {
      
        }
    }
}

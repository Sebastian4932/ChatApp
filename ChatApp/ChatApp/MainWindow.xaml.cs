using ChatApp.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
using static ChatApp.src.ViewModel;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();


        }
        public void Show_Users(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.Windows.OfType<ChooseWindow>().FirstOrDefault();
            if (window == null)
            {
                window = new ChooseWindow();
                window.Show();
            }
            else
                window.Activate();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }


        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void buttonMaxmize_Click(object sender, RoutedEventArgs e)
        {

            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
                WindowState = WindowState.Normal;
        }

      
        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as ViewModel;
            if (viewModel != null)
            {
                await viewModel.SendMessageAsync(MessageTextBox.Text);
                MessageTextBox.Clear();
            }
        }

        private async void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var viewModel = DataContext as ViewModel;
                if (viewModel != null)
                {
                    await viewModel.SendMessageAsync(MessageTextBox.Text);
                    MessageTextBox.Clear();
                }
            }
        }

        private void New_Session(object sender, RoutedEventArgs e)
        {
            var appPath = Assembly.GetExecutingAssembly().Location;
            Process.Start(new ProcessStartInfo(appPath) { UseShellExecute = true });
        }
    }
}


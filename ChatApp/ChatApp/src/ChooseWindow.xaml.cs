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
using System.Windows.Shapes;
using static ChatApp.src.ViewModel;

namespace ChatApp.src
{
    /// <summary>
    /// Interaction logic for ChooseWindow.xaml
    /// </summary>
    public partial class ChooseWindow : Window
    {
             
        public ChooseWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
        private void SwitchUser_ClickA(object sender, RoutedEventArgs e)
        {
            var newViewModel = new ViewModel();
            newViewModel.SelectedUser = newViewModel.UserA;

            var window = new MainWindow();
            window.DataContext = newViewModel;
            window.Show();
        }
        private void SwitchUser_ClickB(object sender, RoutedEventArgs e)
        {
            var newViewModel = new ViewModel();
            newViewModel.SelectedUser = newViewModel.UserB;
           
            var window = new MainWindow();
            window.DataContext = newViewModel;
            window.Show();
        }
        private void SwitchUser_ClickC(object sender, RoutedEventArgs e)
        {
            var newViewModel = new ViewModel();
            newViewModel.SelectedUser = newViewModel.UserC;

            var window = new MainWindow();
            window.DataContext = newViewModel;
            window.Show();

        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

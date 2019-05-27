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
using System.Windows.Shapes;

namespace UI_QLTV
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LblGuessLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("OK");
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("OK1");
        }
    }
}

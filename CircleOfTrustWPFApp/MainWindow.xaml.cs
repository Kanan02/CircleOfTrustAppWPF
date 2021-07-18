using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CircleOfTrustWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new FriendsDataSource();
        }

   

        private void Star_Click(object sender, RoutedEventArgs e)
        {

            int grade =int.Parse((sender as ToggleButton).Content.ToString());
            int i = 0;
            foreach (var item in ((sender as ToggleButton).Parent as StackPanel).Children)
            {
                if (item is ToggleButton )
                {
                    if (int.Parse((item as ToggleButton).Content.ToString())<=grade)
                    {
                        (item as ToggleButton).IsChecked = true;

                        (DataContext as FriendsDataSource).Friends.Where(x => x.Name == (((sender as ToggleButton).Parent as StackPanel).Children[0] as Label).Content.ToString()).ElementAt(0).Stars[i] = true;

                    }
                    else
                    {
                        (item as ToggleButton).IsChecked = false;
                        (DataContext as FriendsDataSource).Friends.Where(x => x.Name == (((sender as ToggleButton).Parent as StackPanel).Children[0] as Label).Content.ToString()).ElementAt(0).Stars[i] = false;

                    }
                    i++;
                }
            }

        }


    }
}

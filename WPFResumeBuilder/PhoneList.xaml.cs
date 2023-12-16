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

namespace WPFResumeBuilder
{
    /// <summary>
    /// Interaction logic for PhoneList.xaml
    /// </summary>
    public partial class PhoneList : Window
    {
        DBHandler dBHandler = DBHandler.Instance;
        public PhoneList()
        {
            InitializeComponent();
            User user = dBHandler.createUserObj();
            PhoneListContainer.ItemsSource = user.Phones;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PhoneEdit pe = new PhoneEdit(null);
            pe.ShowDialog();
            PhoneListContainer.ItemsSource = null;
            User user = dBHandler.createUserObj();
            PhoneListContainer.ItemsSource = user.Phones;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            PhoneEdit pe = new PhoneEdit(btn.DataContext.ToString());
            pe.ShowDialog();
            PhoneListContainer.ItemsSource = null;
            User user = dBHandler.createUserObj();
            PhoneListContainer.ItemsSource = user.Phones;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            dBHandler.deletePhone(btn.DataContext.ToString());
            PhoneListContainer.ItemsSource = null;
            User user = dBHandler.createUserObj();
            PhoneListContainer.ItemsSource = user.Phones;
        }
    }
}

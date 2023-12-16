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
    /// Interaction logic for EduList.xaml
    /// </summary>
    public partial class EduList : Window
    {
        DBHandler dBHandler = DBHandler.Instance;
        public EduList()
        {
            InitializeComponent();
            User user = dBHandler.createUserObj();
            EduListContainer.ItemsSource = user.Education;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EduEdit ee = new EduEdit(null);
            ee.ShowDialog();
            EduListContainer.ItemsSource = null;
            User user = dBHandler.createUserObj();
            EduListContainer.ItemsSource = user.Education;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            EduEdit ee = new EduEdit(btn.DataContext.ToString());
            ee.ShowDialog();
            EduListContainer.ItemsSource = null;
            User user = dBHandler.createUserObj();
            EduListContainer.ItemsSource = user.Education;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            dBHandler.deleteSchool(btn.DataContext.ToString());
            EduListContainer.ItemsSource = null;
            User user = dBHandler.createUserObj();
            EduListContainer.ItemsSource = user.Education;
        }
    }
}

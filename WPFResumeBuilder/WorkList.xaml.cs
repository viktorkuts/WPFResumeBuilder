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
    public partial class WorkList : Window
    {
        DBHandler dBHandler = DBHandler.Instance;
        public WorkList()
        {
            InitializeComponent();
            User user = dBHandler.createUserObj();
            WorkListContainer.ItemsSource = user.Work;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WorkEdit ee = new WorkEdit(null);
            ee.ShowDialog();
            WorkListContainer.ItemsSource = null;
            User user = dBHandler.createUserObj();
            WorkListContainer.ItemsSource = user.Work;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            WorkEdit ee = new WorkEdit(btn.DataContext.ToString());
            ee.ShowDialog();
            WorkListContainer.ItemsSource = null;
            User user = dBHandler.createUserObj();
            WorkListContainer.ItemsSource = user.Work;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            dBHandler.deleteWork(btn.DataContext.ToString());
            WorkListContainer.ItemsSource = null;
            User user = dBHandler.createUserObj();
            WorkListContainer.ItemsSource = user.Work;
        }
    }
}

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
    /// Interaction logic for PersonalInfoView.xaml
    /// </summary>
    public partial class PersonalInfoView : Window
    {
        DBHandler dBHandler = DBHandler.Instance;
        public PersonalInfoView()
        {
            InitializeComponent();
            User user = dBHandler.createUserObj();
            this.DataContext = user;
            PhoneListContainer.ItemsSource = user.Phones;
        }
        
        private void PhoneBTN_Click(object sender, RoutedEventArgs e)
        {
            PhoneList phoneList = new PhoneList();
            phoneList.ShowDialog();
            PhoneListContainer.ItemsSource = null;
            User user = dBHandler.createUserObj();
            this.DataContext = user;
            PhoneListContainer.ItemsSource = user.Phones;
        }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {
            dBHandler.updatePersonalInfo(firstNameTextBlock.Text, lastNameTextBlock.Text, addressTextBlock.Text);
            this.Close();
        }
    }
}

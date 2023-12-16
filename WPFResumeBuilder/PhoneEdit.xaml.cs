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
    /// Interaction logic for PhoneEdit.xaml
    /// </summary>
    public partial class PhoneEdit : Window
    {
        DBHandler dBHandler = DBHandler.Instance;
        string oldPhone;
        public PhoneEdit(string phone)
        {
            InitializeComponent();
            if(phone != null)
            {
                PhoneInput.Text = phone;
                oldPhone = phone;
            }
            else
            {
                oldPhone = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dBHandler.updatePhone(oldPhone, PhoneInput.Text);
            this.Close();
        }
    }
}

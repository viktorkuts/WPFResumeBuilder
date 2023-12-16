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
    public partial class EduEdit : Window
    {
        DBHandler dBHandler = DBHandler.Instance;
        string oldEdu;
        public EduEdit(string edu)
        {
            InitializeComponent();
            if (edu != null)
            {
                EduInput.Text = edu;
                oldEdu = edu;
            }
            else
            {
                oldEdu = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dBHandler.updateSchool(oldEdu, EduInput.Text);
            this.Close();
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows;

namespace WPFResumeBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBHandler dBHandler = DBHandler.Instance;
        public MainWindow()
        {
            InitializeComponent();
            refreshInfo();
        }
        private void refreshInfo()
        {
            this.DataContext = null;
            PhoneListContainer.ItemsSource = null;
            EducationListContainer.ItemsSource = null;
            WorkListContainer.ItemsSource = null;
            User user = dBHandler.createUserObj();
            this.DataContext = user;
            PhoneListContainer.ItemsSource = user.Phones;
            EducationListContainer.ItemsSource = user.Education;
            WorkListContainer.ItemsSource = user.Work;
        }

        private void EditPersonalInfo_Click(object sender, RoutedEventArgs e)
        {
            PersonalInfoView personalInfoView = new PersonalInfoView();
            personalInfoView.ShowDialog();
            refreshInfo();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EduList ee = new EduList();
            ee.ShowDialog();
            refreshInfo();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WorkList wl = new WorkList();
            wl.ShowDialog();
            refreshInfo();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            User user = dBHandler.createUserObj();
            using (PdfDocument doc = new PdfDocument())
            {
                PdfPage page = doc.Pages.Add();
                PdfGraphics graphics = page.Graphics;
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
                graphics.DrawString("Resume", font, PdfBrushes.Black, new PointF(0, 0));
                graphics.DrawString("Name: " + user.FirstName + " " + user.LastName, font, PdfBrushes.Black, new PointF(0, 20));
                graphics.DrawString("Address: " + user.Address, font, PdfBrushes.Black, new PointF(0, 40));
                user.Phones.ForEach(delegate (string phone)
                {
                    graphics.DrawString("Phone: " + phone, font, PdfBrushes.Black, new PointF(0, 60));
                });
                user.Education.ForEach(delegate (string edu)
                {
                    graphics.DrawString("School: " + edu, font, PdfBrushes.Black, new PointF(0, 80));
                });
                user.Work.ForEach(delegate (string work)
                {
                    graphics.DrawString("Work: " + work, font, PdfBrushes.Black, new PointF(0, 100));
                });
                doc.Save("Resume.pdf");
            }
        }
    }
}

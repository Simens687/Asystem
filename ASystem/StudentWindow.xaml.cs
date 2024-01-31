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

namespace ASystem
{
    public partial class StudentWindow : Window
    {
        public StudentWindow()
        {
            InitializeComponent();
            FrameStudent.Content = new SchedulePage();
            BtnSchedule.IsEnabled = false;
        }

        private void ActSchedule(object sender, RoutedEventArgs e)
        {

            FrameStudent.Content = new SchedulePage();
            BtnSchedule.IsEnabled = false;
            BtnGrade.IsEnabled = true;
        }

        private void ActGrade(object sender, RoutedEventArgs e)
        {
            FrameStudent.Content = new GradePage();
            BtnSchedule.IsEnabled = true;
            BtnGrade.IsEnabled = false;
        }
    }
}

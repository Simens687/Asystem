using ASystem.ASystemDBDataSetTableAdapters;
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

namespace ASystem
{
    public partial class SchedulePage : Page
    {
        School_day_subjectsTableAdapter school_Day_ = new School_day_subjectsTableAdapter();
        public SchedulePage()
        {
            InitializeComponent();
            ScheduleGrid.ItemsSource = school_Day_.GetData();
        }
    }
}

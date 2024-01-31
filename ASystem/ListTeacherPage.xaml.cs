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
    public partial class ListTeacherPage : Page
    {
        Students_in_groupTableAdapter students_In = new Students_in_groupTableAdapter();
        StudentsTableAdapter students = new StudentsTableAdapter();
        UsersTableAdapter users = new UsersTableAdapter();

        private int student_id;
        private int user_id;
        private int ID;
        public ListTeacherPage(int group_id)
        {
            InitializeComponent();

            StudentsGrid.ItemsSource = students_In.GetData(group_id);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

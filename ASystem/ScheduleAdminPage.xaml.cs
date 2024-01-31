using ASystem.ASystemDBDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class ScheduleAdminPage : Page
    {
        SubjectsTableAdapter subjects = new SubjectsTableAdapter();
        Day_in_scheduleTableAdapter day_In_Schedule = new Day_in_scheduleTableAdapter();
        TeachersTableAdapter teachers = new TeachersTableAdapter();
        School_day_subjectsTableAdapter school_Day_ = new School_day_subjectsTableAdapter();

        private int group_id;
        private int registrated_admin_id;

        private int ID;
        public ScheduleAdminPage(int group_id, int registrated_admin_id)
        {
            InitializeComponent();
            this.group_id = group_id;
            this.registrated_admin_id = registrated_admin_id;

            CbxSubject.ItemsSource = subjects.GetData();
            CbxSubject.DisplayMemberPath = "name";

            CbxDay.ItemsSource = day_In_Schedule.GetData();
            CbxDay.DisplayMemberPath = "date_";
            CbxDay.ItemStringFormat = "dd-MM-yyyy";

            CbxTeacher.ItemsSource = teachers.GetData();
            CbxTeacher.DisplayMemberPath = "full_name";

            ScheduleGrid.ItemsSource = school_Day_.GetData();
        }

        private void ActCreate(object sender, RoutedEventArgs e)
        {
            if (CbxDay.SelectedItem is DataRowView selectedRow)
            {
                int day_id = Convert.ToInt32(selectedRow["day_id"]);

                if (CbxTeacher.SelectedItem is DataRowView selectedRoww)
                {
                    int teacher_id = Convert.ToInt32(selectedRoww["teacher_id"]);

                    if (CbxSubject.SelectedItem is DataRowView selectedRowww)
                    {
                        int subject_id = Convert.ToInt32(selectedRowww["subject_id"]);

                        school_Day_.InsertQuery(subject_id, day_id, teacher_id, Convert.ToInt32(TbxNumberSubject.Text));

                        ScheduleGrid.ItemsSource = school_Day_.GetData();
                    }
                }
            }
        }

        private void SelectGrid(object sender, SelectionChangedEventArgs e)
        {
            ID = Convert.ToInt32((ScheduleGrid.SelectedItem as DataRowView).Row[0]);
        }

        private void ActDelete(object sender, RoutedEventArgs e)
        {
            school_Day_.DeleteQuery(ID);
        }
    }
}

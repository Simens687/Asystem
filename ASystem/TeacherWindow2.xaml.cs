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
using System.Windows.Shapes;

namespace ASystem
{
    public partial class TeacherWindow2 : Window
    {
        private int group_id;
        GroupsTableAdapter groups = new GroupsTableAdapter();
        public TeacherWindow2(int group_id)
        {
            InitializeComponent();
            FrameTeacher.Content = new MarkTeacherPage();
            BtnMark.IsEnabled = false;

            this.group_id = group_id;
            TbkGroup.Text = "Группа: " + groups.GetGroupName(group_id).ToString();
        }

        private void ActList(object sender, RoutedEventArgs e)
        {
            FrameTeacher.Content = new ListTeacherPage(group_id);
            BtnList.IsEnabled = false;
            BtnMark.IsEnabled = true;
        }

        private void ActMark(object sender, RoutedEventArgs e)
        {
            FrameTeacher.Content = new MarkTeacherPage();
            BtnList.IsEnabled = true;
            BtnMark.IsEnabled = false;
        }
    }
}

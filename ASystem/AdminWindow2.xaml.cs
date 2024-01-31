using ASystem.Admin;
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
    public partial class AdminWindow2 : Window
    {
        GroupsTableAdapter groups = new GroupsTableAdapter();
        private int group_id = 1;
        private int registrated_admin_id = 1;
        public AdminWindow2(int group_id)
        {
            InitializeComponent();
            FrameAdmin.Content = new ScheduleAdminPage(group_id, registrated_admin_id);
            BtnSchedule.IsEnabled = false;
            TbkGroup.Text = "Группа: " + groups.GetGroupName( group_id ).ToString();
            this.group_id = group_id;
        }

        private void ActList(object sender, RoutedEventArgs e)
        {
            FrameAdmin.Content = new ListAdminPage(group_id, registrated_admin_id);
            BtnList.IsEnabled = false;
            BtnSchedule.IsEnabled = true;
        }

        private void ActSchedule(object sender, RoutedEventArgs e)
        {
            FrameAdmin.Content = new ScheduleAdminPage(group_id, registrated_admin_id);
            BtnList.IsEnabled = true;
            BtnSchedule.IsEnabled = false;
        }
    }
}

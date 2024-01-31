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
using System.Windows.Shapes;

namespace ASystem
{
    public partial class TeacherWindow1 : Window
    {
        GroupsTableAdapter groups = new GroupsTableAdapter();

        public TeacherWindow1()
        {
            InitializeComponent();
            GroupGrid.ItemsSource = groups.GetData();
        }

        private void ActGo(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)GroupGrid.SelectedItem;

            if (selectedRow != null)
            {
                object columnValue = selectedRow["group_id"];

                TeacherWindow2 teacherWindow2 = new TeacherWindow2(Convert.ToInt32(columnValue));

                teacherWindow2.Show();

                MessageBox.Show($"Значение в выбранной ячейке столбца: {columnValue.ToString()}");
            }
            else
            {
                MessageBox.Show("Выберите элемент из таблицы.");
            }
        }
    }
}

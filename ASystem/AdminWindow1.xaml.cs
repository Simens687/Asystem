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
    public partial class AdminWindow1 : Window
    {
        GroupsTableAdapter groups = new GroupsTableAdapter();
        private int registrated_admin_id;
        public AdminWindow1(int registrated_admin_id)
        {
            InitializeComponent();
            GroupGrid.ItemsSource = groups.GetData();
            this.registrated_admin_id = registrated_admin_id;
        }

        private void ActCreate(object sender, RoutedEventArgs e)
        {
            if (TbxGroup.Text != null || TbxGroup.Text != "")
            {
                groups.InsertQuery(TbxGroup.Text, registrated_admin_id);
                GroupGrid.ItemsSource = groups.GetData();
            }
        }

        private void ActGo(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)GroupGrid.SelectedItem;

            if (selectedRow != null)
            {
                object columnValue = selectedRow["group_id"];

                /*AdminWindow2 adminWindow2 = new AdminWindow2(Convert.ToInt32(columnValue));
                adminWindow2.Show();*/

                MessageBox.Show($"Значение в выбранной ячейке столбца: {columnValue.ToString()}");
            }
            else
            {
                MessageBox.Show("Выберите элемент из таблицы.");
            }
        }
    }
}

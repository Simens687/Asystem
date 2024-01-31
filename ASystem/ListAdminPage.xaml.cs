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
using static ASystem.ASystemDBDataSet;

namespace ASystem.Admin
{
    public partial class ListAdminPage : Page
    {
        Students_in_groupTableAdapter students_In = new Students_in_groupTableAdapter();
        StudentsTableAdapter students = new StudentsTableAdapter();
        UsersTableAdapter users = new UsersTableAdapter();

        private int group_id;
        private int registrated_admin_id;

        private int student_id;
        private int user_id;
        private int ID;
        public ListAdminPage(int group_id, int registrated_admin_id)
        {
            InitializeComponent();
            this.group_id = group_id;
            this.registrated_admin_id = registrated_admin_id;

            StudentsGrid.ItemsSource = students_In.GetData(group_id);
        }

        private void ActCreate(object sender, RoutedEventArgs e)
        {
            users.InsertQuery(TbxLogin.Text, TbxPass.Text, TbxEmail.Text);
            List<object> list_users = new List<object>(users.GetData());
            var last_user = list_users[list_users.Count-1];
            int last_user_id = (int)last_user.GetType().GetProperty("user_id").GetValue(last_user, null);

            students.InsertQuery(TbxFIO.Text, last_user_id, registrated_admin_id);

            List<object> list_students = new List<object>(students.GetData());
            var last_student = list_students[list_students.Count-1];
            int last_student_id = (int)last_student.GetType().GetProperty("student_id").GetValue(last_student, null);

            students_In.InsertQuery(group_id, last_student_id, 1);

            StudentsGrid.ItemsSource = students_In.GetData(group_id);
        }

        private void SelectStudent(object sender, SelectionChangedEventArgs e)
        {
            ID = Convert.ToInt32((StudentsGrid.SelectedItem as DataRowView).Row[0]);

                DataTable studentInfoTable = students_In.GetStudentInfo(ID);

                if (studentInfoTable.Rows.Count > 0)
                {
                    TbxFIO.Text = studentInfoTable.Rows[0]["StudentFullName"].ToString();
                    TbxLogin.Text = studentInfoTable.Rows[0]["Login"].ToString();
                    TbxPass.Text = studentInfoTable.Rows[0]["Password"].ToString();
                    TbxEmail.Text = studentInfoTable.Rows[0]["Email"].ToString();
                }
                else
                {
                    MessageBox.Show("Данные не найдены.");
                    TbxFIO.Text = "";
                    TbxLogin.Text = "";
                    TbxPass.Text = "";
                    TbxEmail.Text = "";
                }

                student_id = Convert.ToInt32(studentInfoTable.Rows[0]["student_id"]);
                user_id = Convert.ToInt32(studentInfoTable.Rows[0]["user_id"]);

                MessageBox.Show(user_id.ToString());
        }

        private void ActUpdate(object sender, RoutedEventArgs e)
        {
            users.UpdateQuery(TbxLogin.Text.ToString(), TbxPass.Text.ToString(), TbxEmail.Text.ToString(), user_id);

            students.UpdateQuery(TbxFIO.Text.ToString(), student_id, registrated_admin_id, user_id); 

            StudentsGrid.ItemsSource = students_In.GetData(group_id);
        }

        private void ActDelete(object sender, RoutedEventArgs e)
        {
            students_In.DeleteQuery(ID);
            StudentsGrid.ItemsSource = students_In.GetData(group_id);
        }
    }
}

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
using ASystem.ASystemDBDataSetTableAdapters;

namespace ASystem
{
    public partial class AuthWindow : Window
    {
        List<string> logins = new List<string>();
        List<string> passs = new List<string>();
        List<int> usersID = new List<int>();
        

        public AuthWindow()
        {
            InitializeComponent();

            GetLoginPass();
        }

        private void GetLoginPass()
        {
            UsersTableAdapter users = new UsersTableAdapter();
            DataTable usersTable = users.GetData();

            foreach (DataRow row in usersTable.Rows)
            {
                string login = row["login_"].ToString();
                string password = row["password_"].ToString();
                int ID = Convert.ToInt32(row["user_id"]);

                logins.Add(login);
                passs.Add(password);
                usersID.Add(ID);
            }
        }

        private void Enter(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < usersID.Count; i++)
            {
                if (TbxLogin.Text == logins[i])
                {
                    if (TbxPass.Password == passs[i])
                    {
                        Who_is_your_role(i+1);
                    }
                }
            }
        }

        private void Who_is_your_role(int i)
        {
            List <int> idsInAdmin = new List<int>();
            List<int> idsInStudent = new List<int>();
            List<int> idsInTeacher = new List<int>();

            AdminsTableAdapter admins = new AdminsTableAdapter();
            StudentsTableAdapter students = new StudentsTableAdapter();
            TeachersTableAdapter teachers = new TeachersTableAdapter();

            DataTable adminsTable = admins.GetData();
            DataTable studentsTable = students.GetData();
            DataTable teachersTable = teachers.GetData();

            foreach (DataRow row in adminsTable.Rows)
            {
                int ID = Convert.ToInt32(row["user_id"]);

                idsInAdmin.Add(ID);
            }

            foreach (DataRow row in studentsTable.Rows)
            {
                int ID = Convert.ToInt32(row["user_id"]);

                idsInStudent.Add(ID);
            }

            foreach (DataRow row in teachersTable.Rows)
            {
                int ID = Convert.ToInt32(row["user_id"]);

                idsInTeacher.Add(ID);
            }

            for (int j = 0; j < idsInAdmin.Count; j++)
            {
                if (i == idsInAdmin[j])
                {
                    AdminWindow1 window = new AdminWindow1(i);
                    window.Show();
                    this.Close();
                }
            }

            for (int j = 0; j < idsInStudent.Count; j++)
            {
                if (i == idsInStudent[j])
                {
                    StudentWindow window = new StudentWindow();
                    window.Show();
                    this.Close();
                 
                }
            }

            for (int j = 0; j < idsInTeacher.Count; j++)
            {
                if (i == idsInTeacher[j])
                {
                    TeacherWindow1 window = new TeacherWindow1();
                    window.Show();
                    this.Close();
                }
            }
        }
    }
}

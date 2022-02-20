using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test20._2._22
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Fill_ListBox();
        }

        private void Fill_ListBox()
        {
            collegeEntities cl = new collegeEntities();
            List<Course> courses = cl.Courses.ToList();
            foreach (Course item in courses)
            {
                listBox1.Items.Add(item.CourseName);
            }
        }

        private void student_screenBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.student_screenBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet_College);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet_College.Student_screen' table. You can move, or remove it, as needed.
            this.student_screenTableAdapter.Fill(this.dataSet_College.Student_screen);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            collegeEntities cl = new collegeEntities();
            List<Student> students = cl.Students.ToList();
            Student_screen student_s = new Student_screen();
            student_s.student_id =Convert.ToInt32(textBox1.Text);
            student_s.student_id_num = textBox2.Text;
            student_s.course = listBox1.SelectedItem.ToString();
            student_s.registration_date = dateTimePicker1.Value;
            student_s.grade = Convert.ToInt32(textBox3.Text);
            foreach (Student item in students)
            {
                if (item.IdNum == student_s.student_id_num)
                {
                    if (item.RegisterDate.Month != student_s.registration_date.Month - 4)
                    {
                        cl.Student_screen.Add(student_s);
                        cl.SaveChanges();
                    }
                }
                else
                    MessageBox.Show("Student not exist in database");
            }
            
        }
    }
}

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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void studentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.studentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet_College);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet_College.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.dataSet_College.Student);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            collegeEntities cl = new collegeEntities();
            List<Student> students = cl.Students.ToList();
            Student s = new Student();
            s.StudentID= Convert.ToInt32(studentIDTextBox.Text);
            s.FullName = fullNameTextBox.Text;
            s.IdNum = idNumTextBox.Text;
            s.BirthDate = birthDateDateTimePicker.Value;
            s.RegisterDate = registerDateDateTimePicker.Value;
            if(students.Count== 0)
            {
                cl.Students.Add(s);
                cl.SaveChanges();
            }
            if(students.Count> 0)
            {
                foreach (Student item in students)
                {
                    if(s.IdNum == item.IdNum)
                    {
                        cl.Students.Remove(item);
                        s.StudentID = Convert.ToInt32(studentIDTextBox.Text);
                        s.IdNum = idNumTextBox.Text;
                        s.FullName = fullNameTextBox.Text;
                        s.BirthDate = birthDateDateTimePicker.Value;
                        s.RegisterDate = registerDateDateTimePicker.Value;
                        cl.Students.Add(s);
                        cl.SaveChanges();
                    }
                }
                
            }

        }
    }
}

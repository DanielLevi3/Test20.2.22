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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void courseBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.courseBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet_College);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet_College.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.dataSet_College.Student);
            // TODO: This line of code loads data into the 'dataSet_College.Course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.dataSet_College.Course);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            collegeEntities cl = new collegeEntities();
            List<Course> courses = cl.Courses.ToList();
            Course c = new Course();
            c.CourseCode = Convert.ToInt32(courseCodeTextBox.Text);
            c.CourseID = Convert.ToInt32(courseIDTextBox.Text);
            c.CourseName = courseNameTextBox.Text;
            c.CreditPoints = Convert.ToDecimal(creditPointsTextBox.Text);
            c.PassGrade = Convert.ToInt32(passGradeTextBox.Text);
           if(c.CourseName != string.Empty && c.CourseCode != null && c.CreditPoints != null && c.PassGrade != null )
            {
                if (courses.Count == 0)
                {
                   cl.Courses.Add(c);
                    cl.SaveChanges();
                }
                else if(courses.Count>0)
                {
                    if(courses.Contains(c))
                    {
                        MessageBox.Show("This course is exist in the system");
                    }
                    else
                    {
                        cl.Courses.Add(c);
                        cl.SaveChanges();
                    }
                }
                else
                { 
                    MessageBox.Show("This course is exist in the system");
                }
            }
           
        }

      
    }
}

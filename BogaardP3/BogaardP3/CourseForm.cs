using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using RESTUtil;

namespace BogaardP3
{
    public partial class CourseForm : Form
    {
        REST rj = new REST("http://ist.rit.edu/api");
        Course course;
        String para;
        public CourseForm(String me)
        {

            InitializeComponent();
            para = me;
            label1.Text = me;
        }

        private void Course_Load(object sender, EventArgs e)
        {
            string jsonCourse = rj.getRESTDataJSON("/course/courseID="+para);
            course = JToken.Parse(jsonCourse).ToObject<Course>();
            label1.Text = course.courseID;
            label1.Text += ("  --  "+course.title);
            label2.Text = course.description;
        }
    }
}

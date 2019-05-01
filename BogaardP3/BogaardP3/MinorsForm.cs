using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogaardP3
{
    public partial class MinorsForm : Form
    {
        UgMinor para;
        public MinorsForm(UgMinor me)
        {
            para = me;
            InitializeComponent();

        }

        private void MinorsForm_Load(object sender, EventArgs e)
        {
            label1.Text = para.title;
            label2.Text = para.description;
            label3.Text = para.note;

            for (int i = 0; i < para.courses.Count; i++)
            {
                //build a row, add it
                dataGridView1.Rows.Add();
                //add things to the row
                dataGridView1.Rows[i].Cells[0].Value =
                    para.courses[i];
            }
        }
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string courseS = row.Cells[0].Value.ToString();
                //constructor of courseForm
                CourseForm cF = new CourseForm(courseS);
                cF.Show();

            }
        }
    }
}

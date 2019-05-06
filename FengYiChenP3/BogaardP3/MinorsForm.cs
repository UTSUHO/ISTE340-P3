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
            this.Text = me.name;

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
            dataGridView1.CellContentDoubleClick += dataGridView_CellContentDoubleClicked;

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = false;
        }



        private void dataGridView_CellContentDoubleClicked(object sender, EventArgs e)
        {
            
            DataGridView buffer = sender as DataGridView;
            //MessageBox.Show(buffer.CurrentCell.Value.ToString());
            string courseS = buffer.CurrentCell.Value.ToString();
            //constructor of courseForm
            CourseForm cF = new CourseForm(courseS);
            cF.Show();
        }
    }
}

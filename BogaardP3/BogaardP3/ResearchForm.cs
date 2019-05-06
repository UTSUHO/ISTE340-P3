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
    public partial class ResearchForm : Form
    {
        public ResearchForm(ByInterestArea me)
        {
            InitializeComponent();
            this.Text = me.areaName;
            label1.Text = "Research By Domain Area: "+me.areaName;
            for (int i = 0; i < me.citations.Count; i++)
            {
                //build a row, add it
                dataGridView1.Rows.Add();
                //add things to the row
                dataGridView1.Rows[i].Cells[0].Value =
                    me.citations[i];
            }
        }
        public ResearchForm(ByFaculty me)
        {
            InitializeComponent();
            this.Text = "Citation of " + me.facultyName;
            label1.Text = me.facultyName;
            for (int i = 0; i < me.citations.Count; i++)
            {
                //build a row, add it
                dataGridView1.Rows.Add();
                //add things to the row
                dataGridView1.Rows[i].Cells[0].Value =
                    me.citations[i];
            }
        }
    }
}

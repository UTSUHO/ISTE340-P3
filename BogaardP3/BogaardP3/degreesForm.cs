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
    public partial class DegreesForm : Form
    {
        public DegreesForm(Undergraduate me)
        {
            InitializeComponent();
            this.Text = me.degreeName;
            label1.Text = me.title;
            label2.Text = me.description;
            for (int i = 0; i < me.concentrations.Count; i++)
            {
                //build a row, add it
                dataGridView1.Rows.Add();
                //add things to the row
                dataGridView1.Rows[i].Cells[0].Value =
                    me.concentrations[i];
            }

        }

        public DegreesForm(Graduate me)
        {
            InitializeComponent();
            
            this.Text = me.degreeName;
            
            if (me.degreeName == "graduate advanced certificates")
            {
                label1.Text = me.degreeName;
                this.Controls.Remove(dataGridView1);
                label2.Text = me.availableCertificates[0] + " " + me.availableCertificates[1];
            }
            else if (me.degreeName != "graduate advanced certificates")
            {
                label1.Text = me.title;
                label2.Text = me.description;
                for (int i = 0; i < me.concentrations.Count; i++)
                {
                    //build a row, add it
                    dataGridView1.Rows.Add();
                    //add things to the row
                    dataGridView1.Rows[i].Cells[0].Value =
                        me.concentrations[i];
                }
            }
        }
    }
}

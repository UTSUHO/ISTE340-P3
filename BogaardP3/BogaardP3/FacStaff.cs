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
    public partial class FacStaff : Form
    {
        public FacStaff(Faculty me)
        {
            this.Text = me.name;
            InitializeComponent();
            pictureBox1.Load(me.imagePath);
            name.Text += me.name;
            name.Text += ("  --  "+me.tagline);
            title.Text += me.title;
            interestArea.Text += me.interestArea;
            office.Text += me.office;
            phone.Text += me.phone;
            email.Text += me.email;
            website.Text += me.website;

        }

        public FacStaff(Staff me)
        {
            this.Text = me.name;
            InitializeComponent();
            pictureBox1.Load(me.imagePath);
            name.Text += me.name;
            name.Text += ("  --  " + me.tagline);
            title.Text += me.title;
            interestArea.Text += me.interestArea;
            office.Text += me.office;
            phone.Text += me.phone;
            email.Text += me.email;
            website.Text += me.website;
        }
    }
}

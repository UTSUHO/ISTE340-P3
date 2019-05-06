using Newtonsoft.Json.Linq;
using RESTUtil;
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
        REST rj = new REST("http://ist.rit.edu/api");
        Research research;
        String facName;
        public FacStaff(Faculty me)
        {
            facName = me.username;
            
            string jsonResearch = rj.getRESTDataJSON("/research/");
            research = JToken.Parse(jsonResearch).ToObject<Research>();

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
            this.Text = me.name;

        }


        public FacStaff(Staff me)
        {
            
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
            this.Text = me.name;
            this.Controls.Remove(Citation);
        }
        private void citation_Click(object sender, EventArgs e)
        {
            foreach (ByFaculty thisFac in research.byFaculty) {
                if (facName == thisFac.username) {
                    ResearchForm fR = new ResearchForm(thisFac);
                    fR.Show();
                }
            }
        }
    }
}

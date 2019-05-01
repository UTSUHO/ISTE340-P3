using Newtonsoft.Json.Linq;
using RESTUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogaardP3
{
    public partial class Form1 : Form
    {
        //instantiate my rest classes
        REST rj = new REST("http://ist.rit.edu/api");
        REST googleRj = new REST("http://www.google.com/api");

        //instantiate my data objects
        People people;
        About about;
        Resources resources;
        Employment employment;
        Minors minors;
        Footer footer;
        Stopwatch sw = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
            Console.WriteLine("from Const");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("From Load");
            //go get /about/
            string jsonAbout = rj.getRESTDataJSON("/about/");
            //Console.WriteLine(jsonAbout);
            //cast it to the About object!
            about = JToken.Parse(jsonAbout).ToObject<About>();
            //access
            //Console.WriteLine(about.title);
            label4.Text = about.description;
            label1.Text = about.quote;
            label2.Text = (" -- -- " + about.quoteAuthor);
            label3.Text = about.title;
            Console.WriteLine(about.quoteAuthor);
            string jsonResources = rj.getRESTDataJSON("/resources/");
            resources = JToken.Parse(jsonResources).ToObject<Resources>();
            //populate the linkLabel with the RITJobZoneLink!
            

            string jsonEmp = rj.getRESTDataJSON("/employment/");
            employment = JToken.Parse(jsonEmp).ToObject<Employment>();

            string jsonMinors = rj.getRESTDataJSON("/minors/");
            minors = JToken.Parse(jsonMinors).ToObject<Minors>();

            string jsonFooter = rj.getRESTDataJSON("/footer/");
            footer = JToken.Parse(jsonFooter).ToObject<Footer>();

            linkLabel1.Text = footer.quickLinks[1].href;

            /*imageine that I have a bunch of tabs(like an admin) that the entire
            application needs, but specific users don't - how do we handle that?

            */

            //names of the tabs that I have access to

            //string[] names = { "People", "ListView", "DataGrid", "tabPage4" };

            //kill all athat I shouldn't have access to

            /*foreach (TabPage tab in tabControl1.TabPages) {
                if (names.Contains(tab.Text))
                {
                    //kill it
                    int t = tabControl1.TabPages.IndexOf(tab);
                    tabControl1.TabPages.RemoveAt(t);
                }
            }*/

            //how do I dynamically create one a new tab?

            TabPage myNewTab = new TabPage("News");
            tabControl1.TabPages.Add(myNewTab);

            TextBox tb = new TextBox();
            tb.BackColor = SystemColors.HotTrack;
            tb.Location = new Point(10, 10);
            tb.Size = new Size(180, 30);
            tb.TabIndex = 1;
            myNewTab.Controls.Add(tb);
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //go and load the pdf!
            //which url do I need?  We can get it from sender!
            //LinkLabel me = (LinkLabel)sender;
            LinkLabel me = sender as LinkLabel;

            //make me look like I was visited
            me.LinkVisited = true;

            //open the browser
            System.Diagnostics.Process.Start(me.Text);
        }

        private void btn_people_Click(object sender, EventArgs e)
        {
            //get the json for people
            string jsonPeople = rj.getRESTDataJSON("/people/");
            people = JToken.Parse(jsonPeople).ToObject<People>();

            //play with data
            foreach(Faculty thisFac in people.faculty)
            {
                Console.WriteLine(thisFac.name);

                Button dButton = new Button();
                dButton.Text = thisFac.name;
                dButton.Show();
                dButton.Name = thisFac.username;            
                dButton.Location = new Point(dButton.Location.X + 108, dButton.Location.Y + 48);
                dButton.Visible = true;
                tabPage1.Controls.Add(dButton);
                dButton.Click += dButton_Click;
//                FacStaff f2 = new FacStaff(thisFac);
//                f2.Show();

            }

            //issue is how to find data on ONE ind
            getSingleInstance("dsbics");

        }

        private void dButton_Click(object sender, EventArgs e)
        {
            String buffer = this.Name;
            foreach (Faculty thisFac in people.faculty)
            {
                if (thisFac.username==buffer) {
                    FacStaff f2 = new FacStaff(thisFac);
                    f2.Show();
                }
            }
        }

        private void getSingleInstance(string id)
        {
            Faculty result = people.faculty.Find(x => x.username == id);
            Console.WriteLine(result.office);

            //useful
            List<Faculty> res = people.faculty.FindAll(x => x.title=="Associate Professor");
            Console.WriteLine(res[2].name);
        }

        private void btn_coop_Enter(object sender, EventArgs e)
        {
            //sw.Reset();
            //sw.Start();
            label5.Text = employment.introduction.content[1].description;
            foreach (String me in employment.careers.careerNames) {

                label6.Text += me;
                    }
            //creare the dataGridView contents!
            for (int i=0;i<employment.coopTable.coopInformation.Count;i++)
            {
                //build a row, add it
                dataGridView1.Rows.Add();
                //add things to the row
                dataGridView1.Rows[i].Cells[0].Value = 
                    employment.coopTable.coopInformation[i].employer;
                dataGridView1.Rows[i].Cells[1].Value =
                    employment.coopTable.coopInformation[i].degree;
                dataGridView1.Rows[i].Cells[2].Value =
                    employment.coopTable.coopInformation[i].city;
                dataGridView1.Rows[i].Cells[3].Value =
                    employment.coopTable.coopInformation[i].term;
            }


            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds.ToString());
        }

        private void btn_emp_Enter(object sender, EventArgs e)
        {
            //sw.Reset();
            //sw.Start();
            label11.Text = employment.introduction.content[0].description;
            foreach (String me in employment.employers.employerNames)
            {
                label12.Text += me;
            }
            //creare the dataGridView contents!
            for (int i = 0; i < employment.employmentTable.professionalEmploymentInformation.Count; i++)
            {
                //build a row, add it
                dataGridView2.Rows.Add();
                //add things to the row
                dataGridView2.Rows[i].Cells[0].Value =
                    employment.employmentTable.professionalEmploymentInformation[i].employer;
                dataGridView2.Rows[i].Cells[1].Value =
                    employment.employmentTable.professionalEmploymentInformation[i].degree;
                dataGridView2.Rows[i].Cells[2].Value =
                    employment.employmentTable.professionalEmploymentInformation[i].city;
                dataGridView2.Rows[i].Cells[3].Value =
                    employment.employmentTable.professionalEmploymentInformation[i].title;
                dataGridView2.Rows[i].Cells[4].Value =
                    employment.employmentTable.professionalEmploymentInformation[i].startDate;
            }


            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds.ToString());
        }

        private void tp_list_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked - worthless");
        }

        private void tp_list_Enter(object sender, EventArgs e)
        {
            if (employment == null)
            {
                string jsonEmp = rj.getRESTDataJSON("/employment/");
                employment = JToken.Parse(jsonEmp).ToObject<Employment>();

            }
            //build the listView
            sw.Reset();
            sw.Start();
            //prepare the listView
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Width = 710;
            //assign columns
            listView1.Columns.Add("Employer", 200);
            listView1.Columns.Add("Degree", 200);
            listView1.Columns.Add("City", 200);
            listView1.Columns.Add("Term", 200);

            //dump out the data...
            ListViewItem item;
            for (int i = 0; i < employment.coopTable.coopInformation.Count; i++)
            {
                item = new ListViewItem(new String[]
                {
                    employment.coopTable.coopInformation[i].employer,
                    employment.coopTable.coopInformation[i].degree,
                    employment.coopTable.coopInformation[i].city,
                    employment.coopTable.coopInformation[i].term
                });
                listView1.Items.Add(item);
            }
        }

        private void degreeStatic_Enter(object sender, EventArgs e)
        {
            label7.Text = employment.degreeStatistics.statistics[0].value;
            label7.Text += ("\r\r"+employment.degreeStatistics.statistics[0].description);
            label8.Text = employment.degreeStatistics.statistics[1].value;
            label8.Text += ("\r\r" + employment.degreeStatistics.statistics[1].description);
            label9.Text = employment.degreeStatistics.statistics[2].value;
            label9.Text += ("\r\r" + employment.degreeStatistics.statistics[2].description);
            label10.Text = employment.degreeStatistics.statistics[3].value;
            label10.Text += ("\r\r" + employment.degreeStatistics.statistics[3].description);
        }

        private void Minors_Enter(object sender, EventArgs e)
        {
            foreach (UgMinor me in minors.UgMinors) { 
                foreach (Label lab in Minors.Controls)
                {
                    if (me.name == lab.Text)
                    {
                        lab.Click += Lab_Click;
                    }
                }
            }
            Console.WriteLine("WTF");
        }

        private void Lab_Click(object sender, EventArgs e)
        {
            String buffer = this.Text;
            foreach (UgMinor me in minors.UgMinors)
            {
                if (me.name == buffer)
                {
                    MinorsForm fM = new MinorsForm(me);
                    fM.Show();
                }
            }
            throw new NotImplementedException();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
    
    
}

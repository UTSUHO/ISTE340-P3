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
        int situationFac = 0;
        int situationStaff = 0;


        //instantiate my data objects
        People people;
        About about;
        Resources resources;
        Employment employment;
        Minors minors;
        Footer footer;
        Degrees degrees;
        Research research;
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

            string jsonPeople = rj.getRESTDataJSON("/people/");
            people = JToken.Parse(jsonPeople).ToObject<People>();

            string jsonDegrees = rj.getRESTDataJSON("/degrees/");
            degrees = JToken.Parse(jsonDegrees).ToObject<Degrees>();

            string jsonResearch = rj.getRESTDataJSON("/research/");
            research = JToken.Parse(jsonResearch).ToObject<Research>();

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
                foreach (Label lab in minorsPage.Controls)
                {
                    
                    if (me.title == lab.Text)
                    {
                        lab.Click += LabS_Click;
                    }
                }
            }
        }

        private void LabS_Click(object sender, EventArgs e)
        {
            Label myButton = sender as Label;
            String buffer = myButton.Text;
            foreach (UgMinor me in minors.UgMinors)
            {
                if (me.title == buffer)
                {
                    MinorsForm fM = new MinorsForm(me);
                    fM.Show();
                }
            }
        }
        private void LabD_Click(object sender, EventArgs e)
        {
            Label myButton = sender as Label;
            String buffer = myButton.Text;
            foreach (Undergraduate me in degrees.Undergraduate)
            {
                if (me.title == buffer)
                {
                    DegreesForm fD = new DegreesForm(me);
                    fD.Show();
                }
            }
            foreach (Graduate me in degrees.Graduate)
            {
                if (me.title == buffer)
                {
                    DegreesForm fD = new DegreesForm(me);
                    fD.Show();
                }
                else if (me.degreeName == buffer)
                {
                    DegreesForm fD = new DegreesForm(me);
                    fD.Show();
                }
            }
        }

        

        //preloading function of staff/fac

        /*
    private void professorTabPage_Enter(object sender, EventArgs e)
    {
        if (situationFac == 0)
        {
            //TabPage buffer = sender as TabPage;
            int lx = 108;
            int ly = 48;
            int iy = 5;
            int ix = 10;
            int counter = 0;
            //play with data
            foreach (Faculty thisFac in people.faculty)
            {
                //Console.WriteLine(thisFac.name);
                Button dButtonF = new Button();
                dButtonF.Text = thisFac.name;
                dButtonF.Show();
                dButtonF.Name = thisFac.username;
                if (counter == 0)
                {
                    dButtonF.Location = new Point(ix, iy);
                }
                else
                {
                    if (counter % 6 == 0)
                    {
                        iy += ly;
                        ix = 10;
                        lx = 108;
                        dButtonF.Location = new Point(ix, iy);
                    }
                    else
                    {
                        dButtonF.Location = new Point(ix + lx, iy);
                        lx += 108;
                    }
                }
                counter++;
                dButtonF.Visible = true;
                facultyTabPage.Controls.Add(dButtonF);
                dButtonF.Click += dButtonF_Click;
            }
            situationFac = 1;
        }
        //issue is how to find data on ONE ind
        //getSingleInstance("dsbics");
    }

    private void staffTabPage_Enter(object sender, EventArgs e)
    {
        if (situationStaff == 0)
        {
            //TabPage buffer = sender as TabPage;
            int lx = 108;
            int ly = 48;
            int iy = 5;
            int ix = 10;
            int counter = 0;

            //play with data
            foreach (Staff thisStaff in people.staff)
            {
                //Console.WriteLine(thisStaff.name);
                Button dButtonS = new Button();
                dButtonS.Text = thisStaff.name;
                dButtonS.Show();
                dButtonS.Name = thisStaff.username;
                if (counter == 0)
                {
                    dButtonS.Location = new Point(ix, iy);
                }
                else
                {
                    if (counter % 6 == 0)
                    {
                        iy += ly;
                        ix = 10;
                        lx = 108;
                        dButtonS.Location = new Point(ix, iy);
                    }
                    else
                    {
                        dButtonS.Location = new Point(ix + lx, iy);
                        lx += 108;
                    }
                }
                counter++;
                dButtonS.Visible = true;
                staffTabPage.Controls.Add(dButtonS);
                dButtonS.Click += dButtonS_Click;
            }
            situationStaff = 1;
            //issue is how to find data on ONE ind
            //getSingleInstance("dsbics");
        }
    }
    */
        private void dButtonF_Click(object sender, EventArgs e)
        {
            Button myButton = sender as Button;
            String buffer = myButton.Name;
            foreach (Faculty thisFac in people.faculty)
            {
                if (thisFac.username == buffer)
                {
                    FacStaff f2 = new FacStaff(thisFac);
                    f2.Show();
                }
            }
        }

        private void dButtonS_Click(object sender, EventArgs e)
        {
            Button myButton = sender as Button;
            String buffer = myButton.Name;
            foreach (Staff thisStaff in people.staff)
            {
                if (thisStaff.username == buffer)
                {
                    FacStaff f2 = new FacStaff(thisStaff);
                    f2.Show();
                }
            }
        }

        //refactor method of staff/fac preload function
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "peoplePage")
            {
                if (situationFac == 0)
                {
                    int lx = 108;
                    int ly = 48;
                    int iy = 5;
                    int ix = 10;
                    int counter = 0;
                    //play with data
                    foreach (Faculty thisFac in people.faculty)
                    {
                        //Console.WriteLine(thisFac.name);
                        Button dButtonF = new Button();
                        dButtonF.Text = thisFac.name;
                        dButtonF.Show();
                        dButtonF.Name = thisFac.username;
                        if (counter == 0)
                        {
                            dButtonF.Location = new Point(ix, iy);
                        }
                        else
                        {
                            if (counter % 6 == 0)
                            {
                                iy += ly;
                                ix = 10;
                                lx = 108;
                                dButtonF.Location = new Point(ix, iy);
                            }
                            else
                            {
                                dButtonF.Location = new Point(ix + lx, iy);
                                lx += 108;
                            }
                        }
                        counter++;
                        dButtonF.Visible = true;
                        facultyTabPage.Controls.Add(dButtonF);
                        dButtonF.Click += dButtonF_Click;
                    }
                    situationFac = 1;
                }
                if (situationStaff == 0)
                {
                    int lx = 108;
                    int ly = 48;
                    int iy = 5;
                    int ix = 10;
                    int counter = 0;

                    //play with data
                    foreach (Staff thisStaff in people.staff)
                    {
                        //Console.WriteLine(thisStaff.name);
                        Button dButtonS = new Button();
                        dButtonS.Text = thisStaff.name;
                        dButtonS.Show();
                        dButtonS.Name = thisStaff.username;
                        if (counter == 0)
                        {
                            dButtonS.Location = new Point(ix, iy);
                        }
                        else
                        {
                            if (counter % 6 == 0)
                            {
                                iy += ly;
                                ix = 10;
                                lx = 108;
                                dButtonS.Location = new Point(ix, iy);
                            }
                            else
                            {
                                dButtonS.Location = new Point(ix + lx, iy);
                                lx += 108;
                            }
                        }
                        counter++;
                        dButtonS.Visible = true;
                        staffTabPage.Controls.Add(dButtonS);
                        dButtonS.Click += dButtonS_Click;
                    }
                    situationStaff = 1;
                    //issue is how to find data on ONE ind
                    //getSingleInstance("dsbics");
                }
            }
            if (tabControl1.SelectedTab.Name == "degreesPage")
            {
                foreach (Undergraduate me in degrees.Undergraduate)
                {
                    foreach (Label lab in undergraduate.Controls)
                    {

                        if (me.title == lab.Text)
                        {
                            lab.Click += LabD_Click;
                        }
                    }
                }
                foreach (Graduate me in degrees.Graduate)
                {
                    foreach (Label lab in graduate.Controls)
                    { 
                        if (me.title == lab.Text)
                        {
                            lab.Click += LabD_Click;
                        }
                        else if (me.degreeName == lab.Text)
                        {
                            lab.Click += LabD_Click;
                        }
                    }
                }
                
            }
        }
    }
    
    
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Net;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            spinner.Visible = false;
        }



        #region inline
        //Inline!
        private void button1_Click(object sender, EventArgs e)
        {

            timer1.Start();

            Cursor.Current = Cursors.WaitCursor;
            //take some time.
            getStuff();

            timer1.Stop();
            Cursor.Current = Cursors.Default;
            //this way sucks.  We are stuck in the main thread and
            //can't have the form redraw the spinner or the 
            //loadbar...

        }


        #endregion inline

        #region threaded
        //Threaded... Launch up a new single thread to 
        //process the requests.
        private void button2_Click(object sender, EventArgs e)
        {
            //turn on the visuals...
            spinner.Visible = true;


            //create a thread.
            timer1.Start();
            Cursor.Current = Cursors.WaitCursor;
            ThreadStart ts = new ThreadStart(getStuff);
            Thread t = new Thread(ts);
            t.Start();
            


            //turn off visuals
            spinner.Visible = false;
            Cursor.Current = Cursors.Default;
            timer1.Stop();
           
            //cant see anything - why?  It's a thread.
            //seperate process that makes this code forge ahead and
            //not wait at all.

        }


        #endregion threaded

        #region backgroundWorker
        //BackgroundWorker - a way
        /*
         * The core issue that BW tried to solve was the need to 
         * execute synchronous code on a background thread.
         * (like updating a UI after load...)
         * 
         */
        private void button3_Click(object sender, EventArgs e)
        {
            spinner.Visible = true;
            timer1.Start();

            //BW
            var bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync();


            
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            
            getStuff();
            
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            spinner.Visible = false;
            timer1.Stop();
        }

        #endregion backgroundWorker

        #region task
        //task - another way...
        //threaded and ASYNC.
        private async void button4_Click(object sender, EventArgs e)
        {
            timer1.Start();
            spinner.Visible = true;
            Cursor.Current = Cursors.WaitCursor;
            await Task.Run(() =>
            {
                getStuff();
            });

            timer1.Stop();
            spinner.Visible = false;
            Cursor.Current = Cursors.Default;
        }
        #endregion task

        private void getStuff()
        {


            for (int j = 0; j < 5; j++)
            {
                //List<string> orgs = new List<string>();
                string uri = @"http://simon.ist.rit.edu:8080/Services/resources/ESD/Organizations";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
                req.Method = "GET";
                Console.WriteLine("in");
                try
                {
                    HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                    //converts the response into a usable stream
                    Stream str = res.GetResponseStream();
                    // reads the stream as an XML object
                    XmlReader xr = XmlReader.Create(str);

                    XmlDocument xmlDoc = new XmlDocument();
                    xr.Read();
                    xmlDoc.Load(xr);
                    XmlNodeList names = xmlDoc.GetElementsByTagName("name");
                    for (int i = 0; i < names.Count; i++)
                    {
                        //waisting time...
                    }
                    res.Close();
                }
                catch (Exception ex)
                {
                    Console.Write("Error");
                }
            }
            Console.WriteLine("What happened");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value++;
            }
            else {
                progressBar1.Value = 0;
            }
        }




    }
}

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


namespace IST
{
    public partial class PeopleWin : Form
    {
        Faculty f;
        Staff s;
        RESTUtil.Rest api = new RESTUtil.Rest("http://ist.rit.edu/api");
        public PeopleWin(string url)
        {
            InitializeComponent();
            string[] person = url.Split('_');
            string staff = api.getRestData(string.Concat("/people/", person[0], "/username=", person[1]));
            if (person[0].Equals("staff"))
            {
                s = JToken.Parse(staff).ToObject<Staff>();
            } else
            {
                f = JToken.Parse(staff).ToObject<Faculty>();
            }
            showbox();
        }

        private void showbox()
        {
            if (s != null)
            {
                if (s.name != null)
                {
                    peaple_label1.Text = s.name;
                }
                if(s.title != null)
                {
                    peaple_label1.Text += ", " + s.title;
                }
                if (s.office != null)
                {
                    peaple_label2.Text = "Office: " + s.office;
                }
                if (s.email != null)
                {
                    peaple_label3.Text = "Email: " + s.email;
                }
                if (s.phone != null)
                {
                    peaple_label4.Text = "Phone: " + s.phone;
                }
                if (s.website != null)
                {
                    peaple_label5.Text = "Website: " + s.website;
                }
                if (s.twitter != null)
                {
                    peaple_label6.Text = "Twitter: " + s.twitter;
                }
                if(s.facebook != null)
                {
                    peaple_label7.Text = "FaceBook: " + s.facebook;
                }
                if(s.tagline != null)
                {
                    peaple_label8.Text = s.tagline;
                }
                if(s.imagePath != null)
                {
                    peaple_pictureBox.Load(s.imagePath);
                }
            } else
            {
                {
                    peaple_label1.Text = f.name;
                }
                if (f.title != null)
                {
                    peaple_label1.Text += ", " + f.title;
                }
                if (f.office != null)
                {
                    peaple_label2.Text = "Office: " + f.office;
                }
                if (f.email != null)
                {
                    peaple_label3.Text = "Email: " + f.email;
                }
                if (f.phone != null)
                {
                    peaple_label4.Text = "Phone: " + f.phone;
                }
                if (f.website != null)
                {
                    peaple_label5.Text = "Website: " + f.website;
                }
                if (f.twitter != null)
                {
                    peaple_label6.Text = "Twitter: " + f.twitter;
                }
                if (f.facebook != null)
                {
                    peaple_label7.Text = "FaceBook: " + f.facebook;
                }
                if (f.tagline != null)
                {
                    peaple_label8.Text = f.tagline;
                }
                if (f.imagePath != null)
                {
                    peaple_pictureBox.Load(f.imagePath);
                }
            }
        }
    }
}

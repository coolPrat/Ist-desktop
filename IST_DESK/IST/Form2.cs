using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IST
{
    public partial class Form2 : Form
    {
        List<string> _items = new List<string>();
        News mynews;
        public Form2(Form1 news)
        {
            mynews = news.getNews();
            InitializeComponent();
            newsTabs_SelectedIndexChanged(this, EventArgs.Empty);
        }

        private void newsTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currentIndex = newsTabs.SelectedIndex;
            Label title;
            Label desc;
            Label date;
            switch (currentIndex)
            {
                case 0:
                    List<Year> years = mynews.year;
                    foreach (Year year in years)
                    {
                        title = getTitle();
                        desc = getDesc();
                        date = getDate();
                        title.Text = year.title;
                        date.Text = year.date;
                        desc.Text = year.description;
                        title.AutoSize = true;
                        desc.AutoSize = true;
                        date.AutoSize = true;
                        this.flowLayoutPanel1.Controls.Add(title);
                        this.flowLayoutPanel1.Controls.Add(date);
                        this.flowLayoutPanel1.Controls.Add(desc);

                    }
                    break;
                case 1:
                    List<Quarter> quarters = mynews.quarter;
                    foreach (Quarter quarter in quarters)
                    {
                        title = getTitle();
                        desc = getDesc();
                        date = getDate();
                        title.Text = quarter.title;
                        date.Text = quarter.date;
                        desc.Text = quarter.description;
                        title.AutoSize = true;
                        desc.AutoSize = true;
                        date.AutoSize = true;
                        this.flowLayoutPanel4.Controls.Add(title);
                        this.flowLayoutPanel4.Controls.Add(date);
                        this.flowLayoutPanel4.Controls.Add(desc);

                    }
                    break;
                case 2:
                    List<Month> months = mynews.month;
                    foreach (Month month in months)
                    {
                        title = getTitle();
                        desc = getDesc();
                        date = getDate();
                        title.Text = month.title;
                        date.Text = month.date;
                        desc.Text = month.description;
                        title.AutoSize = true;
                        desc.AutoSize = true;
                        date.AutoSize = true;
                        this.flowLayoutPanel3.Controls.Add(title);
                        this.flowLayoutPanel3.Controls.Add(date);
                        this.flowLayoutPanel3.Controls.Add(desc);

                    }
                    break;
                case 3:
                    List<Older> old = mynews.older;
                    foreach (Older oldOne in old)
                    {
                        title = getTitle();
                        desc = getDesc();
                        date = getDate();
                        title.Text = oldOne.title;
                        date.Text = oldOne.date;
                        desc.Text = oldOne.description;
                        title.AutoSize = true;
                        desc.AutoSize = true;
                        date.AutoSize = true;

                        this.flowLayoutPanel2.Controls.Add(title);
                        this.flowLayoutPanel2.Controls.Add(date);
                        this.flowLayoutPanel2.Controls.Add(desc);

                    }
                    break;
            }
        } 

        public void setNews(News news)
        {
            this.mynews = news;
        }


        private Label getTitle()
        {
            Label l = new Label();
            l.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
            l.MaximumSize = new Size(900, l.Width);
            return l;
        }

        private Label getDesc()
        {
            Label l = new Label();
            l.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
            l.MaximumSize = new Size(900, 1000);
            l.Padding = new Padding(0, 2, 0, 18);
            return l;
        }

        private Label getDate()
        {
            Label l = new Label();
            l.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            l.MaximumSize = new Size(900, l.Width);
            return l;
        }
    }
}

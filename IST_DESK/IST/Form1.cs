using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RESTUtil;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace IST
{
    public partial class Form1 : Form
    {
        Rest apiPoint = new Rest("http://ist.rit.edu/api");
        string[] tabs = { "/about/", "/degrees/", "/employement/", "/people/", "/research/", "resources/" };
        News aalaNews;
        EmployementData empData = null;
        Degrees degrees;
        Minors minors;
        People people;
        Research research;
        Resources resources;
        Links links;
        private List<Control> undergradControls = new List<Control>();
        private List<Control> gradControls = new List<Control>();
        private List<string> minorList = new List<string>();
        private Dictionary<string, Control> minorMap;
        ListBox minor_list;
        ListBox minor_list_2;


        public Form1()
        {
            InitializeComponent();
            mainTab_SelectedIndexChanged(this, EventArgs.Empty);
        }

        private void mainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currentIndex = mainTab.SelectedIndex;
            switch (currentIndex)
            {
                case 0:
                    string jsonAbout = apiPoint.getRestData("/about/");
                    About about = JToken.Parse(jsonAbout).ToObject<About>();
                    aboutTitle.Text = about.title;
                    about_desc.Text = about.description;
                    about_quote.Text = "\"" + about.quote + "\"";
                    about_auth.Text = about.quoteAuthor;
                    break;
                case 1:
                    if (degrees == null)
                    {
                        string jsonDegree = apiPoint.getRestData("/degrees/");
                        degrees = JToken.Parse(jsonDegree).ToObject<Degrees>();
                        string jsonMinors = apiPoint.getRestData("/minors/");
                        minors = JToken.Parse(jsonMinors).ToObject<Minors>();
                        foreach (UgMinor ug in minors.UgMinors)
                        {
                            minorList.Add(ug.title);
                        }
                    }
                    degreeRadio1.Checked = true;
                    break;
                case 2:
                    if (empData == null)
                    {
                        string jsonEmployment = apiPoint.getRestData("/employment/");
                        EmployementData employment = JToken.Parse(jsonEmployment).ToObject<EmployementData>();
                        empData = employment;
                    }
                    showEmpDetails();
                    break;
                case 3:
                    if (people == null)
                    {
                        string peopleJson = apiPoint.getRestData("/people/");
                        people = JToken.Parse(peopleJson).ToObject<People>();
                    }
                    staffRad.Checked = true;
                    break;
                case 4:
                    if (research == null)
                    {
                        string researchJson = apiPoint.getRestData("/research/");
                        research = JToken.Parse(researchJson).ToObject<Research>();
                    }
                    researchTab_SelectedIndexChanged(this, EventArgs.Empty);
                    break;
                case 5:
                    if (resources == null)
                    {
                        string resourcesJson = apiPoint.getRestData("/resources/");
                        resources = JToken.Parse(resourcesJson).ToObject<Resources>();
                    }
                    resourcesTab_SelectedIndexChanged(this, EventArgs.Empty);
                    break;
                case 6:
                    string json = apiPoint.getRestData("/footer/");
                    links = JToken.Parse(json).ToObject<Links>();

                    links_label1.Text = links.social.title;
                    links_linkLabel1.Text = "Twitter";
                    links_linkLabel2.Text = "Facebook";
                    links_label2.Text = "Quicklinks";
                    links_linkLabel3.Text = links.quickLinks[0].title;
                    links_linkLabel4.Text = links.quickLinks[1].title;
                    links_linkLabel5.Text = links.quickLinks[2].title;
                    links_linkLabel6.Text = links.quickLinks[3].title;
                    links_label3.Text = links.copyright.title;
                    links_webBrowser1.DocumentText = links.copyright.html;
                    break;
            }
        }

        private void showEmpDetails()
        {
            head_emp.Text = string.Concat("\"", empData.introduction.title, "\"");
            foreach (Content con in empData.introduction.content)
            {
                if (con.title.Equals("Employment"))
                {
                    lab_emp.Text = con.title;
                    lable_emp_desc.Text = con.description;
                }
                else
                {
                    label_coop.Text = con.title;
                    label_coop_desc.Text = con.description;
                }
            }

            List<FlowLayoutPanel> flows = new List<FlowLayoutPanel>();
            List<Statistic> statList = empData.degreeStatistics.statistics;
            foreach (Statistic stat in statList)
            {
                FlowLayoutPanel flow = new FlowLayoutPanel();
                flow.Controls.Add(new Label { Text = stat.value, AutoSize = true, MaximumSize = new Size(120, 25), Font = new Font("Microsoft Sans Serif", 9) });
                flow.Controls.Add(new Label { Text = stat.description, AutoSize = true, MaximumSize = new Size(120, 100), Font = new Font("Microsoft Sans Serif", 8) });
                flows.Add(flow);
            }

            emp_stat_table.Controls.Add(flows.ElementAt(0), 0, 0);
            emp_stat_table.Controls.Add(flows.ElementAt(1), 0, 1);
            emp_stat_table.Controls.Add(flows.ElementAt(2), 1, 0);
            emp_stat_table.Controls.Add(flows.ElementAt(3), 1, 1);
        }


        private void news_Click(object sender, EventArgs e)
        {
            News news2 = JToken.Parse(apiPoint.getRestData("/news/")).ToObject<News>();
            this.setNews(news2);
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        private void setNews(News news)
        {
            this.aalaNews = news;
        }

        public News getNews()
        {
            return this.aalaNews;
        }

        private void contactUs_Click(object sender, EventArgs e)
        {
            contact cs = new contact();
            cs.Show();
        }

        private void coop_table_Click(object sender, EventArgs e)
        {
            TableCoop tabCoop = new TableCoop(empData.coopTable.coopInformation);
            tabCoop.Show();
        }

        private void emp_table_Click(object sender, EventArgs e)
        {
            TableEmp tabEmp = new TableEmp(empData.employmentTable.professionalEmploymentInformation);
            tabEmp.Show();
        }

        private void map_Click(object sender, EventArgs e)
        {
            new EmpMap().Show();
        }

        /*private void degreeRadio1_CheckedChanged(object sender, EventArgs e)
        {
            List<string> underGradList = new List<string>();
            underGradList.Add("Majors");
            underGradList.Add("Minors");
            degree_listBox.DataSource = underGradList;
            degree_listBox.SelectedIndex = 0;
        }*/

        /*private void degree_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("AAA");
        }*/

        private void allDegreeRadio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectedRad = sender as RadioButton;
            if (selectedRad.Checked)
            {
                List<string> underGradList = new List<string>();
                underGradList.Add("Majors");
                underGradList.Add("Minors");
                degree_listBox.DataSource = underGradList;
                degree_listBox.SelectedIndex = 0;
            }
            else
            {
                List<string> gradList = new List<string>();
                gradList.Add("Majors");
                gradList.Add("Certifications");
                degree_listBox.DataSource = gradList;
                degree_listBox.SelectedIndex = 0;
            }

        }

        private void degree_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (degreeRadio1.Checked)
            {
                if (degree_listBox.SelectedIndex == 0)
                {
                    if (undergradControls.Count == 0)
                    {
                        for (int i = 0; i < degrees.undergraduate.Count; i++)
                        {
                            foreach (Control cnt in degree_panel.Controls)
                            {
                                if (cnt is Label && cnt.Name.Equals("under_head_label_" + (i + 1)))
                                {
                                    cnt.Text = degrees.undergraduate[i].title;
                                }
                                if (cnt is Label && cnt.Name.Equals("under_desc_label_" + (i + 1)))
                                {
                                    cnt.Text = degrees.undergraduate[i].description;
                                }
                            }
                        }
                    }
                    else
                    {
                        degree_panel.Controls.Clear();
                        foreach (Control cnt in undergradControls)
                        {
                            degree_panel.Controls.Add(cnt);
                        }
                    }
                }
                else
                {
                    foreach (Control cnt in degree_panel.Controls)
                    {
                        undergradControls.Add(cnt);
                    }
                    degree_panel.Controls.Clear();
                    minorMap = setMinorPanel();
                    minor_list = minorMap["minor_list"] as ListBox;
                    minor_list_2 = minorMap["minor_list_2"] as ListBox;
                    minor_list.SelectedIndex = 0;
                }
            }
            else
            {
                if (degree_listBox.SelectedIndex == 0)
                {
                    if (gradControls.Count == 0)
                    {
                        for (int i = 0; i < degrees.graduate.Count; i++)
                        {
                            foreach (Control cnt in degree_panel.Controls)
                            {
                                if (cnt is Label && cnt.Name.Equals("under_head_label_" + (i + 1)))
                                {
                                    cnt.Text = degrees.graduate[i].title;
                                }
                                if (cnt is Label && cnt.Name.Equals("under_desc_label_" + (i + 1)))
                                {
                                    cnt.Text = degrees.graduate[i].description;
                                }
                            }
                        }
                    }
                    else
                    {
                        degree_panel.Controls.Clear();
                        foreach (Control cnt in gradControls)
                        {
                            degree_panel.Controls.Add(cnt);
                        }
                    }
                }
                else
                {
                    foreach (Control cnt in degree_panel.Controls)
                    {
                        gradControls.Add(cnt);
                    }
                    degree_panel.Controls.Clear();
                    showCerti();
                }

            }
        }

        private void under_info_1_Click(object sender, EventArgs e)
        {
            UnderInfo undInfo;
            if (degreeRadio1.Checked)
            {
                undInfo = new UnderInfo(degrees.undergraduate[0].title, degrees.undergraduate[0].concentrations);
            }
            else
            {
                undInfo = new UnderInfo(degrees.graduate[0].title, degrees.graduate[0].concentrations);
            }
            undInfo.Show();
        }

        private void under_info_2_Click(object sender, EventArgs e)
        {
            UnderInfo undInfo;
            if (degreeRadio1.Checked)
            {
                undInfo = new UnderInfo(degrees.undergraduate[1].title, degrees.undergraduate[1].concentrations);
            }
            else
            {
                undInfo = new UnderInfo(degrees.graduate[1].title, degrees.graduate[1].concentrations);
            }
            undInfo.Show();
        }

        private void under_info_3_Click(object sender, EventArgs e)
        {
            UnderInfo undInfo;
            if (degreeRadio1.Checked)
            {
                undInfo = new UnderInfo(degrees.undergraduate[2].title, degrees.undergraduate[2].concentrations);
            }
            else
            {
                undInfo = new UnderInfo(degrees.graduate[2].title, degrees.graduate[2].concentrations);
            }
            undInfo.Show();
        }

        private Dictionary<string, Control> setMinorPanel()
        {
            Dictionary<string, Control> minorMap = new Dictionary<string, Control>();
            Label minor_desc_1 = new Label();
            minor_desc_1.AutoSize = true;
            minor_desc_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            minor_desc_1.Location = new System.Drawing.Point(20, 14);
            minor_desc_1.Name = "minor_desc_1";
            minor_desc_1.Size = new System.Drawing.Size(52, 17);

            minor_desc_1.TabIndex = 0;
            minor_desc_1.Text = "label1";
            minorMap.Add("minor_desc_1", minor_desc_1);


            Label minor_desc_2 = new Label();
            minor_desc_2.AutoSize = true;
            minor_desc_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            minor_desc_2.Location = new System.Drawing.Point(24, 77);
            minor_desc_2.Name = "minor_desc_2";
            minor_desc_2.Size = new System.Drawing.Size(46, 17);
            minor_desc_2.MaximumSize = new System.Drawing.Size(250, 100);
            minor_desc_2.AutoSize = true;
            minor_desc_2.TabIndex = 1;
            minor_desc_2.Text = "label2";
            minorMap.Add("minor_desc_2", minor_desc_2);

            Panel minor_panel_2 = new Panel();
            minor_panel_2.Controls.Add(minor_desc_2);
            minor_panel_2.Controls.Add(minor_desc_1);
            minor_panel_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            minor_panel_2.Location = new System.Drawing.Point(158, 168);
            minor_panel_2.Name = "minor_panel_2";
            minor_panel_2.Size = new System.Drawing.Size(414, 233);
            minor_panel_2.TabIndex = 3;
            minorMap.Add("minor_panel_2", minor_panel_2);

            ListBox minor_list_2 = new ListBox();
            minor_list_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            minor_list_2.FormattingEnabled = true;
            minor_list_2.ItemHeight = 18;
            minor_list_2.Location = new System.Drawing.Point(12, 168);
            minor_list_2.Name = "minor_list_2";
            minor_list_2.Size = new System.Drawing.Size(140, 220);
            minor_list_2.TabIndex = 2;
            minor_list_2.SelectedIndexChanged += new System.EventHandler(this.minor_list_2_SelectedIndexChanged);
            minorMap.Add("minor_list_2", minor_list_2);

            Label minor_label_1 = new Label();
            minor_label_1.AutoSize = true;
            minor_label_1.Location = new System.Drawing.Point(4, 4);
            minor_label_1.Name = "minor_label_1";
            minor_label_1.Size = new System.Drawing.Size(59, 20);
            minor_label_1.TabIndex = 0;
            minor_label_1.Text = "label1";
            minorMap.Add("minor_label_1", minor_label_1);

            Label minor_label_2 = new Label();
            minor_label_2.AutoSize = true;
            minor_label_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            minor_label_2.Location = new System.Drawing.Point(8, 45);
            minor_label_2.Name = "minor_label_2";
            minor_label_2.Size = new System.Drawing.Size(46, 18);
            minor_label_2.MaximumSize = new System.Drawing.Size(550, 50);
            minor_label_2.AutoSize = true;
            minor_label_2.TabIndex = 1;
            minor_label_2.Text = "label2";
            minorMap.Add("minor_label_2", minor_label_2);


            ListBox minor_list = new ListBox();
            minor_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            minor_list.FormattingEnabled = true;
            minor_list.ItemHeight = 20;
            minor_list.Location = new System.Drawing.Point(4, 11);
            minor_list.Name = "minor_list";
            minor_list.Size = new System.Drawing.Size(205, 404);
            minor_list.TabIndex = 0;
            minor_list.DataSource = minorList;
            minor_list.SelectedIndexChanged += new System.EventHandler(this.minor_list_SelectedIndexChanged);
            minorMap.Add("minor_list", minor_list);

            Panel panel2 = new Panel();
            panel2.Controls.Add(minor_panel_2);
            panel2.Controls.Add(minor_list_2);
            panel2.Controls.Add(minor_label_2);
            panel2.Controls.Add(minor_label_1);
            panel2.Location = new System.Drawing.Point(215, 11);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(587, 404);
            panel2.TabIndex = 1;
            minorMap.Add("panel2", panel2);


            Panel minor_panel = new Panel();
            minor_panel.Controls.Add(panel2);
            minor_panel.Controls.Add(minor_list);
            //minor_panel.Location = new System.Drawing.Point(200, 40);
            minor_panel.Name = "minor_panel";
            minor_panel.Size = new System.Drawing.Size(805, 423);
            minor_panel.TabIndex = 0;
            minorMap.Add("minor_panel", minor_panel);

            degree_panel.Controls.Add(minor_panel);
            return minorMap;
        }

        private void minor_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = minor_list.SelectedIndex;
            minorMap["minor_label_1"].Text = minors.UgMinors[index].title;
            minorMap["minor_label_2"].Text = minors.UgMinors[index].description;
            (minorMap["minor_list_2"] as ListBox).DataSource = minors.UgMinors[index].courses;
            (minorMap["minor_list_2"] as ListBox).SelectedIndex = 0;
        }

        private void minor_list_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = minor_list.SelectedIndex;
            int index1 = minor_list_2.SelectedIndex;
            string name = minors.UgMinors[index].courses[index1];
            string csStr = apiPoint.getRestData(string.Concat("/course/courseID=", name));
            Course cs = JToken.Parse(csStr).ToObject<Course>();
            minorMap["minor_desc_1"].Text = string.Concat(cs.courseID, ":", cs.title);
            minorMap["minor_desc_2"].Text = string.Concat(cs.description);
        }

        private void showCerti()
        {
            Label l1 = new Label();
            l1.Text = degrees.graduate[degrees.graduate.Count() - 1].degreeName;
            l1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            l1.Size = new Size(400, 50);
            l1.Location = new System.Drawing.Point(248, 89);
            Label l2 = new Label();
            l2.Text = degrees.graduate[degrees.graduate.Count() - 1].availableCertificates[0];
            l2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            l2.Size = new Size(400, 50);
            l2.Location = new System.Drawing.Point(252, 167);
            Label l3 = new Label();
            l3.Text = degrees.graduate[degrees.graduate.Count() - 1].availableCertificates[1];
            l3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            l3.Size = new Size(400, 50);
            l3.Location = new System.Drawing.Point(252, 267);

            degree_panel.Controls.Add(l1);
            degree_panel.Controls.Add(l2);
            degree_panel.Controls.Add(l3);
        }

        private void staffRad_CheckedChanged(object sender, EventArgs e)
        {
            
            while (peopleTable.RowStyles.Count > 0)
            {
                peopleTable.RowStyles.RemoveAt(0);
            }
            while(peopleTable.ColumnStyles.Count > 0)
            {
                peopleTable.ColumnStyles.RemoveAt(0);
            }
            peopleTable.Controls.Clear();
            if (staffRad.Checked == true)
            {
                this.peopleTable.ColumnCount = 5;
                for (int i = 0; i < 5; i++)
                {
                    this.peopleTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
                }
                this.peopleTable.RowCount = 3;
                for (int i = 0; i < 3; i++)
                {
                    this.peopleTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
                }


                int row = -1, col = 0;
                for (int i = 0; i < people.staff.Count; i++)
                {
                    if (i % 5 == 0)
                    {
                        row += 1;
                        col = 0;
                    }
                    else
                    {
                        col += 1;
                    }
                    //MessageBox.Show(people.staff[i].name);
                    LinkLabel l1 = new LinkLabel();
                    l1.VisitedLinkColor = Color.Blue;
                    l1.ActiveLinkColor = Color.Blue;
                    l1.LinkColor = Color.Blue;
                    l1.Visible = true;
                    l1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
                    l1.LinkArea = new LinkArea(0, 100);
                    l1.MaximumSize = new Size(200, 100);
                    l1.AutoSize = true;
                    l1.Name = "staff_" + people.staff[i].username;
                    l1.Text = people.staff[i].name;
                    l1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
                    peopleTable.Controls.Add(l1, col, row);
                }
            }
            else
            {
                this.peopleTable.Controls.Clear();
                //MessageBox.Show(people.faculty.Count + "");
                this.peopleTable.ColumnCount = 5;
                for (int i = 0; i < 5; i++)
                {
                    this.peopleTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
                }
                this.peopleTable.RowCount = 7;
                for (int i = 0; i < 7; i++)
                {
                    this.peopleTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.2F));
                }


                int row = -1, col = 0;
                for (int i = 0; i < people.faculty.Count; i++)
                {
                    if (i % 5 == 0)
                    {
                        row += 1;
                        col = 0;
                    }
                    else
                    {
                        col += 1;
                    }
                    //MessageBox.Show(people.faculty[i].name);
                    LinkLabel l1 = new LinkLabel();
                    l1.VisitedLinkColor = Color.Blue;
                    l1.ActiveLinkColor = Color.Blue;
                    l1.LinkColor = Color.Blue;
                    l1.Visible = true;
                    l1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
                    l1.LinkArea = new LinkArea(0, 100);
                    l1.MaximumSize = new Size(200, 100);
                    l1.AutoSize = true;
                    l1.Name = "faculty_" + people.faculty[i].username;
                    l1.Text = people.faculty[i].name;
                    l1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
                    peopleTable.Controls.Add(l1, col, row);
                }
            }
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel l = sender as LinkLabel;
            PeopleWin pwin = new PeopleWin(l.Name);
            pwin.Show();
        }

        private void researchTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            while (byAreaTable.RowStyles.Count > 0)
            {
                byAreaTable.RowStyles.RemoveAt(0);
            }
            while (byAreaTable.ColumnStyles.Count > 0)
            {
                byAreaTable.ColumnStyles.RemoveAt(0);
            }

            while (byFacultyTable.RowStyles.Count > 0)
            {
                byFacultyTable.RowStyles.RemoveAt(0);
            }
            while (byFacultyTable.ColumnStyles.Count > 0)
            {
                byFacultyTable.ColumnStyles.RemoveAt(0);
            }


            int currentIndex = reseach_tabs.SelectedIndex;
            switch (currentIndex)
            {
                case 0:
                    List<ByInterestArea> interestArea = research.byInterestArea;
                    byAreaTable.Controls.Clear();
                    byAreaTable.RowCount = interestArea.Count / 3;
                    byAreaTable.ColumnCount = 3;
                    for (int i = 0; i < byAreaTable.RowCount; i++)
                    {
                        byAreaTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / byAreaTable.RowCount));
                    }
                    for (int i = 0; i < byAreaTable.ColumnCount; i++)
                    {
                        byAreaTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                    }

                    int row = -1, col = 0;
                    for (int i = 0; i < interestArea.Count; i++)
                    {
                        if (i % 3 == 0)
                        {
                            row += 1;
                            col = 0;
                        }
                        else
                        {
                            col += 1;
                        }
                        //MessageBox.Show(people.faculty[i].name);
                        LinkLabel l1 = new LinkLabel();
                        l1.VisitedLinkColor = Color.Blue;
                        l1.ActiveLinkColor = Color.Blue;
                        l1.LinkColor = Color.Blue;
                        l1.Visible = true;
                        l1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Underline);
                        l1.LinkArea = new LinkArea(0, 100);
                        l1.MaximumSize = new Size(200, 100);
                        l1.AutoSize = true;
                        l1.Name = "area_" + i;
                        l1.Text = interestArea[i].areaName;
                        l1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.researchLabel_LinkClicked);
                        byAreaTable.Controls.Add(l1, col, row);
                    }
                    break;
                case 1:
                    List<ByFaculty> faculty = research.byFaculty;
                    byFacultyTable.Controls.Clear();
                    byFacultyTable.RowCount = faculty.Count / 3;
                    byFacultyTable.ColumnCount = 3;
                    for (int i = 0; i < byFacultyTable.RowCount; i++)
                    {
                        byFacultyTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / byAreaTable.RowCount));
                    }
                    for (int i = 0; i < byFacultyTable.ColumnCount; i++)
                    {
                        byFacultyTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                    }

                    row = -1; col = 0;
                    for (int i = 0; i < faculty.Count; i++)
                    {
                        if (i % 3 == 0)
                        {
                            row += 1;
                            col = 0;
                        }
                        else
                        {
                            col += 1;
                        }
                        //MessageBox.Show("Aala");
                        LinkLabel l1 = new LinkLabel();
                        l1.VisitedLinkColor = Color.Blue;
                        l1.ActiveLinkColor = Color.Blue;
                        l1.LinkColor = Color.Blue;
                        l1.Visible = true;
                        l1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Underline);
                        l1.LinkArea = new LinkArea(0, 100);
                        l1.MaximumSize = new Size(200, 100);
                        l1.AutoSize = true;
                        l1.Name = "faculty_" + i;
                        l1.Text = faculty[i].facultyName;
                        l1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.researchLabel_LinkClicked);
                        byFacultyTable.Controls.Add(l1, col, row);
                    }
                    break;
            }
        }
        private void researchLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResearchWin pwin;
            string label = (sender as LinkLabel).Name;
            string[] labelParts = label.Split('_');
            int index = 0;
            Int32.TryParse(labelParts[1], out index);
            if (labelParts[0].Equals("area"))
            {
                pwin = new ResearchWin(research.byInterestArea[index].citations);
            }
            else
            {
                pwin = new ResearchWin(research.byFaculty[index].citations);
            }
            pwin.Show();
        }

    private void resourcesTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currentIndex = resourcesTabs.SelectedIndex;
            switch (currentIndex)
            {
                case 0:
                    studyAbroad_label1.Text = resources.studyAbroad.title;
                    studyAbroad_label2.Text = resources.studyAbroad.description;
                    studyAbroad_label3.Text = "Places";
                    studyAbroad_label4.Text = resources.studyAbroad.places[0].nameOfPlace;
                    studyAbroad_label5.Text = resources.studyAbroad.places[0].description;
                    studyAbroad_label6.Text = resources.studyAbroad.places[1].nameOfPlace;
                    studyAbroad_label7.Text = resources.studyAbroad.places[1].description;
                    break;
                case 1:
                    studServicesTab_SelectedIndexChanged(this, EventArgs.Empty);
                    break;
                case 2:
                    tut_label1.Text = resources.tutorsAndLabInformation.title;
                    tut_label2.Text = resources.tutorsAndLabInformation.description;
                    break;
                case 3:
                    studAm_label1.Text = resources.studentAmbassadors.title;
                    List<string> controls = new List<string>();
                    foreach (SubSectionContent cont in resources.studentAmbassadors.subSectionContent)
                    {
                        controls.Add(cont.title);
                    }
                    studAm_listBox1.DataSource = controls;
                    studAm_label4.Text = "note: " + resources.studentAmbassadors.note;
                    break;
                case 4:
                    forms_label1.Text = "Forms";
                    forms_label2.Text = "Click on the form to view URL";
                    for (int i = 0; i < resources.forms.graduateForms.Count; i++)
                    {
                        LinkLabel l1 = new LinkLabel();
                        l1.VisitedLinkColor = Color.Blue;
                        l1.ActiveLinkColor = Color.Blue;
                        l1.LinkColor = Color.Blue;
                        l1.Visible = true;
                        l1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Underline);
                        l1.LinkArea = new LinkArea(0, 100);
                        l1.MaximumSize = new Size(200, 100);
                        l1.AutoSize = true;
                        l1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.getForm);
                        l1.Name = "form_" + i;
                        l1.Text = resources.forms.graduateForms[i].formName;
                        forms_tableLayoutPanel1.Controls.Add(l1, i % 2, i / 2);
                    }
                    LinkLabel l2 = new LinkLabel();
                    l2.VisitedLinkColor = Color.Blue;
                    l2.ActiveLinkColor = Color.Blue;
                    l2.LinkColor = Color.Blue;
                    l2.Visible = true;
                    l2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Underline);
                    l2.LinkArea = new LinkArea(0, 100);
                    l2.MaximumSize = new Size(200, 100);
                    l2.AutoSize = true;
                    l2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.getForm);
                    l2.Name = "form_" + 7;
                    l2.Text = resources.forms.undergraduateForms[0].formName;
                    forms_tableLayoutPanel1.Controls.Add(l2, 1, 3);
                    break;
                case 5:
                    coop_label1.Text = resources.coopEnrollment.title;
                    coop_linkLabel1.Text = "Job Zone";
                    List<string> controls1 = new List<string>();
                    foreach (EnrollmentInformationContent coop in resources.coopEnrollment.enrollmentInformationContent)
                    {
                        controls1.Add(coop.title);
                    }
                    coop_listBox1.DataSource = controls1;
                    break;
            }
        }

        private void studServicesTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currentIndex = studServicesTabs.SelectedIndex;
            switch (currentIndex)
            {
                case 0:
                    acad_label1.Text = resources.studentServices.academicAdvisors.title;
                    acad_label2.Text = resources.studentServices.academicAdvisors.description;
                    acad_label3.Text = "Click here to view FAQs";
                    acad_label3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.faq_LinkClicked);
                    break;
                case 1:
                    proad_label1.Text = resources.studentServices.professonalAdvisors.title;
                    proad_label2.Text = resources.studentServices.professonalAdvisors.advisorInformation[0].name;
                    proad_label3.Text = resources.studentServices.professonalAdvisors.advisorInformation[0].department;
                    proad_label4.Text = resources.studentServices.professonalAdvisors.advisorInformation[0].email;
                    proad_label5.Text = resources.studentServices.professonalAdvisors.advisorInformation[1].name;
                    proad_label6.Text = resources.studentServices.professonalAdvisors.advisorInformation[1].department;
                    proad_label7.Text = resources.studentServices.professonalAdvisors.advisorInformation[1].email;
                    proad_label8.Text = resources.studentServices.professonalAdvisors.advisorInformation[2].name;
                    proad_label9.Text = resources.studentServices.professonalAdvisors.advisorInformation[2].department;
                    proad_label10.Text = resources.studentServices.professonalAdvisors.advisorInformation[2].email;
                    break;
                case 2:
                    facad_label1.Text = resources.studentServices.facultyAdvisors.title;
                    facad_label2.Text = resources.studentServices.facultyAdvisors.description;
                    break;
                case 3:
                    istad_label1.Text = resources.studentServices.istMinorAdvising.title;
                    foreach (MinorAdvisorInformation mi in resources.studentServices.istMinorAdvising.minorAdvisorInformation)
                    {
                        ListViewItem item = new ListViewItem(new String[] {
                            mi.title,
                            mi.advisor,
                            mi.email
                        });
                        istAd_list.Items.Add(item);
                    }
                    break;
            }
        }

        private void faq_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(resources.studentServices.academicAdvisors.faq.contentHref);
        }

        private void studAm_listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = studAm_listBox1.SelectedIndex;
            studAm_label2.Text = resources.studentAmbassadors.subSectionContent[index].title;
            studAm_label3.Text = resources.studentAmbassadors.subSectionContent[index].description;
            if (index == 6)
            {
                studAm_label3.Text += "Google Form: " + resources.studentAmbassadors.applicationFormLink;
            }
        }

        private void getForm(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            Int32.TryParse((sender as LinkLabel).Name.Split('_')[0], out i);
            if (i < 7)
            {
                MessageBox.Show("http://ist.rit.edu/" + resources.forms.graduateForms[i].href);
            } else
            {
                MessageBox.Show("http://ist.rit.edu/" + resources.forms.undergraduateForms[0].href);
            }
            
        }

        private void coop_linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(resources.coopEnrollment.RITJobZoneGuidelink);
        }

        private void coop_listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = coop_listBox1.SelectedIndex;
            coop_label3.Text = resources.coopEnrollment.enrollmentInformationContent[index].title;
            coop_label4.Text = resources.coopEnrollment.enrollmentInformationContent[index].description;
        }

        private void links_linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(links.social.twitter);
        }

        private void links_linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(links.social.facebook);
        }

        private void links_linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(links.quickLinks[0].href);
        }

        private void links_linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(links.quickLinks[1].href);
        }

        private void links_linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(links.quickLinks[2].href);
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(links.quickLinks[3].href);
        }
    }
}

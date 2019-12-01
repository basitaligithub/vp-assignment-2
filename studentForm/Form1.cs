using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace studentForm
{
    public partial class Form1 : Form
    {
       
        string textfilepath = @"C:\Users\basit\Desktop\studentForm\file.txt";

        List<Student> myList = new List<Student>();
        int x = 0;
        Student obj = new Student();
        Label[] lblids;
        Label[] lblnames;
        RadioButton[] RDpresent;
        RadioButton[] RDabsent;
        bool created = false;

        void clearFields()
        {
            textbox_AddName.Clear();
            textbox_AddID.Clear();
            textbox_AddCGPA.Clear();
            textbox_AddSem.ResetText();
            textbox_AddDept.Clear();
            textbox_AddUni.Clear();
        }
       
           
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel_AddStudent.Visible = false;
            panel_search.Visible = false;
            panel_deleteRecord.Visible = false;
            panel_searchByID.Visible = false;
            panel_searchByName.Visible = false;
            panel_listallstds.Visible = false;
            panel_top3.Visible = false;
            panel_MarkAttnd.Visible = false;
            StreamReader newfile = new StreamReader(textfilepath);
            while (!newfile.EndOfStream)
            {
                myList.Add(new Student());
                myList[x].name = newfile.ReadLine();
                myList[x].ID = newfile.ReadLine();
                myList[x].cgpa = Convert.ToDecimal(newfile.ReadLine());
                myList[x].semester = Convert.ToInt32(newfile.ReadLine());
                myList[x].dept = newfile.ReadLine();
                myList[x].uni = (newfile.ReadLine());
                myList[x].attendance = newfile.ReadLine();
                x++;
            }
            newfile.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (addstudentradio.Checked==true)
            {
                panel_AddStudent.Visible = true;
            }
            else if (searchstdradio.Checked==true)
            {
                panel_search.Visible = true;
            }
            else if (delstdradio.Checked == true)
            {
                panel_deleteRecord.Visible = true; 
            }
            else if (markattndradio.Checked == true)
            {
                panel_MarkAttnd.Visible = true;
            }
            else if (viewattndreport.Checked == true)
            {
                
            }
            else if (top3radio.Checked == true)
            {
                panel_top3.Visible = true;
            }
            panel1.Visible = false;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)   //------------create profile button-------------
        {

            myList.Add(new Student());
            myList[x].name = textbox_AddName.Text;
            myList[x].ID = textbox_AddID.Text;
            myList[x].cgpa = Convert.ToDecimal(textbox_AddCGPA.Text);
            myList[x].semester = Convert.ToInt32(textbox_AddSem.Text);
            myList[x].dept = textbox_AddDept.Text;
            myList[x].uni = textbox_AddUni.Text;
            myList[x].attendance = "present";
            myList[x].CreateNewProfile(textfilepath);
            x++;
            MessageBox.Show("Profile is Successfully Created ");
            clearFields();

        }

        private void button2_Click_1(object sender, EventArgs e)  //switching to main menu button
        {
            panel_AddStudent.Visible = false;
            panel1.Visible = true;
        }

        private void panel_search_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)         //switching to main menu button
        {
            panel_search.Visible = false;
            panel1.Visible = true;
        }

        private void searchOpBtn_Click(object sender, EventArgs e)
        {
            if (radioSearchByName.Checked==true)
            {
                panel_searchByName.Visible = true;
            }
            else if (radioSearchByID.Visible==true)
            {
                panel_searchByID.Visible = true;
            }
            else if (radio_allStudents.Checked==true)
            {
                panel_listallstds.Visible = true;
            }
            panel_search.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel_deleteRecord.Visible = false;
        }

        private void btn_searchByID_Click(object sender, EventArgs e)    //searching through ID
        {
            grid_searchByID.Columns.Clear();
            grid_searchByID.Rows.Clear();

            grid_searchByID.ColumnCount = 6;
            grid_searchByID.Columns[0].Name = "Name";
            grid_searchByID.Columns[1].Name = "ID";
            grid_searchByID.Columns[2].Name = "CGPA";
            grid_searchByID.Columns[3].Name = "Semester";
            grid_searchByID.Columns[4].Name = "Department";
            grid_searchByID.Columns[5].Name = "University";
                for (int i = 0; i < myList.Count; i++)
                {
                    if (TextBox_searchByID.Text.ToString() == myList[i].ID.ToString())
                    {
                        string[] row = new string[] { myList[i].name.ToString(), myList[i].ID.ToString(), myList[i].cgpa.ToString(), myList[i].semester.ToString(), myList[i].dept.ToString(), myList[i].uni.ToString() };
                        grid_searchByID.Rows.Add(row);
                        break;
                    }
                }
            TextBox_searchByID.ResetText();
        }

        private void btn_goBack_Click(object sender, EventArgs e)
        {
            panel_searchByID.Visible = false;
            panel_search.Visible = true;
        }

        private void btn_mainManu_Click(object sender, EventArgs e)
        {
            panel_searchByID.Visible = false;
            panel1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel_searchByName.Visible = false;
            panel_search.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel_searchByName.Visible = false;
            panel1.Visible = true;
        }

        private void panel_listallstds_Paint(object sender, PaintEventArgs e)    //listing all students
        {
            grid_viewAll.Visible = true;
            grid_viewAll.Columns.Clear();
            grid_viewAll.Rows.Clear();
            grid_viewAll.ColumnCount = 6;
            grid_viewAll.Columns[0].Name = "Name";
            grid_viewAll.Columns[1].Name = "ID";
            grid_viewAll.Columns[2].Name = "CGPA";
            grid_viewAll.Columns[3].Name = "Semester";
            grid_viewAll.Columns[4].Name = "Department";
            grid_viewAll.Columns[5].Name = "University";
            for (int i = 0; i < myList.Count; i++)
            {
                string[] row = new string[] { myList[i].name.ToString(), myList[i].ID.ToString(), myList[i].cgpa.ToString(), myList[i].semester.ToString(), myList[i].dept.ToString(), myList[i].uni.ToString() };
                grid_viewAll.Rows.Add(row);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel_listallstds.Visible = false;
            panel_search.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel_listallstds.Visible = false;
            panel1.Visible = true;
        }

        private void btn_searchByName_Click(object sender, EventArgs e)   //searching by name
        {
            grid_searchByName.Visible = true;
            grid_searchByName.Columns.Clear();
            grid_searchByName.Rows.Clear();
            grid_searchByName.ColumnCount = 6;
            grid_searchByName.Columns[0].Name = "Name";
            grid_searchByName.Columns[1].Name = "ID";
            grid_searchByName.Columns[2].Name = "CGPA";
            grid_searchByName.Columns[3].Name = "Semester";
            grid_searchByName.Columns[4].Name = "Department";
            grid_searchByName.Columns[5].Name = "University";

            for (int i = 0; i < myList.Count; i++)
            {
                if (TextBox_searchByName.Text.ToString() == myList[i].name.ToString())
                {
                    string[] row = new string[] { myList[i].name.ToString(), myList[i].ID.ToString(), myList[i].cgpa.ToString(), myList[i].semester.ToString(), myList[i].dept.ToString(), myList[i].uni.ToString() };
                    grid_searchByName.Rows.Add(row);
                    break;
                }
            }
            TextBox_searchByName.ResetText();
        }

        private void btn_delstd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_deleterecord.Text))
            {
                MessageBox.Show("Id Field is empty");

            }
            else
            {
                bool check = false;
                for (int i = 0; i < myList.Count; i++)
                {
                    if (textBox_deleterecord.Text.ToString() == myList[i].ID.ToString())
                    {
                        myList.RemoveAt(i);
                        check = true;
                        x--;
                        break;
                    }
                }
                if (check == true)
                {
                    Student obj = new Student();
                    MessageBox.Show("Record Was Successfully Deleted");
                    obj.deleteRecord(textfilepath, myList);
                    
                }
                else
                {
                    MessageBox.Show("Search Id is not Found");
                }
            }
            textBox_deleterecord.Clear();
        }

        private void panel_top3_Paint(object sender, PaintEventArgs e)
        {
            myList.Sort(delegate (Student x, Student y)
            {
                return y.cgpa.CompareTo(x.cgpa);
            });

            grid_top3.Columns.Clear();
            grid_top3.Rows.Clear();
            grid_top3.ColumnCount = 7;
            grid_top3.Columns[0].Name = "Position";
            grid_top3.Columns[1].Name = "Id";
            grid_top3.Columns[2].Name = "Name";
            grid_top3.Columns[3].Name = "Semester";
            grid_top3.Columns[4].Name = "CGPA";
            grid_top3.Columns[5].Name = "Department";
            grid_top3.Columns[6].Name = "University";
            float first = 0;
            float second = 0;
            float third = 0;
            for (int i = 0; i < myList.Count; i++)
            {
                if ((float)Convert.ToDouble(myList[i].cgpa.ToString()) > first)
                {
                    third = second;
                    second = first;
                    first = (float)Convert.ToDouble(myList[i].cgpa.ToString());
                }
                else if ((float)Convert.ToDouble(myList[i].cgpa.ToString()) > second)
                {
                    third = second;
                    second = (float)Convert.ToDouble(myList[i].cgpa.ToString());
                }
                else if (second > (float)Convert.ToDouble(myList[i].cgpa.ToString()) && (float)Convert.ToDouble(myList[i].cgpa.ToString()) > third)
                {
                    third = (float)Convert.ToDouble(myList[i].cgpa.ToString());
                }
            }

            for (int i = 0; i < myList.Count; i++)
            {
                if ((float)Convert.ToDouble(myList[i].cgpa.ToString()) == first)
                {
                    string[] row = new string[] { "1st.", myList[i].ID.ToString(), myList[i].name.ToString(), myList[i].semester.ToString(), myList[i].cgpa.ToString(), myList[i].dept.ToString(), myList[i].uni.ToString() };
                    grid_top3.Rows.Add(row);
                }
                else if ((float)Convert.ToDouble(myList[i].cgpa.ToString()) == second)
                {
                    string[] row = new string[] { "2nd.", myList[i].ID.ToString(), myList[i].name.ToString(), myList[i].semester.ToString(), myList[i].cgpa.ToString(), myList[i].dept.ToString(), myList[i].uni.ToString() };
                    grid_top3.Rows.Add(row);
                }
                else if ((float)Convert.ToDouble(myList[i].cgpa.ToString()) == third)
                {
                    string[] row = new string[] { "3rd.", myList[i].ID.ToString(), myList[i].name.ToString(), myList[i].semester.ToString(), myList[i].cgpa.ToString(), myList[i].dept.ToString(), myList[i].uni.ToString() };
                    grid_top3.Rows.Add(row);
                }
            }
        }
    }
}

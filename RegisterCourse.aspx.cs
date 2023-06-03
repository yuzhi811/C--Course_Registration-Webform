using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab6
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        List<string> selectedCourses = new List<string>();
        public int WeeklyHoursSum = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (Course b in Helper.GetAvailableCourses())
                {
                    //chklst.Items.Add(new ListItem(b.Title, b.Code));
                    chklst.Items.Add(new ListItem(b.Title + " - " + b.WeeklyHours + " hours/week", b.Code));

                }
            }

            /* foreach (Course b in Helper.GetAvailableCourses())
             {
                 TableRow rowNew = new TableRow();
                 tblCourses.Rows.Add(rowNew);

                 TableCell cell = new TableCell();
                 rowNew.Cells.Add(cell);
                 cell.Text = b.Code;

                 cell = new TableCell();
                 rowNew.Cells.Add(cell);
                 cell.Text = b.Title;

                 cell = new TableCell();
                 rowNew.Cells.Add(cell);
                 cell.Text = b.WeeklyHours.ToString();
             }*/
        }
        bool validate = true;
        protected void submit_Click(object sender, EventArgs e)
        {
            ErrorMsgName.Visible = false;
            ErrorMsgFullTime.Visible = false;
            ErrorMsgPartTime.Visible    = false;
            ErrorMsgCoop1.Visible = false;
            ErrorMsgCoop2.Visible = false;

            //1. The user must enter a student name

            if (NameBox != null && !string.IsNullOrEmpty(NameBox.Value))
            {
                // The textbox is not empty
                string studentName = NameBox.Value;
            }
            else
            {
                //The textbox is empty
                ErrorMsgName.Visible = true;
                return;

            }

            /*  if (!string.IsNullOrEmpty(NameBox.Value))
              {
                  // The textbox is not empty
                  string studentName = NameBox.Value;
              }
              else
              {
                  //The textbox is empty
                  ErrorMsgName.Visible = true;
                  pnlResult.Visible = false;
                  pnlSelection.Visible = true;
              }*/

            foreach (ListItem item in chklst.Items)
            {
                if (item.Selected)
                {
                    //helper에서 course code를 list에 담기
                    selectedCourses.Add(item.Value);
                    Course course = Helper.GetCourseByCode(item.Value);
                    WeeklyHoursSum += course.WeeklyHours;

                }

                //got course codes from the list
                //for loop - 
                //Course courses = Helper.GetCourseByCode(item.Value);
                // getting weeklyhours from selectedCourses
                /*  foreach (string code in selectedCourses)
                  {                     
                      Course course = Helper.GetCourseByCode(item.Value);
                      // Course course = Helper.GetCourseByCode(code);
                      WeeklyHoursSum += course.WeeklyHours;}*/
            }
            //2. validation
            string selectedValue = RadioButtonList.SelectedValue;

            if (selectedValue == "Full Time")
            {
                if (WeeklyHoursSum > 16)
                {
                    ErrorMsgFullTime.Visible = true;
                    
                    return;
                }

            }
            else if (selectedValue == "Part Time")
            {
                int selectedCount = 0;

                foreach (ListItem it in chklst.Items)
                {
                    if (it.Selected)
                    {
                        selectedCount++;
                    }
                }

                if (selectedCount > 3)
                {
                    ErrorMsgPartTime.Visible = true;
                    return;

                }

            }
            else if (selectedValue == "Co-op")
            {
                // Do something if Co-op is selected
                int selectedCount = 0;

                foreach (ListItem it in chklst.Items)
                {
                    if (it.Selected)
                    {
                        selectedCount++;
                    }
                }

                if (selectedCount > 2)
                {
                    ErrorMsgCoop1.Visible = true;
                    return;
                }

                if (WeeklyHoursSum > 4)
                {
                    ErrorMsgCoop2.Visible = true;
                    return;
                }
            }


            bool noCourseSelected = true;
            foreach (ListItem lstItem in chklst.Items)
            {
                if (lstItem.Selected == true)
                {
                    noCourseSelected = false;

                    Course b = Helper.GetCourseByCode(lstItem.Value);

                    TableRow rowNew = new TableRow();
                    tblCourses.Rows.Add(rowNew);

                    TableCell cell = new TableCell();
                    rowNew.Cells.Add(cell);
                    cell.Text = b.Code;

                    cell = new TableCell();
                    rowNew.Cells.Add(cell);
                    cell.Text = b.Title;

                    cell = new TableCell();
                    rowNew.Cells.Add(cell);
                    cell.Text = b.WeeklyHours.ToString();

                }

            }
            TableRow rowNewTotal = new TableRow();
            tblCourses.Rows.Add(rowNewTotal);
            TableCell cellTotal = new TableCell();
            cellTotal.ColumnSpan = 3;
            rowNewTotal.Cells.Add(cellTotal);
            cellTotal.Text = "Total: " + WeeklyHoursSum;


            if (noCourseSelected)
            {
                TableRow rowNew = new TableRow();
                tblCourses.Rows.Add(rowNew);

                TableCell cell = new TableCell();
                rowNew.Cells.Add(cell);

                cell.ColumnSpan = 3;
                cell.Text = "No Course selected!";
                cell.ForeColor = System.Drawing.Color.Red;
            }

            pnlResult.Visible = true;
            pnlSelection.Visible = false;
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Lab6.Models
{
    public class Course
    {
        //properties
        public string Code { get; }
        public string Title { get; }
        public int WeeklyHours { get; set; }

        //one constructor taking two parameters
        public Course(string code, string title)
        {
            Code = code;
            Title = title;
        }

       
    }
}
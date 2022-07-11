using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FirstWebsite.Web.Models
{
    public class CalendarEvent
    {
        public string User { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public bool personalDisplay { get; set; }
    }
}
using FirstWebsite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWebsite.Web.Models
{
    public class IndexVM
    {
        public List<PTO> PTOs { get; set; }
        public List<OutOfOffice> OutOfOffices { get; set; }
        public List<Event> Events { get; set; }
        public List<User> Users { get; set;}
    }
}
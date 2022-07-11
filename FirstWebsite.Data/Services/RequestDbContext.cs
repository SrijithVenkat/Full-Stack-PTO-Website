using FirstWebsite.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWebsite.Data.Services
{
    public class RequestDbContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
    }
}

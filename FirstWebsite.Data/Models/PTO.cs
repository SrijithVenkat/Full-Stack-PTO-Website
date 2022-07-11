using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWebsite.Data.Models
{
    public class PTO : Request
    {
        [Required]
        public PTOType ptoType { get; set; }
        public PTO()
        {
            this.requestType = 1;
        }
    }
}

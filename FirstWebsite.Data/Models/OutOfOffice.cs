using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWebsite.Data.Models
{
    public class OutOfOffice : Request
    {
        [Required]
        public OOOType oooType { get; set; }
        public OutOfOffice()
        {
            this.requestType = 2;
        }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWebsite.Data.Models
{
    abstract public class Request
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int requestId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int requestType {get; set;}
        [Required]
        public int userID { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [UIHint("ShortDate")]
        public DateTime requestStartDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [UIHint("ShortDate")]
        public DateTime requestEndDate { get; set; }
        [Range(1,100)]
        public int daysOff { get; set; }
        [Required]
        public DateTime dateSubmitted { get; set; }
        public string requestDescription { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWebsite.Data.Models
{
    public class Event : Request
    {
        [Required]
        [Range(14,365)]
        public int previewDays { get; set; } = 14;
        [Required]
        public EventType eventType { get; set; }
        public bool recurringChoice { get; set; } = false;
        public int recurringDaysBetweenOccurrence { get; set; } = 0;
        public int recurringNumberOfDays { get; set; } = 0;
        public string htmlDesc { get; set; }

        public Event()
        {
            this.requestType = 3;
        }
    
    }
}

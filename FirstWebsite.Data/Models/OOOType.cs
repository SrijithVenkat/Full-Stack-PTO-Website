using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWebsite.Data.Models
{
    public enum OOOType
    {
        [Display(Name = "At Client Site")]
        [Description("At Client Site")]
        AT_CLIENT_SITE,
        [Display(Name = "Working From Home")]
        [Description("Working From Home")]
        WORKING_FROM_HOME,
        [Display(Name = "Conference")]
        [Description("Conference")]
        CONFERENCE,
        [Display(Name = "In Livonia Office")]
        [Description("In Livonia Office")]
        IN_LIVONIA_OFFICE
    }
}

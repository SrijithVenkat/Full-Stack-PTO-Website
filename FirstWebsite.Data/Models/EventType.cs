using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWebsite.Data.Models
{
    public enum EventType
    {
        [Display(Name = "Special Event")]
        [Description("Special Event")]
        SPECIAL_EVENT,
        [Display(Name = "Release")]
        [Description("Release")]
        RELEASE,
        [Display(Name = "Fitness")]
        [Description("Fitness")]
        FITNESS,
        [Display(Name = "General")]
        [Description("General")]
        GENERAL

    }
}

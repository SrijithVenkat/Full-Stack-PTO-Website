using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWebsite.Data.Models
{
    public enum PTOType
    {
        [Display(Name = "PTO")]
        [Description("PTO")]
        PTO,
        [Display(Name = "Floating Day")]
        [Description("Floating Day")]
        FLOATING_DAY,
        [Display(Name = "Half-Day")]
        [Description("Half-Day")]
        HALF_DAY,
        [Display(Name = "Bereavement")]
        [Description("PBereavementTO")]
        BEREAVEMENT,
        [Display(Name = "Leave")]
        [Description("Leave")]
        LEAVE,
        [Display(Name = "Sick Leave")]
        [Description("Sick Leave")]
        SICK_LEAVE,
        [Display(Name = "Jury Duty")]
        [Description("Jury Duty")]
        JURY_DUTY,
        [Display(Name = "Educational Time-Off")]
        [Description("Educational Time-Off")]
        EDUCATIONAL_TIMEOFF
    }
}

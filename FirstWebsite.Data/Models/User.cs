using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWebsite.Data.Models
{
    public class User
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }

        [Required]
        [MaxLength(50)]
        public string firstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string lastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [Required]
        [MaxLength(5)]
        [MinLength(5)]
        public string ZipCode { get; set; }
        public byte[] profilePicture { get; set; }
        [Required]
        public StatesAbbrev State { get; set; }
        [Required]
        public DateTime hireDate { get; set; }
        public DateTime anniversaryDate { get; set; }
        [Required]
        public Boolean isApprover { get; set; }
        [Required]
        public Boolean isAdmin { get; set; }
        public Boolean isActive { get; set; }
        
        [Required]
        public string userName { get; set; }

        public string passWord { get; set; }
        public string FullName()
        {
            return this.firstName + " " + this.lastName;
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobFair.Models
{
    [Table("Register")]
    public class Register
    {
        [Display(Name = "Reg Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Rid { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }
        [Display(Name = "Role")]
        [Required]
        [DefaultValue("1")]
        public string Role { get; set; }

        #region Navigation Properties to the Company Model

        public ICollection<Company> Companies { get; set; }

        public ICollection<Seeker> Seekers { get; set; }

        #endregion

    }
}

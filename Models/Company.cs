using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobFair.Models
{
    [Table("Company")]
    public class Company
    {
        [Required]
        [Display(Name ="CompanyId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cid { get; set; }

        [Display (Name = "Company Name")]
        [Required]
        public string CompanyName { get; set; }

        [Display(Name ="Hiring Date")]
        [Required]
        public string HiringDate { get; set; }

        [Display(Name ="Description")]
        [Required]
        public string Description { get; set; }

        [Display(Name ="Criteria")]
        [Required]
        public string Criteria { get; set; }

        [Display(Name ="Vacancies")]
        [Required]
        public string Vacancies { get; set; }

        [Display(Name ="Package")]
        [Required]
        public int Package { get; set; }

        [Display(Name ="Apply Link")]
        [Required]
        public string ApplyLink { get; set; }

        #region Navigation Properties to the Register Model

        [Display(Name = "Reg Id")]
        [Column("Rid")]  // Name of the column in register table
        [ForeignKey(nameof(Company.Register))] //foreign key to object in current model
        public int Rid { get; set; }

        public Register Register { get; set; }

        #endregion
        #region Navigation Properties to the Interested Candidate Model

        public ICollection<SelecetedCandidate> SelecetedCandidates { get; set; }

        public ICollection<InterestedCandidate> InterestedCandidates { get; set; }

        #endregion
    }
}

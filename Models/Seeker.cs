using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobFair.Models
{
    [Table("Seeker")]
    public class Seeker
    {
        [Display(Name ="Seeker Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sid { get; set; }

        [Display(Name ="Seeker Name")]
        [Required]
        public string SeekerName { get; set; }

        [Display(Name ="Highest Qualification")]
        [Required]
        public string HighestQualification { get; set; }

        [Display(Name ="Percentage")]
        [Required]
        public string Percentage { get; set; }

        [Display(Name ="Skills")]
        [Required]
        public string Skills { get; set; }

        [Display(Name ="Status")]
        [Required]
        public string Status { get; set; }

        #region Navigation Properties to the Register Model

        [Display(Name = "Reg Id")]
        [Required]
        [Column("Rid")]  // Name of the column in register table
        [ForeignKey(nameof(Seeker.Register))] //foreign key to object in current model
        public int Rid { get; set; }

        public Register Register { get; set; }

        #endregion
        #region Navigation Properties to the Interested Candidate Model

        public ICollection<SelecetedCandidate> SelecetedCandidates  { get; set; }

        public ICollection<InterestedCandidate> InterestedCandidates { get; set; }

        #endregion
    }
}

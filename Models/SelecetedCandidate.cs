using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobFair.Models
{
    [Table("SelectedCandidate")]

    public class SelecetedCandidate
    {
        [Display(Name = "SelectedCandidateId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Scid { get; set; }

        #region Navigation Properties to the Company & Seeker Model

        [Display(Name = "Candidate Id")]
        [Required]
        [Column("Cid")]  // Name of the column in company table
        [ForeignKey(nameof(InterestedCandidate.Company))] //foreign key to object in current model
        public int Cid { get; set; }

        public Company Company { get; set; }



        [Display(Name = "Seeker Id")]
        [Required]
        [Column("Sid")] // Name of the column in Seeker table
        [ForeignKey(nameof(InterestedCandidate.Seeker))] //foreign key to object in current model
        public int Sid { get; set; }

        public Seeker Seeker { get; set; }

        #endregion
    }
}
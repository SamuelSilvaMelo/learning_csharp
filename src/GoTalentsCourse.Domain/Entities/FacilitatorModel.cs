using System;
using System.ComponentModel.DataAnnotations;
using GoTalentsCourse.AbstractClasses;
using GoTalentsCourse.Types;

namespace GoTalentsCourse.Models
{
    public class FacilitatorModel : Person
    {
        [Key]
        public int Id { get; set; }

        [EnumDataType(typeof(Speciality))]
        [Required(ErrorMessage = "Speciality is required")]
        public Speciality? Speciality { get; set; }

        public FacilitatorModel() : base() {}
    }
}

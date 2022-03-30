using System;
using System.ComponentModel.DataAnnotations;
using GoTalentsCourse.AbstractClasses;
using GoTalentsCourse.Types;

namespace GoTalentsCourse.Models
{
    public class FacilitatorModel : Person
    {
        public Guid FacilitatorId { get; set; }

        [EnumDataType(typeof(Speciality))]
        [Required(ErrorMessage = "Speciality is required")]
        public Speciality? Speciality { get; set; }

        public FacilitatorModel() : base()
        {
            FacilitatorId = Guid.NewGuid();
        }

        public FacilitatorModel(
           string userName,
           string birthDate,
           GenderType gender,
           string email,
           string cpf,
           string nickName,
           string password,
           RoleType role,
           Speciality speciality
        ) : base(
            userName,
            birthDate,
            gender,
            email,
            cpf,
            nickName,
            password,
            role
        )
        {
            Speciality = speciality;
            FacilitatorId = Guid.NewGuid();
        }
    }
}

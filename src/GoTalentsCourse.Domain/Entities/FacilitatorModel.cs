using System;
using GoTalentsCourse.AbstractClasses;
using GoTalentsCourse.Types;

namespace GoTalentsCourse.Models
{
    public class FacilitatorModel : Person
    {
        public Guid FacilitatorId { get; private set; }
        public Speciality Speciality { get; }

        public FacilitatorModel(
           string userName,
           // string birthDate,
           GenderType gender,
           string email,
           string cpf,
           string nickName,
           string password,
           RoleType role,
           Speciality speciality
        ) : base(
            userName,
            // birthDate,
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

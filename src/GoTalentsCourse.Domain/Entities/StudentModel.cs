using System;
using System.Text.Json.Serialization;
using GoTalentsCourse.AbstractClasses;
using GoTalentsCourse.Types;

namespace GoTalentsCourse.Models
{
    public class StudentModel : Person
    {
        public Guid StudentId { get; private set; }
        // Adicionar Challenges

        public StudentModel() : base()
        {
            StudentId = Guid.NewGuid();
        }

        public StudentModel(
            string userName,
            string birthDate,
            GenderType gender,
            string email,
            string cpf,
            string nickName,
            string password,
            RoleType role
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
            StudentId = Guid.NewGuid();
        }
    }
}

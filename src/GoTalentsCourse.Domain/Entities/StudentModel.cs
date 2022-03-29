using System;
using Course_API.AbstractClasses;
using Course_API.Types;

namespace Course_API.Models
{
    public class StudentModel : Person
    {
        public Guid StudentId { get; private set; }
        // Adicionar Challenges

        public StudentModel(
            string userName,
            // string birthDate,
            GenderType gender,
            string email,
            string cpf,
            string nickName,
            string password,
            RoleType role
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
            StudentId = Guid.NewGuid();
        }
    }
}

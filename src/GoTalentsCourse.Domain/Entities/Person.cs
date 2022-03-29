using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Course_API.Types;

namespace Course_API.AbstractClasses

{
    public abstract class Person
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "User name is required")]
        [StringLength(maximumLength: 100, MinimumLength = 10, ErrorMessage = "The name must have a minimum length of 10 and a maximum length of 100")]
        public string UserName { get; protected set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Birth Data is required")]
        public DateTime BirthDate { get; protected set; }

        [Required(ErrorMessage = "The sex field is required")]
        public GenderType Gender { get; protected set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; protected set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "CPF is required")]
        public string CPF { get; protected set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Nick Name is Required")]
        public string NickName { get; protected set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required")]
        public string Password { get; protected set; }

        [Required]
        public RoleType Role { get; protected set; }

        public Person(
            string userName,
            // string birthDate,
            GenderType gender,
            string email,
            string cpf,
            string nickName,
            string password,
            RoleType role
        )
        {
            UserName = userName;
            // BirthDate = DateTime.Parse(birthDate);
            Gender = gender;
            Email = email;
            CPF = cpf;
            NickName = nickName;
            Password = password;
            Role = role;
        }
    }
}

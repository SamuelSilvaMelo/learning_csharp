using System;
using System.ComponentModel.DataAnnotations;
using GoTalentsCourse.Types;

namespace GoTalentsCourse.AbstractClasses

{
    public abstract class Person
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "User name is required")]
        [StringLength(maximumLength: 100, MinimumLength = 10, ErrorMessage = "The name must have a minimum length of 10 and a maximum length of 100")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Birth Data is required")]
        public DateTime? BirthDate { get; set; }

        [EnumDataType(typeof(GenderType))]
        [Required(ErrorMessage = "Gender is required")]
        public GenderType? Gender { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "CPF is required")]
        public string CPF { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Nick Name is Required")]
        public string NickName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        [EnumDataType(typeof(RoleType))]
        [Required(ErrorMessage = "Role is required")]
        public RoleType? Role { get; set; }

        public Person() {}
    }
}

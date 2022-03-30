using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using GoTalentsCourse.AbstractClasses;
using GoTalentsCourse.Types;

namespace GoTalentsCourse.Models
{
    public class StudentModel : Person
    {
        [Key]
        public int Id { get; set; }
        // Adicionar Challenges

        public StudentModel() : base() {}
    }
}

using GoTalentsCourse.Types;

namespace GoTalentsCourse.Models.ViewModels
{
    public class StudentViewModel
    {
        public StudentViewModel() { }
            
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public RoleType? Role { get; set; }
    }
}

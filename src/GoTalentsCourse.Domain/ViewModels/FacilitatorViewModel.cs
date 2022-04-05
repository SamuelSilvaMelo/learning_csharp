using GoTalentsCourse.Types;

namespace GoTalentsCourse.Models.ViewModels
{
    public class FacilitatorViewModel
    {
        public FacilitatorViewModel() { }
            
        public int Id { get; set; }
        public string NickName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public RoleType? Role { get; set; }
    }
}

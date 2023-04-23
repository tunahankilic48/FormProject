using Microsoft.AspNetCore.Identity;

namespace FormProject.Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
        //Navigation Property
        public List<Form> Forms { get; set; }
    }
}

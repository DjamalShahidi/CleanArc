using CleanArc.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace CleanArc.Domain.Entities.User
{
    public class User : IdentityUser<int>, IEntity
    {
        public User()
        {
            this.GeneratedCode = Guid.NewGuid().ToString()[..8];
        }

        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string GeneratedCode { get; set; }
    }
}

using CleanArc.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace CleanArc.Domain.Entities.User
{
    public class Role:IdentityRole<int>,IEntity
    {
        public string DisplayName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

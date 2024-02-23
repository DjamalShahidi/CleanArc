using Demo.Domain.Common;
using System.Security.Principal;

namespace Demo.Domain
{
    public class Book :BaseDomainEntity
    {
        public string Title { get; set; }

        public int Count { get; set; }

        public bool IsDleted { get; set; }
    }
}

using Demo.Domain.Common;

namespace Demo.Domain
{
    public class Book :BaseDomainEntity
    {
        public string Title { get; set; }

        public int Count { get; set; }

        public bool IsDeleted { get; set; }
    }
}

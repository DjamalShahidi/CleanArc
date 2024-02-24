namespace Demo.Domain.Common
{
    public class BaseDomainEntity
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}

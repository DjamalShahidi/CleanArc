namespace CleanArc.Domain.Common
{
    public abstract class BaseEntity<TKey> : IEntity, ITimeModification
    {
        public TKey Id { get; protected set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public abstract class BaseEntity : BaseEntity<int>
    {

    }
}

namespace CleanArc.Domain.Common
{
    public interface ITimeModification
    {
        DateTime CreateDate { get; set; }
        DateTime? ModifiedDate { get; set; }
    }
}

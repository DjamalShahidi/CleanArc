using CleanArc.Domain.Common;

namespace CleanArc.Domain.Entities.Order
{
    public class Order:BaseEntity
    {
        public string OrderName { get; set; }
        public bool IsDeleted { get; set; }
        public User.User User { get; set; }

    }
}

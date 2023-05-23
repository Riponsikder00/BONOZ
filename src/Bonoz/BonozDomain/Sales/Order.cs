namespace BonozDomain.Sales
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus Status { get; set; }
    }
}

namespace BonozDomain.Sales
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User Sender { get; set; }
        //public int ReceiverId { get; set; }
        //public User Receiver { get; set; }
        public string Message { get; set; }
        public DateTime SentDateTime { get; set; }
    }

}

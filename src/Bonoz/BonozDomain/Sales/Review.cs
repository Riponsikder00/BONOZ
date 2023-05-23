﻿namespace BonozDomain.Sales
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }

}

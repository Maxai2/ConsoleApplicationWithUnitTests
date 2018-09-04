namespace ConsoleApplication.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int Count { get; set; }
        public bool Delivered { get; set; }
        public string Buyer { get; set; }

        public Order()
        {

        }

        public Order(string product, int count, string buyer)
        {
            Product = product;
            Count = count;
            Buyer = buyer;
        }
    }
}

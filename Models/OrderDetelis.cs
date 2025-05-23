using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class OrderDetelis
    {
         public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}

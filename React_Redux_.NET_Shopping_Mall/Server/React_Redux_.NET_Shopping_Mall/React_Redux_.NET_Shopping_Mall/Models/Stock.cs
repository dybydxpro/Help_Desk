using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace React_Redux_.NET_Shopping_Mall.Data
{
    public class Stock
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public int AvailableQty { get; set; }
        public double UnitPrice { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class StockAdd
    {
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public int AvailableQty { get; set; }
        public double UnitPrice { get; set; }
    }
}
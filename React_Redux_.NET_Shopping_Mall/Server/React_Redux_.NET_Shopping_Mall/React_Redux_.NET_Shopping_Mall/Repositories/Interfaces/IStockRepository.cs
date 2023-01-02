using React_Redux_.NET_Shopping_Mall.Data;

namespace React_Redux_.NET_Shopping_Mall.Repositories.Interfaces
{
    public interface IStockRepository
    {
        public List<Stock> GetStock();

        public Stock GetStockById(int id);

        public bool PostStock(StockAdd obj);

        public bool PutStock(Stock obj);

        public bool DeleteStock(int id);
    }
}

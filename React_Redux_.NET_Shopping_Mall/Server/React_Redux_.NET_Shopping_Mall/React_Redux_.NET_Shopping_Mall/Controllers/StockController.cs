using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using React_Redux_.NET_Shopping_Mall.Data;
using React_Redux_.NET_Shopping_Mall.Repositories.Interfaces;

namespace React_Redux_.NET_Shopping_Mall
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;

        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Stock>>> GetAllStock()
        {
            List<Stock> stock = _stockRepository.GetStock().ToList();
            return Ok(stock);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Stock>>> GetStockById(int id)
        {
            Stock stock = _stockRepository.GetStockById(id);
            return Ok(stock);
        }

        [HttpPost]
        public async Task<ActionResult<List<Stock>>> PostStock(StockAdd obj)
        {
            if (ModelState.IsValid)
            {
                var isOK = _stockRepository.PostStock(obj);
                return Ok(isOK);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<Stock>>> PutStock(Stock obj)
        {
            if (ModelState.IsValid)
            {
                var isOK = _stockRepository.PutStock(obj);
                return Ok(isOK);
            }
            else
            {
                return BadRequest("Something Wrong!");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Stock>>> DeleteStock(int id)
        {
            if (_stockRepository.DeleteStock(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
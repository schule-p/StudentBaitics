using Microsoft.AspNetCore.Mvc;
using NpgsqlTypes;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using System.Data.Entity;
using System.Linq.Expressions;



namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("/api/Transaction")]
    public class TransactionsController : Controller
    {
        private readonly AppDbContext _context;
        public TransactionsController(AppDbContext context)

        {
            this._context = context;
        }

        //Генерация уникального Id
        private int NextUniId => _context.Transactions.Count() == 0 ? 1 : _context.Transactions.Max(p => p.Id) + 1;

        [HttpGet("GetTransactions")]
        public IActionResult GetTransactions()
        {
            var x = _context.Transactions.ToList();
            var y = _context.Transactions;

            return Ok(x);
        }



        [HttpGet("{Id}")]
        public IActionResult GetTransactions(int Id)
        {
            var transactions = _context.Transactions.FirstOrDefault(x => x.Id == Id);
            if (transactions == null)
                return NotFound();

            return Ok(transactions);
        }


        [HttpPost]
        public async Task<IActionResult> AddTransactions(Models.Transactions transactionsRequest)
        {
            var transactions = new Models.Transactions()
            {
                //Id = Guid.NewGuid(),
                Id = NextUniId,
                IdStudent = transactionsRequest.IdStudent,
                Sum = transactionsRequest.Sum,
                TypeOfTransaction = transactionsRequest.TypeOfTransaction,
                DateTransartion = transactionsRequest.DateTransartion

            };
            await _context.Transactions.AllAsync(transactions);
            await _context.SaveChangesAsync();
            return Ok(transactions);
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteTransactions(int Id)
        {
            var transactions = await _context.Transactions.FindAsync(Id);
            if (transactions != null)
            {
                _context.Remove(transactions);
                await _context.SaveChangesAsync();
                return Ok(transactions);
            }
            return NotFound();
        }

        
    }
}

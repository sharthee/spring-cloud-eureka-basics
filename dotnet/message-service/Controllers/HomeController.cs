using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillboardClient.Services;
using MessageService.Models;
using MessageService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessageService.Controllers
{
    public class HomeController : Controller
    {
        private readonly QuoteRepository _db;

        public HomeController(QuoteRepository db)
        {
            _db = db;
        }

        [Route("/")]
        public async Task<BillboardQuote> RandomQuote()
        {
            var total = _db.Quotes.Count();
            var rnd = new Random().Next(0, total);
            var randomQuote = await _db.Quotes.Skip(rnd).Take(1).FirstOrDefaultAsync();
            return randomQuote;
        }

        [Route("/quotes")]
        public IEnumerable<BillboardQuote> GetAll()
        {
            return _db.Quotes.AsEnumerable();
        }
        [Route("/quotes/{id}")]
        public async Task<IActionResult> GetQuote(int id)
        {
            var quote = await _db.Quotes.FirstOrDefaultAsync(x => x.Id == id);
            if (quote != null)
                return Json(quote);
            return NotFound();
        }
    }
}

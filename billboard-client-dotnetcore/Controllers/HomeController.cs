using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BillboardClient.Models;
using BillboardClient.Services;
using Microsoft.AspNetCore.Mvc;
using Steeltoe.Common.Discovery;

namespace BillboardClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly QuoteService _quoteService;

        public HomeController(QuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/message")]
        public async Task<string> GetMessage()
        {
            var quote = await _quoteService.GetRandom();
            return $"{quote.Quote} -- {quote.Author}";
        } 
    }
}

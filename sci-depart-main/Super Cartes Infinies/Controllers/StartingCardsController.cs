using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Services;

namespace Super_Cartes_Infinies.Controllers
{
    public class StartingCardsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private StartingCardsService _startingCardsService;

        public StartingCardsController(ApplicationDbContext context, StartingCardsService startingCardsService)
        {
            _context = context;
            _startingCardsService = startingCardsService;
        }

        // GET: StartingCards
        public async Task<IActionResult> Index()
        {
            return View(await _startingCardsService.GetStartingCards());
        }


        private bool StartingCardExists(int id)
        {
            return _context.StartingCards.Any(e => e.Id == id);
        }
    }
}

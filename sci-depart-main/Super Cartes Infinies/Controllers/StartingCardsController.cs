using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;

namespace Super_Cartes_Infinies.Controllers
{
    [Authorize(Roles = ApplicationDbContext.ADMIN_ROLE)]
    public class StartingCardsController : Controller
    {
        private StartingCardsService _startingCardsService;
        private CardsService _cardsService;


        public StartingCardsController(CardsService cardsService, StartingCardsService startingCardsService)
        {
            _startingCardsService = startingCardsService;
            _cardsService = cardsService;
        }

        // GET: StartingCards
        public async Task<IActionResult> Index()
        {
            return View(await _startingCardsService.GetStartingCards());
        }

        // GET: StartingCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staringCard = await _startingCardsService.GetStartingCard(id);
            if (staringCard == null)
            {
                return NotFound();
            }

            return View(staringCard);
        }

        public async Task<IActionResult> AddStartingCard(int? id)
        {
            Card card = await _cardsService.GetCard(id);
            if(card == null)
            {
                return NotFound();
            }
            return View(card);
        }

        [HttpPost]
        public async Task<IActionResult> AddStartingCard(int? id, Card card)
        {
            if(id != card.Id || card == null)
            {
                return NotFound();
            }
            try
            {
                await _startingCardsService.AddStartingCard(card);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View(card);
            }

        }

    // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var startingCard = await _startingCardsService.GetStartingCard(id);
            if (startingCard == null)
            {
                return NotFound();
            }

            StartingCard? deletedCard = await _startingCardsService.DeleteStartingCard(startingCard);
            if (deletedCard == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;

namespace Super_Cartes_Infinies.Controllers
{
    public class StartingCardsController : Controller
    {
        private StartingCardsService _startingCardsService;

        public StartingCardsController(StartingCardsService startingCardsService)
        {
            _startingCardsService = startingCardsService;
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

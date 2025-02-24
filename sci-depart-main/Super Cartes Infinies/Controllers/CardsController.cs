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
    public class CardsController : Controller
    {
        private CardsService _cardsService;

        public CardsController(CardsService cardsService)
        {
            _cardsService = cardsService;
        }

        // GET: Cards
        public async Task<IActionResult> Index()
        {
            return View(await _cardsService.GetAllCards());
        }

        // GET: Cards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                Card card = await _cardsService.GetCard(id);
                return View(card);
            }
            catch (Exception e)
            {
                return NotFound();
            }


        }

        // GET: Cards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Attack,Health,Cost,ImageUrl")] Card card)
        {
            if (ModelState.IsValid)
            {
                await _cardsService.CreateCard(card);
                return RedirectToAction(nameof(Index));
            }
            return View(card);
        }

        // GET: Cards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var card = await _cardsService.GetCard(id);
                return View(card);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        // POST: Cards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Attack,Health,Cost,ImageUrl")] Card card)
        {
            if (id != card.Id)
            {
                return NotFound();
            }
            Card? oldCard = await _cardsService.GetCard(id);

            if (oldCard == null)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                Card? newCard = await _cardsService.EditCard(id, card);

                if (newCard == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(card);
        }

        // GET: Cards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _cardsService.GetCard(id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var card = await _cardsService.GetCard(id);
            if (card == null)
            {
                return NotFound();
            }

            Card? deletedCard = await _cardsService.DeleteCard(card);
            if (deletedCard == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return RedirectToAction(nameof(Index));
        }


    }
}

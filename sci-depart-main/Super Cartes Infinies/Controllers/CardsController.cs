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
			List<Power> list = new List<Power>()
		   {
				new Power
				{
					Id = Power.FIRST_STRIKE_ID,
					Name = "First Strike",
					Description = "Attaque l'adversaire.",
					Icone = "fa-bolt",

				},
				new Power
				{
					Id = Power.THORNS_ID,
					Name = "Thorns",
					Description = "Inflige des dégâts au moment où la carte reçoit des dégâts.",
					Icone = "fa-spikes"
				},
				new Power
				{
					Id = Power.HEAL_ID,
					Name = "Heal",
					Description = "Rend des points de vie à une carte.",
					Icone = "fa-heart"
				},
				new Power
				{
					Id = 4,
					Name = "Shield",
					Description = "Absorbe les dégâts.",
					Icone = "fa-shield"
				}
		   };

			var cards = await _cardsService.GetAllCards();

			var cardPowers = cards.ToDictionary(
				card => card.Id,
				card => list//card.CardPowers.Select(cp => cp.Power).ToList()
			);
			ViewBag.CardPowers = cardPowers;

            return View(cards);
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
                ViewBag.AllPowers = await _cardsService.GetAllPowers();
                ViewBag.SelectedPowers = card.CardPowers.Select(cp => cp.PowerId).ToList();
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
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Attack,Health,Cost,ImageUrl,CardPowers")] Card card, string action, int? newPowerId, int? newPowerValue)
		{
			if (id != card.Id)
				return NotFound();

			Card? oldCard = await _cardsService.GetCard(id);
			if (oldCard == null)
				return NotFound();

			ViewBag.AllPowers = await _cardsService.GetAllPowers();

			if (action == "deletepower")
			{
				if (newPowerId.HasValue)
				{
					var cardPower = oldCard.CardPowers.FirstOrDefault(cp => cp.PowerId == newPowerId.Value);
					if (cardPower != null)
					{
						oldCard.CardPowers.Remove(cardPower); 
					}

					await _cardsService.UpdateCardPowers(id, oldCard.CardPowers); 
				}
				return View(oldCard);
			}


			if (action == "addPower")
			{
				if (newPowerId.HasValue && newPowerValue.HasValue)
				{
					if (!oldCard.CardPowers.Any(cp => cp.PowerId == newPowerId.Value))
					{
						oldCard.CardPowers.Add(new CardPower
						{
							PowerId = newPowerId.Value,
							Value = newPowerValue.Value,
							CardId = id
						});

						await _cardsService.UpdateCardPowers(id, oldCard.CardPowers);
					}
				}

				return View(oldCard); 
			}

			if (action == "save")
			{
				if (ModelState.IsValid)
				{
					Card? updatedCard = await _cardsService.EditCard(id, card);
					if (updatedCard == null)
						return StatusCode(StatusCodes.Status500InternalServerError);

					await _cardsService.UpdateCardPowers(id, card.CardPowers);
					return RedirectToAction(nameof(Index));
				}

				return View(card);
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
            try
            {
                Card? deletedCard = await _cardsService.DeleteCard(card);
                if (deletedCard == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return NotFound();
            }

        }


    }
}

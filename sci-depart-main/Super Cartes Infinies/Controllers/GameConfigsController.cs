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
using WebApi.Services;

namespace Super_Cartes_Infinies.Controllers
{
    [Authorize(Roles = ApplicationDbContext.ADMIN_ROLE)]
    public class GameConfigsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private GameConfigsService _gamesConfigsService;

        public GameConfigsController(GameConfigsService gameConfigsService)
        {
            _gamesConfigsService = gameConfigsService;
        }

        // GET: GameConfigs
        public async Task<IActionResult> Index()
        {
            return View(await _gamesConfigsService.GetGameConfigs());
        }

        // GET: GameConfigs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameConfig = await _gamesConfigsService.GetGameConfig(id);
            if (gameConfig == null)
            {
                return NotFound();
            }

            return View(gameConfig);
        }

        // GET: GameConfigs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameConfigs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NbCardsToDraw,QtyManaPerTurn")] GameConfig gameConfig)
        {
            if (ModelState.IsValid)
            {
                await _gamesConfigsService.CreateGameConfig(gameConfig);
                return RedirectToAction(nameof(Index));
            }
            return View(gameConfig);
        }

        // GET: GameConfigs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameConfig = await _gamesConfigsService.GetGameConfig(id);
            if (gameConfig == null)
            {
                return NotFound();
            }
            return View(gameConfig);
        }

        // POST: GameConfigs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NbCardsToDraw,QtyManaPerTurn")] GameConfig gameConfig)
        {
            if (id != gameConfig.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _gamesConfigsService.EditGameConfig(id, gameConfig);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameConfigExists(gameConfig.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(gameConfig);
        }

        // GET: GameConfigs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameConfig = await _gamesConfigsService.GetGameConfig(id);
            if (gameConfig == null)
            {
                return NotFound();
            }

            return View(gameConfig);
        }

        // POST: GameConfigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameConfig = await _gamesConfigsService.GetGameConfig(id);
            if (gameConfig != null)
            {
                await _gamesConfigsService.DeleteGameConfig(gameConfig);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool GameConfigExists(int id)
        {
            return _context.GameConfigs.Any(e => e.Id == id);
        }
    }
}

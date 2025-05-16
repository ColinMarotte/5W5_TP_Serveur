using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Super_Cartes_Infinies.Services;
using Super_Cartes_Infinies.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatistiquesController : ControllerBase
    {
        private readonly PlayersService _playersService;
        private readonly DecksService _decksService;
        private string playerId;

        public StatistiquesController(PlayersService playersService, DecksService decksService)
        {
            _playersService = playersService;
            _decksService = decksService;
        }

        [Authorize]
        [HttpGet("{playerId}")]
        public IActionResult GetPlayerStatistiques(string playerId)
        {
            Player player = _playersService.GetPlayerFromPlayerId(playerId);

            if (player == null) return NotFound();

            var statistiques = new
            {
                player.TotalWins,
                player.TotalLosses,
                Cards = player.OwnedCards.Select(c => c.Card)
            };

            return Ok(statistiques);
        }

        [Authorize]
        [HttpGet("{playerId}")]
        public IActionResult GetDeckStatistiques(int deckid)
        {
            Deck deck = _decksService.GetDeckFromDeckId(deckid);

            if (deck == null) return NotFound();

            var statistiques = new
            {
                deck.Wins,
                deck.Losses,
                Cards = deck.DeckOwnedCards.Select(c => c.OwnedCard)
            };

            return Ok(statistiques);
        }

    }

}

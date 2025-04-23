using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models.Dtos;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DecksController : ControllerBase
    {
        private DecksService _decksService;
        private PlayersService _playersService;

        public DecksController(DecksService decksService, PlayersService playersService)
        {
            _decksService = decksService;
            _playersService = playersService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateDeck(NewDeckDTO newDeckDTO)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            Player player = _playersService.GetPlayerFromUserId(userId);
            string playerId = player.Id.ToString();

            string name = newDeckDTO.DeckName;
            await _decksService.CreateDeck(name, playerId);
            return Ok(new { Message = "Le deck " + name + " a été créé!"});
        }

        [Authorize]
        [HttpPost("{deckId}")]
        public async Task<ActionResult> AddCardsToDeck(int deckId, List<int> ownedCardsIds)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            Player player = _playersService.GetPlayerFromUserId(userId);

            await _decksService.AddCardsToDeck(deckId, ownedCardsIds, player.Id);
            return Ok(new { Message = "Les cartes ont été ajoutées au deck!" });
        }

        [Authorize]
        [HttpPost("{deckId}")]
        public async Task<ActionResult> RemoveCardFromDeck(int deckId, [FromBody] int deckOwnedCardId)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            Player player = _playersService.GetPlayerFromUserId(userId);

            await _decksService.RemoveCardFromDeck(deckId, deckOwnedCardId, player.Id);
            return Ok(new { Message = "La carte a été retitée du deck!" });
        }

        [Authorize]
        [HttpGet("{deckId}")]
        public ActionResult DeleteDeck(int deckId)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            Player player = _playersService.GetPlayerFromUserId(userId);

            _decksService.DeleteDeck(deckId, player.Id);
            return Ok(new { Message = "Le deck est supprimé!" });
        }

        [Authorize]
        [HttpGet("{deckId}")]
        public ActionResult<List<OwnedCard>> GetCardsNotInDeck(int deckId)
        {
            return Ok(_decksService.GetCardsNotInDeck(deckId));
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<Deck>> GetPlayersDecks()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            Player player = _playersService.GetPlayerFromUserId(userId);
            string playerId = player.Id.ToString();

            return Ok(_decksService.GetPlayersDecks(playerId));
        }

        [Authorize]
        [HttpGet("{deckId}")]
        public async Task<ActionResult> MakeDeckCurrent(int deckId)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            Player player = _playersService.GetPlayerFromUserId(userId);
            string playerId = player.Id.ToString();

            await _decksService.MakeDeckCurrent(deckId, playerId);
            return Ok(new { Message = "Le deck spécifié est maintenant courant!" });
        }
    }
}

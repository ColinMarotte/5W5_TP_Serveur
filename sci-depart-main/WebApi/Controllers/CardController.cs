using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using System.Security.Claims;

namespace Super_Cartes_Infinies.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private CardsService _cardsService;
        private PlayersService _playersService;

        public CardController(CardsService cardsService, PlayersService playersService)
        {
            _cardsService = cardsService;
            _playersService = playersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>> >GetAllCards()
        {
            return Ok(await _cardsService.GetAllCards());
        }

        // TODO: La version réelle devra utiliser [Authorize] pour protéger les données est s'assurer d'avoir accès au User
        // Et l'utiliser pour obtenir l'Id de l'utilisateur
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Card>> GetPlayersCards()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            Player player = _playersService.GetPlayerFromUserId(userId);
            string playerId = player.Id.ToString();
            return Ok(_cardsService.GetPlayersCards(playerId));
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using System.Security.Claims;
using WebApi.Services;

namespace WebApi.Controllers
{
    

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PacksController : ControllerBase
    {
        private PacksService _packsService;
        private PlayersService _playersService;

        public PacksController(PacksService packsService, PlayersService playersService)
        {
            _packsService = packsService;
            _playersService = playersService;
        }


        /// <summary>
        /// Acheter un paquet de cartes
        /// 0 = Basic
        /// 1 = Normal
        /// 2 = Super
        /// </summary>
        /// <param name="paquetIndex">Numéro du paquet</param>
        /// <returns></returns>
        [HttpGet("{paquetIndex}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Card>>> AcheterPaquet(int paquetIndex)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            int playerBalance = _playersService.GetBalanceFromUserId(userId);
                        
            var result = await _packsService.AcheterPaquet(paquetIndex, userId);
            return result;
        }
    }
}

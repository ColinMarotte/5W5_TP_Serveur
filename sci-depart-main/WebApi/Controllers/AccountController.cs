using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models.Models.Dtos;
using Super_Cartes_Infinies.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private PlayersService _playersService;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, PlayersService playersService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _playersService = playersService;
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO registerDTO)
        {

            if (registerDTO.Password != registerDTO.PasswordConfirm)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "Le mot de passe et la confirmation ne sont pas identiques" });
            }

            IdentityUser user = new IdentityUser()
            {
                UserName = registerDTO.Email,
                Email = registerDTO.Email
            };
            IdentityResult identityResult = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!identityResult.Succeeded)
            {
                if (identityResult.Errors.First().Code == "DuplicateUserName")
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "Ce nom d'utilisateur est déjà utilisé." });
                }
                if (identityResult.Errors.First().Code == "PasswordTooShort")
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "Le mot de passe doit être d'au moins 6 caractères de long." });
                }
                if (identityResult.Errors.First().Code == "PasswordRequiresLower")
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "Le mot de passe doit contenir au moins une lettre minuscule." });
                }
                if (identityResult.Errors.First().Code == "PasswordRequiresUpper")
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "Le mot de passe doit contenir au moins une lettre majuscule." });
                }
                if (identityResult.Errors.First().Code == "PasswordRequiresDigit")
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "Le mot de passe doit contenir au moins un chiffre." });
                }
                if (identityResult.Errors.First().Code == "PasswordRequiresNonAlphanumeric")
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "Le mot de passe doit contenir au moins un caractère spécial." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Error = identityResult.Errors });
                }
            }

            await _playersService.CreatePlayer(user);

            return Ok(new { Message = "L'utilisateur a été créé avec succès!" });
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO loginDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, true, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                IdentityUser user = await _userManager.FindByEmailAsync(loginDTO.Email);

                Claim? nameIdentifierClaim = User.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                // Note: On ajoute simplement le NameIdentifier dans les claims. Il n'y aura pas de rôles pour les utilisateurs simples du WebAPI.
                List<Claim> authClaims = new List<Claim>();
                authClaims.Add(nameIdentifierClaim);

                SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("C'est tellement la meilleure cle qui a jamais ete cree dans l'histoire de l'humanite (doit etre longue)"));

                string issuer = this.Request.Scheme + "://" + this.Request.Host;

                DateTime expirationTime = DateTime.Now.AddMinutes(30);

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: null,
                    claims: authClaims,
                    expires: expirationTime,
                    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
                );

                string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                string playerId = _playersService.GetPlayerFromUserId(user.Id).Id.ToString();

                return Ok(new LoginSuccessDTO() { Token = tokenString, UserId = user.Id, PlayerId = playerId, Solde = _playersService.GetBalanceFromPlayerId(playerId) });
            }

            return NotFound(new { Error = "L'utilisateur est introuvable ou le mot de passe ne concorde pas." });
        }

        [Authorize]
        [HttpGet]
        public ActionResult<string[]> PrivateData()
        {
            return new string[] { "figue", "banane", "noix" };
        }
    }
}

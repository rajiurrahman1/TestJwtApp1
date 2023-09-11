using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TestJwtApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        //[HttpGet("Public")]
        [HttpGet]
        [Route("PublicEndpoint")]
        public IActionResult Public()
        {

            return Ok("Hello World! Inside public endpoint.");
        }

        [HttpGet("Admin")]
        [Authorize(Roles ="Admin")]
        public IActionResult AdminsEndpoint()
        {
            var userClaims = HttpContext.User.Identity as ClaimsIdentity;
            var currentUser = AuthenticationHelper.GetCurrentUser(userClaims);

            return Ok($"Hi! {currentUser.GivenName}, you are a {currentUser.Role}");
        }

        [HttpGet("Seller")]
        [Authorize(Roles = "Seller")]
        public IActionResult SellerssEndpoint()
        {
            var userClaims = HttpContext.User.Identity as ClaimsIdentity;
            var currentUser = AuthenticationHelper.GetCurrentUser(userClaims);

            return Ok($"Hi! {currentUser.GivenName}, you are a {currentUser.Role}");
        }


    }
}

using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServerApi.ActionFilters;
using System.Threading.Tasks;

namespace ServerApi.Controllers
{
	[Route("api/authentication")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly ILoggerManager _logger;
		private readonly UserManager<User> _userManager;

		public AuthenticationController(ILoggerManager logger, UserManager<User> userManager)
		{
			_logger = logger;
			_userManager = userManager;
		}

		[HttpPost]
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDTO userForRegistration)
		{
			var user = new User
			{
				FirstName = userForRegistration.FirstName,
				LastName = userForRegistration.LastName,
				UserName = userForRegistration.UserName,
				Email = userForRegistration.Email,
				PhoneNumber = userForRegistration.PhoneNumber
			};

			var result = await _userManager.CreateAsync(user, userForRegistration.Password);
			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.TryAddModelError(error.Code, error.Description);
				}
				return BadRequest(ModelState);
			}

			await _userManager.AddToRolesAsync(user, userForRegistration.Roles);

			return StatusCode(201);
		}

	}
}

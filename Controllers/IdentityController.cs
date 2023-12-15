using IdentityUserCustom.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace IdentityUserCustom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityController
    {
        private readonly VerifyMeService _verifyMeService;

        public IdentityController(VerifyMeService verifyMeService)
        {
            _verifyMeService = verifyMeService;
        }


        [HttpGet("verify/{reference}")]
        public async Task<IActionResult> Verify(string reference)
        {
            bool isVerified = await _verifyMeService.VerifyIdentity(reference);

            if (isVerified)
            {
                return new OkResult();
            }
            else
            {
                return new BadRequestResult();
            }
        }
    }
}

using Messaging;
using MFAAuthApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Mockings;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace MFAAuthApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MsIdentityController : ControllerBase
    {
        private readonly ILogger<MsIdentityController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ISmsMessagingService _smsMessagingService;
        private static MockDb _mockDb = new MockDb();

        public MsIdentityController(ILogger<MsIdentityController> logger, IConfiguration configuration, ISmsMessagingService smsMessagingService)
        {
            _logger = logger;
            _configuration = configuration;
            _smsMessagingService = smsMessagingService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> MsIdentityRedirectUri(string state = "123")
        {
            var uri = $"https://login.microsoftonline.com/common/oauth2/v2.0/authorize?" +
            $"client_id={_configuration["AzureAd:ClientId"]}" +
            $"&scope=openid%20profile" +
            $"&response_type=code%20id_token" +
            $"&redirect_uri={_configuration["AzureSignInCallbackUri"]}" +
            $"&response_mode=fragment" +
            $"&nonce={Guid.NewGuid()}";

            if(!String.IsNullOrWhiteSpace(state))
            uri += $"&state={state}";

            return Redirect(uri);
        }

        [AllowAnonymous]
        [HttpGet("SignInCallback")]
        public async Task<IActionResult> SignInCallback(string? code, string? id_token, string? state, string? error, string? error_description)
        {
            if (!String.IsNullOrWhiteSpace(error))
                return Conflict($"{error}\n{error_description}");

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.ReadToken(id_token);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            var claimsEmail = jwtSecurityToken.Claims.First(claim => claim.Type == "preferred_username").Value;

            if(_mockDb.Users.Any(x => x.Email == claimsEmail))
            {
                var user = _mockDb.Users.FirstOrDefault(x => x.Email == claimsEmail);
                if (user.MFAEnabled)
                {
                    var result = await _smsMessagingService.SendVerificationSmsAsync(user.PhoneNumber);
                    user.VerificationMessageStatus = result.Status;
                    user.VerificationSid = result.Sid;
                }

                _mockDb.Users.Clear();
                _mockDb.Users.Add(user);
            }

            return Content(JsonConvert.SerializeObject(_mockDb.Users));
        }

        //This webhook is no longer needed as found out a new logic for identification. Uncomment if you want.
        //[AllowAnonymous]
        //[HttpGet("SmsVerificationWebhook")]
        //public async Task<IActionResult> SmsVerificationWebhook(SmsVerificationWebhook webhook)
        //{
        //    if(_mockDb.Users.Any(x => x.VerificationSid == webhook.VerifySid))
        //    {
        //        var user = _mockDb.Users.FirstOrDefault(x => x.VerificationSid == webhook.VerifySid);
        //        if (user != null && webhook.Status == "factor.verified")
        //        {
        //            user.MFAVerified = true;

        //            _mockDb.Users.Clear();
        //            _mockDb.Users.Add(user);
        //        }
        //    }

        //    return Content("Handled");
        //}

        [AllowAnonymous]
        [HttpPost("SmsCodeVerify")]
        public async Task<IActionResult> SmsCodeVerify(string to, string code)
        {
            var result = await _smsMessagingService.VerifySmsTokenAsync(to, code);

            if (_mockDb.Users.Any(x => x.VerificationSid == result.Sid))
            {
                var user = _mockDb.Users.FirstOrDefault(x => x.VerificationSid == result.Sid);
                if (user != null)
                {
                    user.MFAVerified = true;
                    user.VerificationMessageStatus = result.Status;

                    _mockDb.Users.Clear();
                    _mockDb.Users.Add(user);
                }
            }

            return Content(JsonConvert.SerializeObject(_mockDb.Users));
        }
    }
}
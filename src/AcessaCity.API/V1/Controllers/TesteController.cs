using System.Collections.Generic;
using System.Threading.Tasks;
using AcessaCity.API.Controllers;
using AcessaCity.Business.Interfaces;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AcessaCity.API.Extensions.CustomAuthorize;

namespace AcessaCity.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/teste")]
    public class TesteController: MainController
    {
        public TesteController(INotifier notifier) : base(notifier) { }

        [HttpPost("{uid}")]
        public async Task<ActionResult> Login(string uid)
        {
            string customToken = await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(uid);
            return Ok(customToken);
        }

        [HttpGet]
        [Authorize]
        [ClaimsAuthorize("admin", "true")]
        public async Task<ActionResult> Get()
        {
            // var pagedEnumerable = FirebaseAuth.DefaultInstance.ListUsersAsync(null);
            // var responses = pagedEnumerable.AsRawResponses().GetEnumerator();

            // List<ExportedUserRecord> users = new List<ExportedUserRecord>();

            // while (await responses.MoveNext())
            // {
            //     ExportedUserRecords response = responses.Current;
            //     foreach (ExportedUserRecord user in response.Users)
            //     {
            //         users.Add(user);
            //     }
            // }


            // var claims = new Dictionary<string, object>()
            // {
            //     { "admin", true },
            // };
            // await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync("QMPFglbJ0xgx1u3GZIZA8ZeQUJD3", claims);            



            return Ok(new {
                data = this.CurrentUser().DisplayName
            });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Marketo.Models;
using Newtonsoft.Json;
using System.Web;
using System.Collections.Specialized;


namespace Marketo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tokenController : ControllerBase
    {
        // POST: api/marketo
        [HttpPost] 
        public async Task<ActionResult<ResponseOfIdentity>>  PostIdentity(IdentityQuery identityQuery)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage IdentityResponse = await httpClient.GetAsync(String.Format(identityQuery.api.baseurl + identityQuery.api.path + "?client_id={0}&client_secret={1}&client_secret=&grant_type={2}", identityQuery.identity.client_id, identityQuery.identity.client_secret, identityQuery.identity.grant_type ));
            var IdentityBody = await IdentityResponse.Content.ReadAsStringAsync();
            ResponseOfIdentity responseOfIdentity = JsonConvert.DeserializeObject<ResponseOfIdentity>(IdentityBody);
            return responseOfIdentity;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Marketo.Models;
using Newtonsoft.Json;
using System.Text;

namespace Marketo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class identityController : ControllerBase
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
    [Route("api/[controller]")]
    [ApiController]
    public class leadController : ControllerBase
    {
        [HttpPost] 
        public async Task<ActionResult<ResponseOfLead>>  PostLead(LeadQuery leadQuery)
        {
            
            identityController identityController = new identityController();
            Task<ActionResult<ResponseOfIdentity>> responseOfIdentity = identityController.PostIdentity(leadQuery.identityQuery);
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",  responseOfIdentity.Result.Value.access_token );
            StringContent leadContent = new StringContent(JsonConvert.SerializeObject(leadQuery.syncLeadRequest), Encoding.UTF8, "application/json");
            HttpResponseMessage leadResponse = await httpClient.PostAsync(leadQuery.api.baseurl + leadQuery.api.path, leadContent);
            var LeadBody = await leadResponse.Content.ReadAsStringAsync();
            ResponseOfLead responseOfLead = JsonConvert.DeserializeObject<ResponseOfLead>(LeadBody);
            return responseOfLead;
        }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class leadIdsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ResponseOfLead>>  PostLead(LeadIdsQuery leadIdsQuery)
        {
            identityController identityController = new identityController();
            Task<ActionResult<ResponseOfIdentity>> responseOfIdentity = identityController.PostIdentity(leadIdsQuery.identityQuery);
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",  responseOfIdentity.Result.Value.access_token );
            HttpResponseMessage leadIdsResponse = await httpClient.GetAsync(String.Format(leadIdsQuery.api.baseurl + leadIdsQuery.api.path , leadIdsQuery.filterType,  string.Join(",",leadIdsQuery.filterValues ) ));
            var leadIdsBody = await leadIdsResponse.Content.ReadAsStringAsync();
            ResponseOfLead responseOfLead = JsonConvert.DeserializeObject<ResponseOfLead>(leadIdsBody);
            return responseOfLead;
        } 
    }
}

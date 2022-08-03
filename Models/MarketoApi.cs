namespace Marketo.Models
{
    public class Api
    {
        public string? url { get; set; }
        public string? rout  { get; set; }
    }
    public class Identity
    {
        public string? client_id  { get; set; }
        public string? client_secret { get; set; }
        public string? grant_type { get; set; }
    }
    public class IdentityQuery
    {
        public Api api { get; set; }
        public Identity identity { get; set; }
    }
    public class ResponseOfIdentity 
    {
        public string? access_token { get; set; }
        public string? scope { get; set; }
        public int expires_in { get; set; } 
        public string? token_type { get; set; }
    }
}
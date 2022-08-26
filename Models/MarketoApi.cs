namespace Marketo.Models
{
    public class Api
    {
        public string? baseurl { get; set; }
        public string? path  { get; set; }
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
    public class SyncLeadRequest 
    {
        public string action { get; set; }
        public string lookupField { get; set; }
        public LeadFileds[] input { get; set; }
    }
    public class LeadFileds
    {
        public string firstName { get; set; }
        public string? middleName { get; set; }
        public string lastName { get; set; }
        public string? dateOfBirth { get; set; }
        public string? gender { get; set; }
        public string? salutation { get; set; }
        public string email { get; set; }
        public string? mobilePhone { get; set; }
        public string? phone { get; set; }
        public string? fax { get; set; }
        public string? country { get; set; }
        public string? postalCode { get; set; }
        public string? city { get; set; }
        public string? address { get; set; }
        public string? company { get; set; }
        public string? department { get; set; }
        public string? title { get; set; }
        public string? industry { get; set; }
        public string? website { get; set; }
        public string? numberOfEmployees { get; set; }
    }
    public class LeadQuery
    {
        public Api api { get; set; }
        public SyncLeadRequest syncLeadRequest { get; set; }
        public IdentityQuery identityQuery { get; set; }
    }
    public class ResponseOfIdentity 
    {
        public string? access_token { get; set; }
        public string? scope { get; set; }
        public int expires_in { get; set; } 
        public string? token_type { get; set; }
    }
    public class ResponseOfLead {
        public Error[] errors { get; set; }
        public bool? moreResult { get; set; }
        public string? nextPageToken { get; set; }
        public string requestId { get; set; }
        public Lead[] result { get; set; }
        public bool? success { get; set; }
        public Warning[] warnings { get; set; }
    } 
    public class Error {
        public string code { get; set; }
        public string message { get; set; }
    } 
    public class Lead {
        public int? id { get; set; }
        public ProgramMembership? membership  { get; set; }
        public Reason? reason { get; set; }
        public string? status { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? updatedAt { get; set; }
         public string? createdAt { get; set; }
        }
    public class Warning {
        public int code { get; set; }
        public string message { get; set; }
    }
    public class ProgramMembership {
        public bool? acquiredBy { get; set; }
        public bool? isExhausted { get; set; }
        public string stringmembershipDate { get; set; }
        public string? nurtureCadence { get; set; }
        public string progressionStatus { get; set; }
        public bool? reachedSuccess { get; set; }
        public string? stream { get; set; }
    }
    public class Reason {
        public string code { get; set; }
        public string message { get; set; }
    }
    public class LeadIdsQuery 
    {
        public Api api { get; set; }
        public IdentityQuery identityQuery { get; set; }
        public string filterType { get; set; }
        public string[] filterValues { get; set; }
    }
}
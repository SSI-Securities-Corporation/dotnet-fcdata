using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Serilog;
using SSI.FCData.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SSI.FCData
{
    public class AuthenProvider
    {
        string _url;
        string _id;
        string _secret;
        private readonly ILogger _logger;
        private string _accessToken;
        private long _tokenTime = 0;
        public AuthenProvider(string apiUrl, string consumerId, string consumerSecret, ILogger logger = null)
        {
            _logger = logger;
            _url = apiUrl;
            _id = consumerId;
            _secret = consumerSecret;
            
        }
        
        public async Task<string> GetAccessToken()
        {
            if (!CheckTokenLifeTime())
            {
                try
                {
                    _accessToken = await TakeAccessToken();
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(_accessToken);
                    var tokenS = jsonToken as JwtSecurityToken;
                    var exp = tokenS.Claims.First(claim => claim.Type == "exp").Value;
                    _tokenTime = long.Parse(exp);
                    return _accessToken;
                }
                catch (Exception ex)
                {
                    _logger?.Error(ex, "Failed to get access token");
                    throw;
                }
            }
            return _accessToken;

        }
        private async Task<string> TakeAccessToken()
        {
            using (var client = new HttpClient())
            {
                var accessTokenRequest = new AccessTokenRequest()
                {
                    ConsumerID = _id,
                    ConsumerSecret = _secret
                };
                
                var postJsonItem = new StringContent(JsonConvert.SerializeObject(accessTokenRequest), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(_url + ApiDefine.AccessToken, postJsonItem);

                response.EnsureSuccessStatusCode();
                var data = JsonConvert.DeserializeObject<SingleResponse<AccessTokenResponse>>(await response.Content.ReadAsStringAsync());
                if (data.status == (int)HttpStatusCode.OK)
                {

                    return data.data.accessToken;
                }
                else
                    throw new HttpRequestException(data.message);
            }
        }
        private bool CheckTokenLifeTime()
        {
            try
            {
                var datetimeNow = (long)DateTime.Now.ToUniversalTime().Subtract(
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                ).TotalMilliseconds;
                var timeSpanNumber = _tokenTime - datetimeNow;
                if (timeSpanNumber <= 0) return false;

                return timeSpanNumber > 600; // Revoke access token before it expired in 10 minute
            }
            catch (Exception ex)
            {
                _logger?.Error(ex, ex.Message);
                return false; // token exp invalid
            }
        }
    }
}

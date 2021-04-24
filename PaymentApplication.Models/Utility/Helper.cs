using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace PaymentApplication.Models
{
    public class Helper
    {
        #region Claims
        public static string GetUserName(ClaimsPrincipal claims) => claims.FindFirst(x => x.Type == ClaimTypes.Name)?.Value;
        public static string GetPKID(ClaimsPrincipal claims) => claims.FindFirst(x => x.Type == "UId")?.Value ?? "0";
        public static string GetEmailId(ClaimsPrincipal claims) => claims.FindFirst(x => x.Type == ClaimTypes.Email)?.Value;
        public static string GetCurrentRole(ClaimsPrincipal claims) => claims.FindFirst(x => x.Type == ClaimTypes.Role)?.Value;
        #endregion

        #region SecurityConfig
        
        public static string SymmetricSecurityKey(IConfiguration configuration) => configuration["SecurityConfig:symmetricSecurityKey"] ?? "";
        //public static List<string> GetjwtSecurityIssuers(IConfiguration configuration)
        //{
        //    return configuration.GetSection("SecurityConfig:jwtSecurityIssuers").Get<List<string>>();
        //}
        #endregion
    }
}

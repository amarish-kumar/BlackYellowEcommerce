using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace BlackYellow.Infra.CrossCuting.Security.Services
{
    public class UserAutenticationService
    {
        public ClaimsPrincipal AddToClaim(string nome, string profile, string userId)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, nome, ClaimValueTypes.String));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, userId, ClaimValueTypes.String));
            claims.Add(new Claim(ClaimTypes.Role, profile, ClaimValueTypes.String));
            var userIdentity = new ClaimsIdentity();
            userIdentity.AddClaims(claims);
            userIdentity.Label = userId;
            var userPrincipal = new ClaimsPrincipal(userIdentity);
            return userPrincipal;
        }
    }
}

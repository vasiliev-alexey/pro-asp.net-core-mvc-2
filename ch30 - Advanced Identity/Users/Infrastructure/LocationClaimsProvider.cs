﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Users.Infrastructure
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authentication;

    public class LocationClaimsProvider : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal != null && !principal.HasClaim(c => c.Type == ClaimTypes.PostalCode))
            {
                ClaimsIdentity identity = principal.Identity as ClaimsIdentity;
                if (identity != null && identity.IsAuthenticated && identity.Name != null)
                {
                    if (identity.Name.ToLower() == "alice")
                    {
                        identity.AddClaims(
                            new Claim[]
                                {
                                    CreateClaim(ClaimTypes.PostalCode, "DC 20500"),
                                    CreateClaim(ClaimTypes.StateOrProvince, "DC")
                                });
                    }
                    else
                    {
                        identity.AddClaims(
                            new Claim[]
                                {
                                    CreateClaim(ClaimTypes.PostalCode, "NY 10036"),
                                    CreateClaim(ClaimTypes.StateOrProvince, "NY")
                                });
                    }
                }
            }

            return Task.FromResult(principal);
        }

        private static Claim CreateClaim(string type, string value) =>
            new Claim(type, value, ClaimValueTypes.String, "RemoteClaims");
    }
}
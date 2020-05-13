﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;

namespace TweetBookAPI.Extensions
{
    public static class GeneralExtensions
    {
        public static string GetUserId(this HttpContext httpContext)
        {
            if (httpContext.User == null)
                return string.Empty;

            return httpContext.User.Claims.Single(x => x.Type == "id").Value;
        }
    }
}
﻿using CloudMusicDotNet.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Api.Infrastructure
{
    public class HttpClientCookieDelegatingHandler : DelegatingHandler
    {
        private readonly HttpContext _httpContext;
        private readonly ICryptoService _cryptoService;

        public HttpClientCookieDelegatingHandler(
            IHttpContextAccessor httpContextAccesor,
            ICryptoService cryptoService)
        {
            _httpContext = httpContextAccesor.HttpContext;
            _cryptoService = cryptoService;

        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // 设置请求cookie
            var reqCookies = _httpContext.Request.Headers["Cookie"].ToString();
            if (string.IsNullOrEmpty(reqCookies))
                reqCookies = "os=pc";
            else
                reqCookies += ";os=pc";
            
            var cookies = new List<string> { "os=pc" };

            request.Headers.Add("Cookie", reqCookies);
            request.Headers.Add("Referer", "https://music.163.com");

            // 发送请求
            var response = await base.SendAsync(request, cancellationToken);

            // 设置响应cookie
            if (response.Headers.TryGetValues("Set-Cookie", out var resCookies))
            {
                _httpContext.Response.Headers["Set-Cookie"] = new StringValues(resCookies.Select(c => Regex.Replace(c, @"\s*Domain=[^(;|$)]+;*", "")).ToArray());
            }

            return response;
        }
    }
}

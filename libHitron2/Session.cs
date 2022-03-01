using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;

namespace libHitron2
{
    public static class Session
    {
        internal static HttpClientHandler handler = new HttpClientHandler { UseCookies = true };

        internal static System.Net.Http.Headers.ProductInfoHeaderValue userAgent =
            new ProductInfoHeaderValue("libHitron2", "1.0");
        internal static string getPHPSessionID()
        {
            var cookies = Session.handler.CookieContainer.List();
            if (cookies.Count > 0)
            {
                return cookies[0].ToString();
            }
            return "";
        }

        private static HttpClient _client;
        internal static string host;

        internal static void addCookie(string cookie)
        {
            _client.DefaultRequestHeaders.Add("Cookie", cookie);
        }
        internal static HttpClient client
        {
            get
            {
                if (string.IsNullOrEmpty(host))
                {
                    throw new Exception("Host is not set");
                }
                if (_client == null)
                {
                    _client = new HttpClient{ BaseAddress = new Uri("http://" + Session.host + "/") };
                    _client.DefaultRequestHeaders.Clear(); 
                    _client.DefaultRequestHeaders.UserAgent.Add(userAgent);
                    _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    _client.Timeout = TimeSpan.FromSeconds(3);
                    _client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
                    _client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                    _client.DefaultRequestHeaders.Add("Connection", "keep-alive");
                    _client.DefaultRequestHeaders.Add("Referer", "http://192.168.0.1/webpages/index.html");
                    _client.DefaultRequestHeaders.Add("Sec-GPC", "1");
                }
                return _client;
            }
        }
        
        internal static List<Cookie> List(this CookieContainer container)
        {
            var cookies = new List<Cookie>();

            var table = (Hashtable)container.GetType().InvokeMember("m_domainTable",
                BindingFlags.NonPublic |
                BindingFlags.GetField |
                BindingFlags.Instance,
                null,
                container,
                new object[] { });

            foreach (var key in table.Keys)
            {
                var domain = key as string;

                if (domain == null)
                    continue;

                if (domain.StartsWith("."))
                    domain = domain.Substring(1);

                var httpAddress = string.Format("http://{0}/", domain);
                var httpsAddress = string.Format("https://{0}/", domain);

                if (Uri.TryCreate(httpAddress, UriKind.RelativeOrAbsolute, out var httpUri))
                {
                    foreach (Cookie cookie in container.GetCookies(httpUri))
                    {
                        cookies.Add(cookie);
                    }
                }
                if (Uri.TryCreate(httpsAddress, UriKind.RelativeOrAbsolute, out var httpsUri))
                {
                    foreach (Cookie cookie in container.GetCookies(httpsUri))
                    {
                        cookies.Add(cookie);
                    }
                }
            }

            return cookies;
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebserviceCharging.code.lib
{
    public class HttpRequest
    {
        public Uri URL { get; protected set; }

        public HttpMethod HttpMethod { get; protected set; }

        public Dictionary<String, String> Headers { get; protected set; }

        public HttpContent content;

        public HttpRequest(HttpMethod method, string url)
        {
            Uri locurl;

            if (Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out locurl))
            {
                if (
                    !(locurl.IsAbsoluteUri &&
                      (locurl.Scheme == "http" || locurl.Scheme == "https")) ||
                    !locurl.IsAbsoluteUri)
                {
                    throw new ArgumentException("The url passed to the HttpMethod constructor is not a valid HTTP/S URL");
                }
            }
            else
            {
                throw new ArgumentException("The url passed to the HttpMethod constructor is not a valid HTTP/S URL");
            }

            URL = locurl;
            HttpMethod = method;
            Headers = new Dictionary<string, string>();

        }

        public HttpRequest header(string name, string value)
        {
            Headers.Add(name, value);
            return this;
        }

        

        public HttpRequest connectCard(string format, string typeCard,
            string numberCard, string seriCard, string merchanId, string sign)
        {
             IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("format", format),
                new KeyValuePair<string, string>("merchant_id", merchanId),
                new KeyValuePair<string, string>("type_card", typeCard),
                new KeyValuePair<string, string>("number_card", numberCard),
                new KeyValuePair<string, string>("seri_card", seriCard),
                new KeyValuePair<string, string>("sign", sign)
            };
            content = new FormUrlEncodedContent(queries);

            return this;
        }

        public HttpRequest connectTopup(string format, string typeCard,
            string postpaid, string amount, string phone, string merchanId, string sign)
        {
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("format", format),
                new KeyValuePair<string, string>("merchant_id", merchanId),
                new KeyValuePair<string, string>("type_card", typeCard),
                new KeyValuePair<string, string>("phone", phone),
                new KeyValuePair<string, string>("postpaid", postpaid),
                new KeyValuePair<string, string>("amount", amount),
                new KeyValuePair<string, string>("sign", sign)
            };
            content = new FormUrlEncodedContent(queries);

            return this;
        }

        public HttpRequest connectByCard(string format, string typeCard,
            string total, string amount, string merchanId, string sign)
        {
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("format", format),
                new KeyValuePair<string, string>("merchant_id", merchanId),
                new KeyValuePair<string, string>("type_card", typeCard),
                new KeyValuePair<string, string>("amount", amount),
                new KeyValuePair<string, string>("total", total),
                new KeyValuePair<string, string>("sign", sign)
            };
            content = new FormUrlEncodedContent(queries);

            return this;
        }


        public HttpResponse<String> asString()
        {
            return HttpClientHelper.Request<String>(this);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EduxchangeApp.Services
{
    class HttpClientProvider
    {
        private readonly HttpClient _client;

        public static HttpClientProvider instance;

        private HttpClientProvider()
        {
            _client = new HttpClient();
        }

        private static HttpClientProvider GetInstance()
        {
            if (instance is null) instance = new HttpClientProvider();
            return instance;
        }

        public static HttpClient GetHttpClient()
        {
            return GetInstance()._client;
        }

    }
}

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using BookLibrary.Web.Clients.Interfaces;

namespace BookLibrary.Web.Clients
{
    public class WebApiClient : IClient
    {
        private readonly HttpClient client;

        public WebApiClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(UrlProvider.WebApiHost);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public T Get<T>(string url) where T : class
        {
            var result = default(T);
            var response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<T>().Result;
            }
            return result;
        }

        public bool Create<T>(string url, T dto) where T : class
        {
            var response = client.PostAsJsonAsync(url, dto).Result;

            return response.IsSuccessStatusCode;
        }

        public bool Update<T>(string url, T dto) where T : class
        {
            var response = client.PutAsJsonAsync(url, dto).Result;

            return response.IsSuccessStatusCode;
        }

        public bool Delete(string url)
        {
            var response = client.DeleteAsync(url).Result;

            return response.IsSuccessStatusCode;
        }
    }
}
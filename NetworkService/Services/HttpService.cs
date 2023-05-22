

using System.Net.Http;
using System.Text;

namespace NetworkService.Services
{
    public class HttpService
    {
        static HttpClient _httpClient;

        static HttpClient httpClient
        {
            get
            {
                if (_httpClient == null)
                    _httpClient = new HttpClient();

                return _httpClient;
            }
        }

        public async static Task<string> Get(string url)
        {
            using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            using var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead);
            using var memoryStream = new MemoryStream(await httpResponseMessage.Content.ReadAsByteArrayAsync());

            return await httpResponseMessage.Content.ReadAsStringAsync();
        }

        public async static Task<string> Post<TValue>(string url, TValue content)
        {
            using var stream = new MemoryStream();
            stream.Position = 0;
            HttpContent httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

            using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url) { Content = httpContent };
            using var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead);
            using var memoryStream = new MemoryStream(await httpResponseMessage.Content.ReadAsByteArrayAsync());

            return await httpResponseMessage.Content.ReadAsStringAsync();
        }

        public async static Task<string> Delete(string url)
        {
            using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, url);
            using var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead);
            using var memoryStream = new MemoryStream(await httpResponseMessage.Content.ReadAsByteArrayAsync());

            return await httpResponseMessage.Content.ReadAsStringAsync();
        }

        public async static Task<string> Put<TValue> (string url, TValue content)
        {
            using var stream = new MemoryStream();
            stream.Position = 0;
            HttpContent httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

            using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url) { Content = httpContent };
            using var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead);
            using var memoryStream = new MemoryStream(await httpResponseMessage.Content.ReadAsByteArrayAsync());

            return await httpResponseMessage.Content.ReadAsStringAsync();
        }

    }
}

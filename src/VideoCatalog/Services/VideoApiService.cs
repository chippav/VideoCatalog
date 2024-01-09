using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace VideoCatalog.Services
{
    public class VideoApiService : IVideoApiService
    {
        private static readonly Lazy<IVideoApiService> instance = new Lazy<IVideoApiService>(() => new VideoApiService());

        private VideoApiService()
        {
        }

        public static IVideoApiService Instance => instance.Value;

        public async Task<string> GetJsonVideoResponseAsync(string apiUrl)
        {
            if (!Uri.TryCreate(apiUrl, UriKind.Absolute, out Uri reqUri))
            {
                throw new Exception("The url provided is invalid.");
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(reqUri);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }

            catch
            {
                throw;
            }
        }


        public async Task<bool> IsNetWorkConnected(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    return response.IsSuccessStatusCode;
                }
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }
    }
}

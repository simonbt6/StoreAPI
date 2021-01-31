using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace AdminPanel.Data.Server.Status.HTTP
{
    public class ProductHTTP
    {
        private static string BaseURL = "http://api.boreal-store.com/";

        public async static Task<HttpStatusCode> getAll()
        {
            HttpResponseMessage response = null;
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(BaseURL+"products"),
                };

                using(response = await client.SendAsync(request))
                {
                    Console.WriteLine("Status code: " + response.StatusCode.ToString());
                    return response.StatusCode;
                }
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine(e);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return HttpStatusCode.BadRequest;
        }
    }
}

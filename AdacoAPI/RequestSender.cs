using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static AdacoAPI.DataStructs;

namespace AdacoAPI
{
    static class RequestSender
    {
        public static async Task<string> SendRequest(RequestData request)
        {
            using (var client = new HttpClient())
            {
                foreach (string keys in request.Headers.Keys)
                {
                    client.DefaultRequestHeaders.Add(keys, request.Headers[keys]);
                }
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                switch (request.Method)
                {
                    case "GET":
                        return await client.GetStringAsync(request.Uri);
                    case "POST":
                        {
                            var response = await client.PostAsync(request.Uri, request.Media);
                            return await response.Content.ReadAsStringAsync();
                        }
                    case "PUT":
                        {
                            var response = await client.PutAsync(request.Uri, request.Media);
                            return await response.Content.ReadAsStringAsync();
                        }
                    case "DELETE":
                        {
                            var response = await client.DeleteAsync(request.Uri);
                            return await response.Content.ReadAsStringAsync();
                        }
                    default:
                        return "Invalid method";
                } 
            }
        }
    }
}
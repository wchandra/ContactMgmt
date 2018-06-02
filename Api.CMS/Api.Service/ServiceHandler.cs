using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Api.Service
{
    public class ServiceHandler : IServiceHandler
    {
        public async Task<HttpResponseMessage> Get(string uri, string id)
        {
            var client = new HttpClient();
            var msg = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await client.GetAsync(uri,  HttpCompletionOption.ResponseContentRead);
            if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK) return response;
            
            return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
        }

        public async Task<HttpResponseMessage> Post(string uri, string data)
        {
            var client = new HttpClient();
            var msg = new HttpRequestMessage(HttpMethod.Post, uri);
            var content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");
            var  response =  await client.PostAsync("http://localhost:57562/api/Contact/CreateContact", content);
            if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK) return response;

            return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
        }

        public async Task<HttpResponseMessage> Put(string uri, string data)
        {
            var client = new HttpClient();
            var msg = new HttpRequestMessage(HttpMethod.Put, uri);
            StringContent content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");
            msg.Content = content;
            var response = await client.PutAsync("http://localhost:57562/api/Contact/UpdateContact", content);
            if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK) return response;

            return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
        }

        public async Task<HttpResponseMessage> Delete(string uri, string id)
        {
            var client = new HttpClient();
            var response =  await client.DeleteAsync("http://localhost:57562/api/Contact/DeleteContact/" + id);
            if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK) return response;

            return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
        }
    }
}

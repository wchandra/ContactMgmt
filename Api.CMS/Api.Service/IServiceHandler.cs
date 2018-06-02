using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Api.Service
{
    public interface IServiceHandler
    {
       Task<HttpResponseMessage> Post(string uri, string data);

        Task<HttpResponseMessage> Get(string uri, string id);

        Task<HttpResponseMessage> Put(string uri, string data);
        
        Task<HttpResponseMessage> Delete(string uri, string data);

    }
}

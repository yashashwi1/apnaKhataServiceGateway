using GatewayInteractionContracts.Requests;
using GatewayInteractionContracts.Responses;
using Newtonsoft.Json;
using System.Net;
using System.Security.Cryptography.Xml;

namespace ApnaKhataServiveGateway.Services
{
    public class ServiceLocator
    {
        private IConfiguration configurations;

        public ServiceLocator( IConfiguration configuration)
        {
            this.configurations = configuration;           
        }
       
        public async Task<Response> LocateServiceEndpoint(Request request)
        {
            var type = Type.GetType(request.requestType);

            Response response = null;
            switch (request.requestType)
            {
               
                case "GatewayInteractionContracts.Requests.GetUserRequest":
                    {
                        var getUserRequest = JsonConvert.DeserializeObject<GetUserRequest>(request.payLoad);
                        var baseUrl = this.configurations["serviceSource:internalUrl"];
                        var endPoint = string.Format("api/User?userId={0}&userName={1}", getUserRequest.userId, getUserRequest.userName);
                        var client = new HttpClient();
                        var result = await client.GetAsync(baseUrl + endPoint);
                        if (result.IsSuccessStatusCode)
                        {
                            response = new Response();
                            response.responseType = (typeof(GetUserResponse)).ToString();
                            response.payload = result.Content.ReadAsStringAsync().Result;
                        }

                        break;
                    }
            }
            return response;
        }

       

      
    }
}

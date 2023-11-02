using System.Net.Http;

namespace HRLeaveManagement.MVC.Services.Base
{
    public partial class Client : IClient
    {
        private HttpClient _httpClient;
        public HttpClient HttpClient 
        {
            get
            {
                return  _httpClient;
            }
        }
    }
}

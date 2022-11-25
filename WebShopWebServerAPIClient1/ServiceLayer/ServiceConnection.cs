namespace WebShopWebServerAPIClient.ServiceLayer
{
    public class ServiceConnection
    {
        readonly string baseURL = "https://localhost:7177/";
        public string UseUrl;
        public ServiceConnection()
        {
            HttpEnabler = new HttpClient();
            string UseUrl = "https://localhost:7177/";
        }

        public HttpClient HttpEnabler { private get; init; }


        public async Task<HttpResponseMessage?> CallServiceGet()
        {
            //Open http

            //Check http response and status
            HttpResponseMessage? hrm = null;
            if (UseUrl != null)
            {
                HttpEnabler.BaseAddress = new Uri(baseURL);
                hrm = await HttpEnabler.GetAsync(UseUrl);
            }
            return hrm;

        }
    }
}

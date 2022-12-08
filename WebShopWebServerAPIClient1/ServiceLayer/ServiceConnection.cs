namespace WebShop.ServiceLayer
{
    public class ServiceConnection : IServiceConnection
    {
        readonly string baseURL = "https://localhost:7177/";
        public string UseUrl  { get; set; }
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

        public async Task<int> CallServicePost(StringContent postJson)
        {
            HttpResponseMessage? hrm = null;
            var content = "get";
            int returnId = -1;
            
            if (UseUrl != null)
            {

                HttpEnabler.BaseAddress = new Uri(baseURL);
                hrm = await HttpEnabler.PostAsync(UseUrl, postJson);
               content = await hrm.Content.ReadAsStringAsync();
                returnId = int.Parse(content);

            }
            return returnId;
        }
    }
}

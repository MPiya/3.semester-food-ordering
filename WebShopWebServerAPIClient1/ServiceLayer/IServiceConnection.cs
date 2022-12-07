namespace WebShopWebServerAPIClient.ServiceLayer
{
    public interface IServiceConnection
    {

        
        public string? UseUrl { get; set; }

         Task<HttpResponseMessage?> CallServiceGet();
         Task<int> CallServicePost(StringContent postJson);
        //  Task<HttpResponseMessage?> CallServiceDelete();

    }
}

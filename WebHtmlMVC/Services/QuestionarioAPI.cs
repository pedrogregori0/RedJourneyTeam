namespace WebHtmlMVC.Services
{
    public class QuestionarioAPI
    
        {
            private readonly HttpClient _httpClient;
            public QuestionarioAPI(IHttpClientFactory factory)
            {
                _httpClient = factory.CreateClient("API");
            }
        }
    
}

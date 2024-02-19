namespace Iranpl.Domain.Abstraction
{
    public interface IHttpService
    {
        public HttpClient CreateHttpClient(string url, string mediaType = "application/json");
        public StringContent CreateStringContent(string json, string mediaType = "application/json");
        public bool CreateBoolContent(string json, string mediaType = "application/json");
    }
}

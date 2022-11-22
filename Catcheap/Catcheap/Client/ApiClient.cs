using System.Net.Http.Headers;

namespace Catcheap.Client;
public static class ApiClient
{
    public static HttpClient client = new HttpClient();

    public static void Init()
    {
        client.BaseAddress = new Uri("http://10.0.2.2:7172/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }
    
}

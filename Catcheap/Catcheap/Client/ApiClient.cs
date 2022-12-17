using System.Net.Http.Headers;
using System.Web;

namespace Catcheap.Client;
public static class ApiClient
{
    public static HttpClient client = new();

    public static void Init()
    {
        client.BaseAddress = new Uri("http://10.0.2.2:7102/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }
    
}
 
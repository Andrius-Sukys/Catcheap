using Catcheap.Client.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Catcheap.Client.HttpServices;

public class HttpService<T>
{
    static HttpClient httpClient;
    protected static readonly string BaseAddress = "http://10.0.2.2:7102";
    protected static readonly string Url = $"{BaseAddress}/api/";

    public HttpService()
    {
        httpClient = new HttpClient();
    }

    protected static HttpClient GetClient()
    {
        if (httpClient != null)
            return httpClient;

        httpClient = new HttpClient();

        return httpClient;
    }

    public static async Task<IEnumerable<T>> GetAll(string urlExtension)
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return new List<T>();

        HttpClient client = GetClient();

        string result = await client.GetStringAsync($"{Url}{urlExtension}");

        return JsonConvert.DeserializeObject<IEnumerable<T>>(result);
    }

    public static async Task<T> Get(string urlExtension)
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return default;

        HttpClient client = GetClient();

        string result = await client.GetStringAsync($"{Url}{urlExtension}");

        return JsonConvert.DeserializeObject<T>(result);
    }

    public static async Task<T> Add(T item, string urlExtension)
    {
        var msg = new HttpRequestMessage(HttpMethod.Post, $"{Url}{urlExtension}")
        {
            Content = JsonContent.Create(item)
        };

        HttpClient client = GetClient();

        var response = await client.SendAsync(msg);
        response.EnsureSuccessStatusCode();

        var itemJson = await response.Content.ReadAsStringAsync();
        var insertedItem = JsonConvert.DeserializeObject<T>(itemJson);

        return insertedItem;
    }

    public static async Task Update(T item, string urlExtension)
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return;

        HttpRequestMessage msg = new(HttpMethod.Put, $"{Url}{urlExtension}")
        {
            Content = JsonContent.Create<T>(item)
        };

        HttpClient client = GetClient();

        var response = await client.SendAsync(msg);
        response.EnsureSuccessStatusCode();
    }

    public static async Task Delete(int id, string urlExtension)
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return;

        HttpRequestMessage msg = new(HttpMethod.Delete, $"{Url}{urlExtension}/{id}");

        HttpClient client = GetClient();

        var response = await client.SendAsync(msg);
        response.EnsureSuccessStatusCode();
    }


}

using Catcheap.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcheap.Client.HttpServices;

public class HttpServiceForNordpoolPrice : HttpService<NordpoolPrice>
{
    public static async Task<IEnumerable<NordpoolPrice>> GetByDateTime(DateTime date, string urlExtension)
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return new List<NordpoolPrice>();

        HttpClient client = GetClient();

        string result = await client.GetStringAsync($"{Url}{urlExtension}/{date}");

        return JsonConvert.DeserializeObject<IEnumerable<NordpoolPrice>>(result);
    }

    public static async Task<double> GetCheapestSince(DateTime date, string urlExtension)
    {
        HttpClient client = GetClient();

        string result = await client.GetStringAsync($"{Url}{urlExtension}/{date}");

        return JsonConvert.DeserializeObject<double>(result);
    }

    public static async Task<double> GetMostExpensiveSince(DateTime date, string urlExtension)
    {
        HttpClient client = GetClient();

        string result = await client.GetStringAsync($"{Url}{urlExtension}/{date}");

        return JsonConvert.DeserializeObject<double>(result);
    }

    public static async Task<double> GetAverageSince(DateTime date, string urlExtension)
    {
        HttpClient client = GetClient();

        string result = await client.GetStringAsync($"{Url}{urlExtension}/{date}");

        return JsonConvert.DeserializeObject<double>(result);
    }
}

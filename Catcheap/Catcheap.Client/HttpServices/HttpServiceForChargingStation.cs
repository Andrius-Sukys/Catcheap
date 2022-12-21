using Catcheap.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcheap.Client.HttpServices;

public class HttpServiceForChargingStation : HttpService<ChargingStation>
{
    public static async Task<IEnumerable<ChargingStation>> GetByCity(string city, string urlExtension)
    {
        HttpClient client = GetClient();

        string result = await client.GetStringAsync($"{Url}{urlExtension}/{city}");

        return JsonConvert.DeserializeObject<IEnumerable<ChargingStation>>(result);
    }
}

using System.Globalization;
using System.Text.Json.Nodes;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            
            if (args.Length < 1)
            {
                Console.WriteLine("1 args");
                return;
            }
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync(
                    "https://api.jcdecaux.com/vls/v3/stations?contract=" + args[0] + "&apiKey=bf0e747a512a5c135285653ef36aaabcbe67ad8b");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                JsonNode json = JsonValue.Parse(responseBody);
                JsonArray jsonArray = json.AsArray();
                for (int i = 0; i < jsonArray.Count; i++)
                {
                    Console.WriteLine(jsonArray[i]["name"]);
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }

}
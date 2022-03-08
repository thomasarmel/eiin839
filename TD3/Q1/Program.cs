using System.Globalization;
using System.Text.Json.Nodes;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync(
                    "https://api.jcdecaux.com/vls/v3/contracts?apiKey=bf0e747a512a5c135285653ef36aaabcbe67ad8b");
                string responseBody = await response.Content.ReadAsStringAsync();
                JsonNode json = JsonValue.Parse(responseBody);
                JsonArray jsonArray = json.AsArray();
                foreach (var jsonNode in jsonArray)
                {
                    Console.WriteLine(jsonNode["name"]);
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
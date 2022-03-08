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
                if (args.Length < 1)
                {
                    Console.WriteLine("1 args");
                    return;
                }
                HttpResponseMessage response = await client.GetAsync(
                    $"https://api.jcdecaux.com/vls/v3/stations/{args[0]}?contract={args[1]}&apiKey=bf0e747a512a5c135285653ef36aaabcbe67ad8b");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                JsonNode json = JsonValue.Parse(responseBody);
                Console.WriteLine(json);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }

}
// https://api.jcdecaux.com/vls/v3/stations/{station_number}?contract={contract_name}
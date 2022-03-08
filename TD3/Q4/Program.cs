using System.Device.Location;
using System.Globalization;
using System.Text.Json.Nodes;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            
            if (args.Length < 3)
            {
                Console.WriteLine("3 args");
                return;
            }
            GeoCoordinate cliGPS = new GeoCoordinate(Double.Parse(args[1]), Double.Parse(args[2]));
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync(
                    "https://api.jcdecaux.com/vls/v3/stations?contract=" + args[0] + "&apiKey=bf0e747a512a5c135285653ef36aaabcbe67ad8b");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                JsonNode json = JsonValue.Parse(responseBody);
                JsonArray jsonArray = json.AsArray();
                double minDistance = 100000000;
                string closerStation = "";
                for (int i = 0; i < jsonArray.Count; i++)
                {
                    GeoCoordinate currentGPS = new GeoCoordinate(jsonArray[i]["position"]["latitude"].GetValue<Double>(),
                        jsonArray[i]["position"]["longitude"].GetValue<Double>());
                    double d = currentGPS.GetDistanceTo(cliGPS);
                    if (d < minDistance)
                    {
                        minDistance = d;
                        closerStation = jsonArray[i]["name"].GetValue<string>();
                    }
                }
                Console.WriteLine("Closer Station: " + closerStation);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }

}
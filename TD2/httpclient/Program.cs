namespace HTTPClient
{
    internal class Program
    {
        static readonly HttpClient client = new HttpClient();
        
        private static void Main(string[] args)
        {
            HTTP().GetAwaiter().GetResult();
        }
        
        static async Task HTTP()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try	
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:8080/incr?param1=6");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");	
                Console.WriteLine("Message :{0} ",e.Message);
            }
        }
    }
}
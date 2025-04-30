using ConsoleEntity.Models;
using Newtonsoft.Json;

internal class Program
{
    static async Task Main(string[] args)
    {
        int count = 0;

        Console.WriteLine("Start programu");

        do
        {


            ApiResponse? apiResponse = new();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("http://api.open-notify.org/iss-now.json");
                    response.EnsureSuccessStatusCode(); // Zajistí, že HTTP odpověď bude 200-299  
                    string responseBody = await response.Content.ReadAsStringAsync();
                    apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseBody);
                    //Console.WriteLine(responseBody);

                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Chyba při získávání dat: {e.Message}");
                }
            }

            if (apiResponse?.Message == "success")
            {
                using (var context = new MyDbContext())
                {
                    var issDbPossition = new IssDbPosition() { ID = 0, Iss_Position = apiResponse.Iss_Position, Message = apiResponse.Message, Timestamp = apiResponse.Timestamp };

                    context.Add(issDbPossition);
                    context.SaveChanges();


                    Console.WriteLine("Success!!");
                }
            }
        } while (count++ < 10);
    }









}
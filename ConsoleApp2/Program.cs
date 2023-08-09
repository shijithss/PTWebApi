
// TODO Enter your Dataverse environment's URL and logon info.
using Microsoft.Extensions.Configuration;


class Program
{
    public static async Task Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
                   .AddJsonFile($"appsettings.json", true, true);

        var config = builder.Build();
        var apiurl = config["APIURL"];
        Console.WriteLine(" Enter a) GetAllPosts");
        string input = Console.ReadLine();

        switch (input)
        {
            case "a": // no input
                await ShowDataAsync(apiurl + "GetAllPosts");
                break;

           

            default:
                Console.WriteLine("You did not type a valid option");
                Console.WriteLine();
                Console.ReadLine();
                break;
        }
    }

    public static async Task ShowDataAsync(string apiurl)
    {


        using (var client = new HttpClient())
        {
            string url = string.Format(apiurl);
            var response = client.GetAsync(url).Result;

            string responseAsString = await response.Content.ReadAsStringAsync();
            Console.Write(responseAsString);
        }
    ;

    }
}




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
        Console.WriteLine(" Enter a) CreateAllusers  b) GetAllUsers c) GetUsersByCardType d) GetUsersByPostCount");
        string input = Console.ReadLine();

        switch (input)
        {
            case "a": // no input
                 await ShowDataAsync(apiurl + "CreateAllUsers");
                break;

            case "b": // no input
                await ShowDataAsync(apiurl + "GetAllUsers");
                break;

            case "c": // input data
                Console.WriteLine(" Enter CardType");
                string inputcardType = Console.ReadLine();
                await ShowDataAsync(apiurl + "GetUsersByCardType?cardType=" + inputcardType);
                break;

            case "d": // input data
                Console.WriteLine(" Enter postCount");
                string inputPostCount = Console.ReadLine();
                await ShowDataAsync(apiurl + "GetUsersByPostCount?postCount=" + inputPostCount);
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



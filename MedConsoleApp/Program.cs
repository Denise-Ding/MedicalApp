
using Shared.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;


// Initialise HttpClient
using HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://localhost:7047/");

byte[] byteArray = Encoding.ASCII.GetBytes("admin:778899");   // replace with secured password stored else where
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

while (true)
{
    Console.WriteLine("Server & Port should be https://localhost:7047/");
    Console.WriteLine("Work in progress. Only Doctor is validated.\n\r");
    Console.Write("Please enter Provider Number (or 'q' to quit): ");
    string providerNumber = Console.ReadLine();

    if (providerNumber?.ToLower() == "q")
    {
        Console.WriteLine("Exiting...");
        break;
    }

    HttpResponseMessage response = await client.GetAsync($"api/provider/{providerNumber}");
    if (response.IsSuccessStatusCode)
    {
        string json = await response.Content.ReadAsStringAsync();
        try
        {
            Provider provider = JsonSerializer.Deserialize<Provider>(json);
            if (provider == null)
            {
                Console.WriteLine("Provider not found.");
                continue;
            }

            Console.WriteLine($"We found you: {json} \n");
            //Console.WriteLine($"These are your patients (sorry function not available)");

            // show list of patients allow by this provider

            Console.WriteLine("If this is not you, please contact your hospital administrator.");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Unable to locate Provider.");
        }
    }
    else
    {
        Console.WriteLine("Provider not found or error occurred.");
    }

    Console.WriteLine();
}




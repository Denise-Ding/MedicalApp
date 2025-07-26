
using Shared.Models;
using System.Text.Json;


// Initialise HttpClient
using HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://localhost:7047/");


while (true)
{
    Console.Write("Enter Provider Number (or 'q' to quit): ");
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

            Console.WriteLine($"Provider details: {json}");
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




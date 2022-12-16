using System.Text.Json;
using System.Net.Http.Json;
using System.Text;
namespace PetConsole.App
{
    class Program
    {
        static async Task Main()
        {

            // get all the pets from the database
            Console.WriteLine("PetConsole starting...");
            HttpClient client = new HttpClient();
            string url = "https://localhost:7188/api/Pet";

            string response = await client.GetStringAsync(url);

            IEnumerable<PetDTO> Pets = JsonSerializer.Deserialize<IEnumerable<PetDTO>>(response);

            foreach (PetDTO pet in Pets)
            {
                Console.WriteLine($"{pet.name}, {pet.species}, {pet.coloring}, {pet.age}");
            }


            //Post a new pet and read the response

            PetDTO claude = new PetDTO("Merry", "Cat", "White", 6);
            var content = new StringContent(JsonSerializer.Serialize(claude), Encoding.UTF8, "application/json");
            
            var postResp = await client.PostAsync(url, content);

            Pets = JsonSerializer.Deserialize<IEnumerable<PetDTO>>(await postResp.Content.ReadAsStringAsync());

            foreach (PetDTO pet in Pets)
            {
                Console.WriteLine($"{pet.name}, {pet.species}, {pet.coloring}, {pet.age}");
            }

            Console.WriteLine("PetConsole ending...");
        }
    }
}
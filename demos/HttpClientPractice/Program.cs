using System.Text.Json;

namespace HttpClientPractice;

class Program
{
    static async Task Main(string[] args)
    {
        //HttpClient
        HttpClient client = new HttpClient();
        
        //Using statements.
        //"Using" tells the compiler to create the variable in the () to the right of the word "using"; and discard (dereference) it
        //once the code in the following block of code {...} finishes executing. 
        using (HttpResponseMessage resp = await client.GetAsync("https://api.chucknorris.io/jokes/random"))
        {
            string responseBody = await resp.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);

            Joke returnedJoke = JsonSerializer.Deserialize<Joke>(responseBody)!;
            Console.WriteLine(returnedJoke.ToString());
        }


        

        


        
    }
}

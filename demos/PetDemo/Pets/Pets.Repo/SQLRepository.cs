using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Abstractions;
using Pets.Models;

namespace Pets.Repo
{
    public class SQLRepository : IRepository
    {
        //Fields
        private readonly string connectionString;
        private readonly ILogger<SQLRepository> logger;

        //Constructors
        public SQLRepository(string _connectionString, ILogger<SQLRepository> _logger)
        {
            this.connectionString = _connectionString;
            this.logger = _logger;
        }

        //Methods

        public async Task<IEnumerable<Pet>> AddPet(Pet newPet)
        {
            List<Pet> list = new List<Pet>();

            using SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            string cmdText = "INSERT INTO Pets (name, species, color, age)" +
                             "VALUES (@name, @species, @coloring, @age);" +
                             "SELECT (id, name, species, color, age) FROM Pets;";
            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@name", newPet.Name);
            cmd.Parameters.AddWithValue("@species", newPet.Species);
            cmd.Parameters.AddWithValue("@coloring", newPet.Coloring);
            cmd.Parameters.AddWithValue("@age", newPet.Age);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string species = reader.GetString(2);
                string color = reader.GetString(3);
                int age = reader.GetInt32(4);

                Pet tmp = new Pet(name, species, color, age);
                list.Add(tmp);
            }

            await connection.CloseAsync();
            logger.LogInformation("Executed AddPet");

            return list;
        }
    }
}
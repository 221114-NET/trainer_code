using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ModelsLayer;

namespace RepoLayer
{

    /**
Server=tcp:11142022-batch-server.database.windows.net,1433;Initial Catalog=111422-batch-db;Persist Security Info=False;User ID=mark.moore@revature.com@11142022-batch-server;Password=youneedap1e!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;    */

    public interface IRepositoryClass
    {
        Task<List<Customer>> GetCustomerListAsync();
        Task<Customer> PostCustomerAsync(Customer c);
        PokemonClass PostPokemon(PokemonClass p);
        PokemonSpecific PostPokemonSpecific(PokemonSpecific ps);
    }

    public class RepositoryClass : IRepositoryClass
    {

        //Giving it a Logger
        private readonly IMyLogger _logger;

        public RepositoryClass(IMyLogger logger)
        {
            _logger = logger;
        }

        public async Task<List<Customer>> GetCustomerListAsync()
        {
            // user ADO.NET to push the data to the DB.
            SqlConnection conn = new SqlConnection("Server=tcp:11142022-batch-server.database.windows.net,1433;" +
                "Initial Catalog=111422-batch-db;Persist Security Info=False;" +
                "User ID=mark.moore@revature.com@11142022-batch-server;Password=youneedap1e!;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            //configure the SQL query along with the connection object
            SqlCommand command = new SqlCommand($"SELECT * FROM Customers", conn);
            //Open the Connection - you can access the SqlConnection object directly or through the SqlCommand obj!
            command.Connection.Open();
            Task<SqlDataReader> ret = command.ExecuteReaderAsync();

            List<Customer> list = new List<Customer>();

            SqlDataReader ret1 = await ret;
            while (await ret1.ReadAsync())
            {
                Customer c = Mapper.DbToCustomer(ret1);
                list.Add(c);
            }
            return list;
        }

        public async Task<Customer> PostCustomerAsync(Customer c)
        {
            // user ADO.NET to push the data to the DB.
            SqlConnection conn = new SqlConnection("Server=tcp:11142022-batch-server.database.windows.net,1433;" +
                "Initial Catalog=111422-batch-db;Persist Security Info=False;" +
                "User ID=mark.moore@revature.com@11142022-batch-server;Password=youneedap1e!;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            //configure the SQL query along with the connection object
            SqlCommand command = new SqlCommand($"INSERT INTO Customers (FirstName, LastName, LastOrderDate, Remarks) VALUES (@FirstName,@LastName,@LastOrderDate,@Remarks);", conn);
            //Open the Connection - you can access the SqlConnection object directly or through the SqlCommand obj!
            command.Connection.OpenAsync();
            // conn.Open();

            // add the parameters to the query - do this to prevent Sql Injection
            command.Parameters.AddWithValue("@FirstName", c.FirstName);
            command.Parameters.AddWithValue("@LastName", c.LastName);
            command.Parameters.AddWithValue("@LastOrderDate", c.LastOrderDate);
            command.Parameters.AddWithValue("@Remarks", c.Remarks);
            int rowsAffected = await command.ExecuteNonQueryAsync();

            // verify that the query succeeded.
            if (rowsAffected == 1)
            {
                // query for that new customer to return to the client the customerId
                // call the private get a customer method to get a customer.
                conn.Close();
                return c;
            }
            else
            {
                return null;
            }
        }

        public PokemonClass PostPokemon(PokemonClass p)
        {
            p.Dexterity = 100;
            if (File.Exists("PokemonList.json"))
            {
                string oldPlist = File.ReadAllText("PokemonList.json");

                // do the file saving
                List<PokemonClass> plist = JsonSerializer.Deserialize<List<PokemonClass>>(oldPlist)!;// the ! is to permanently denot tht I know it may be a null value

                plist.Add(p);

                string pliststr = JsonSerializer.Serialize(plist);

                File.WriteAllText("PokemonList.json", pliststr);

                _logger.LogStuff(p);

                return p;
            }
            else
            {
                List<PokemonClass> plist = new List<PokemonClass>();
                plist.Add(p);

                string pliststr = JsonSerializer.Serialize(plist);

                File.WriteAllText("PokemonList.json", pliststr);
                _logger.LogStuff(p);
                return p;
            }

        }

        public PokemonSpecific PostPokemonSpecific(PokemonSpecific ps)
        {
            ps.Name = ps.Name + "-gatherer";
            return ps;
        }

    }
}
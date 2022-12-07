using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ModelsLayer;

namespace RepoLayer
{
    internal static class Mapper
    {
        internal static Customer DbToCustomer(SqlDataReader sdr)
        {
            // map the values to the POCO.
            Customer c = new Customer();

            try
            {

                // create a for loop to check is each individual elelment is null o rnot. 
                // if null, take appropriate action for the datatype
                // is non-null, map the data.
                if (sdr[3] == DBNull.Value) c.LastOrderDate = DateTime.Now;//sdr.GetDateTime(3);
                else c.LastOrderDate = sdr.GetDateTime(3);

                c.CustomerId = sdr.GetInt32(0);
                c.FirstName = sdr.GetString(1);
                c.LastName = sdr.GetString(2);
                c.Remarks = sdr.GetString(4);
                throw new YourOwnPersonalException();// manually throw an exception....
            }
            catch (YourOwnPersonalException ex)
            {
                Console.WriteLine(ex.message);
            }
            return c;
        }
    }
}
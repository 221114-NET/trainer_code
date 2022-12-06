using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class Customer
    {
        public Customer()
        {
        }

        public Customer(int customerId, string firstName, string lastName, DateTime lastOrderDate, string remarks)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            LastOrderDate = lastOrderDate;
            Remarks = remarks;
        }

        public int CustomerId { get; set; }

        [JsonPropertyName("firstname")]
        [StringLength(10, ErrorMessage = "That First name is too long or too short", MinimumLength = 3)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastOrderDate { get; set; }
        public string Remarks { get; set; } = "default remarks";
    }
}
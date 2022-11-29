using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json; //Json serialization/deserialization
using System.Threading.Tasks; //Used for async/await
using System.Text.Json.Serialization; //Used for Json attribute tags

namespace HttpClientPractice
{
    //This is my model. 
    public class Joke
    {
        //The fields in my model must match the fields in the JSON.
        public List<string> categories {get; set;} 
        
        //If you wish to (or are forced to) use names that differ from the model fields, use an attribute tag.
        //https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/customize-properties?pivots=dotnet-7-0
        [JsonPropertyName("created_at")]
        public string created {get; set;} //this field doesn't match the JSON return field, but I accounted for that using the attribute.
        public string icon_url {get; set;}
        public string id {get; set;}
        public string updated_at {get; set;}
        public string url {get; set;}
        public string value {get; set;}


        public override string ToString()
        {
            return $"{value}";
        }
    }
}
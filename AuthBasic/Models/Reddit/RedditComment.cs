namespace AuthBasic.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class RedditComment
    {
        [JsonProperty("body")]
        public string body { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("parentID")]
        public string parentID { get; set; } 

        public string postID { get; set; } 

        public string author { get; set; } 

        public string createdString { get; set; } 

        public Int64 unixTimestamp { get; set; } 

        public int score { get; set; } 

        public int id { get; set; } 

        public bool parity { get; set; } 

    }
}

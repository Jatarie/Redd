namespace AuthBasic.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class RedditPost
    {
        [JsonProperty("title")]
        [Required]
        public string title { get; set; }

        [Required]
        [JsonProperty("subreddit")]
        public string subreddit { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [Required]
        [JsonProperty("id")]
        public string id { get; set; }

        [Required]
        [JsonProperty("author")]
        public string author { get; set; }

        [Required]
        [JsonProperty("num_comments")]
        public int num_comments { get; set; }

        [Required]
        [JsonProperty("score")]
        public string score { get; set; }

        [Required]
        [JsonProperty("created_utc")]
        public double created_utc { get; set; }

        public string created_string { get; set; }

        public string body { get; set; }
    }
}
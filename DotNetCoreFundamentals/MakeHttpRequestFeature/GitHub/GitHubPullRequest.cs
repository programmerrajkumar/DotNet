using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MakeHttpRequestFeature.GitHub
{
    public class GitHubPullRequest
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}

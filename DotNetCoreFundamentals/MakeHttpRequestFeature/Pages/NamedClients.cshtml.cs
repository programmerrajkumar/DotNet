using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MakeHttpRequestFeature.GitHub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MakeHttpRequestFeature.Pages
{
    public class NamedClientsModel : PageModel
    {
        private readonly IHttpClientFactory clientFactory;

        public IEnumerable<GitHubPullRequest> PullRequests { get; private set; }

        public bool IsPullRequestSuccess { get; private set; }

        public bool HasPullRequests => PullRequests.Any();

        public NamedClientsModel(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task OnGet()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "repos/dotnet/AspNetCore.Docs/pulls");
            var client = clientFactory.CreateClient("github");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var result = await response.Content.ReadAsStreamAsync();
                PullRequests = await JsonSerializer.DeserializeAsync<IEnumerable<GitHubPullRequest>>(result);
                IsPullRequestSuccess = true;
            }
        }
    }
}

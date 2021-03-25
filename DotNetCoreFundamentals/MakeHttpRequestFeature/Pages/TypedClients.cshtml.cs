using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MakeHttpRequestFeature.GitHub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MakeHttpRequestFeature.Pages
{
    public class TypedClientsModel : PageModel
    {
        #region GitHub Issue
        private readonly GitHubService gitHubService;

        public IEnumerable<GitHubIssue> LatestIssues { get; private set; }

        public bool HasIssue => LatestIssues.Any();

        public bool GetIssuesError { get; private set; }

        #endregion

        #region Repos
        private readonly RepoService repoService;

        public IEnumerable<string> Repos { get; private set; }

        public bool HasRepo => LatestIssues.Any();

        public bool GetReposError { get; private set; }
        #endregion

        public TypedClientsModel(GitHubService gitHubService, RepoService repoService)
        {
            this.gitHubService = gitHubService;
            this.repoService = repoService;
        }

        public async Task OnGet()
        {
            try
            {
                LatestIssues = await gitHubService.GetAspDotNetDocsIssueAsync();
            }
            catch (HttpRequestException)
            {
                GetIssuesError = true;
                LatestIssues = Array.Empty<GitHubIssue>();
            }

            try
            {
                Repos = await repoService.GetReposAsync();
            }
            catch (HttpRequestException)
            {
                GetReposError = true;
                Repos = Array.Empty<string>();
            }
        }
    }
}

namespace WebApplication1.Services
{
    public class GithubProfile
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public string AvatarUrl { get; set; }
    }

    public class GithubService : IDisposable
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.github.com";

        public GithubService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "GithubService");
        }

        public async Task<GithubProfile> GetUserProfile(string username)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/users/{username}");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<GithubProfile>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Github API error: {ex.Message}");
            }
        }
        public void Dispose()
        {
            _httpClient?.Dispose();
        }

    }
}
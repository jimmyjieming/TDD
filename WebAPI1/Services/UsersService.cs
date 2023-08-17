using Microsoft.Extensions.Options;
using System;
using System.Net;
using WebAPI1.Config;
using WebAPI1.Models;

public class UsersService : IUsersService
{
    private readonly HttpClient _httpClient;
    private readonly IOptionsMonitor<UsersApiOptions> _apiConfig;
    public UsersService(HttpClient httpClient,
        IOptionsMonitor<UsersApiOptions> apiConfig)
    {
        _httpClient = httpClient;
        _apiConfig = apiConfig;
    }

    public async Task<List<User>> GetAllUsers()
    {
        var usersResponse = await _httpClient
            .GetAsync(_apiConfig.CurrentValue.Endpoint);
        
        if (usersResponse.StatusCode == HttpStatusCode.NotFound)
        {
            return new();
        }
        
        var responseContent = usersResponse.Content;
        var allUsers = await responseContent.ReadFromJsonAsync<List<User>>();
        
        return allUsers?.ToList() ?? new();
    }
}

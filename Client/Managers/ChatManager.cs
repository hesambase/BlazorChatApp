using BlazorChatApp.Server.Models;
using BlazorChatApp.Shared;
using System.Net.Http.Json;

namespace BlazorChatApp.Client.Managers
{
    public class ChatManager : IChatManager
    {
        private readonly HttpClient _httpClient;

        public ChatManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ChatMessage>> GetConversationAsync(string contactId)
        {
            return await _httpClient.GetFromJsonAsync<List<ChatMessage>>($"api/chat/{contactId}");
        }
        public async Task<ApplicationUser> GetUserDetailsAsync(string userId)
        {
            return await _httpClient.GetFromJsonAsync<ApplicationUser>($"api/chat/users/{userId}");
        }
        public async Task<List<ApplicationUser>> GetUsersAsync()
        {
            var data = await _httpClient.GetFromJsonAsync<List<ApplicationUser>>("api/chat/users");
            return data;
        }
        public async Task SaveMessageAsync(ChatMessage message)
        {
            await _httpClient.PostAsJsonAsync("api/chat", message);
        }
    }
    
}

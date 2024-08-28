using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FOV.UI.Pages
{
    public class ChatPageTestModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ChatPageTestModel(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public string ChatGroupName { get; set; }
        public List<Message> Messages { get; set; } = new();

        public class Message
        {
            public Guid Id { get; set; }
            public Guid ChatGroupId { get; set; }
            public string UserName { get; set; }
            public string Content { get; set; }
            public DateTime Timestamp { get; set; }
        }

        public async Task OnGetAsync(Guid chatGroupId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_configuration["ApiBaseUrl"]}/api/messages/{chatGroupId}");

            if (response.IsSuccessStatusCode)
            {
                var messages = await response.Content.ReadFromJsonAsync<List<Message>>();
                if (messages != null)
                {
                    Messages = messages;
                }
            }

            // Set ChatGroupName based on your logic
            ChatGroupName = "Group Name";  // Replace with actual chat group name retrieval
        }

        public async Task<IActionResult> OnPostSendMessageAsync(Guid chatGroupId, string userName, string content)
        {
            var client = _httpClientFactory.CreateClient();
            var message = new CreateMessageDto
            {
                ChatGroupId = chatGroupId,
                UserName = userName,
                Content = content
            };

            var response = await client.PostAsJsonAsync($"{_configuration["ApiBaseUrl"]}/api/messages", message);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage(new { chatGroupId });
            }

            return Page();
        }
        public class CreateMessageDto
        {
            public Guid ChatGroupId { get; set; }
            public string UserName { get; set; }
            public string Content { get; set; }
        }
    }
}

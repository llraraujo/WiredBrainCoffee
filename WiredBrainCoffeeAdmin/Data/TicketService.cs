using WiredBrainCoffeeAdmin.Data.Models;

namespace WiredBrainCoffeeAdmin.Data
{
    public class TicketService : ITicketService
    {
        private readonly HttpClient _client;

        public TicketService(HttpClient client)
        {
                _client = client;
        }

        public async Task<string> Create(HelpTicket ticket)
        {
            var response = await _client.PostAsJsonAsync("/api/ticket", ticket);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<List<HelpTicket>> GetAll()
        {
            return await _client.GetFromJsonAsync<List<HelpTicket>>("/api/tickets");
        }
    }
}

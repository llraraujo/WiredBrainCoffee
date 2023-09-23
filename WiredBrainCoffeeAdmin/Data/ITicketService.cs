using WiredBrainCoffeeAdmin.Data.Models;

namespace WiredBrainCoffeeAdmin.Data
{
    public interface ITicketService
    {
        Task<List<HelpTicket>> GetAll();
        Task<string> Create(HelpTicket ticket);

    }
}

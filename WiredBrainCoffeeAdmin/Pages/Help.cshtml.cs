using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.Design;
using WiredBrainCoffeeAdmin.Data;
using WiredBrainCoffeeAdmin.Data.Models;

namespace WiredBrainCoffeeAdmin.Pages
{
    public class HelpModel : PageModel
    {
        private readonly ITicketService _ticketService;

        [BindProperty]
        public HelpTicket NewTicket { get; set; }

        public List<HelpTicket> HelpTickets { get; set; }

        public string ResponseMessage { get; set; }

        public HelpModel(ITicketService ticketService)
        {
            _ticketService = ticketService;        
        }

        public async Task<IActionResult> OnGet()
        {

            HelpTickets = await _ticketService.GetAll();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {

            ResponseMessage = await _ticketService.Create(NewTicket);
            HelpTickets = await _ticketService.GetAll();
            return Page();
        }
    }
}

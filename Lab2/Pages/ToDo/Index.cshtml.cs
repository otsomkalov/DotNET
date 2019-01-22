using System.Collections.Generic;
using System.Threading.Tasks;
using Lab2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2.Pages.ToDo
{
    public class IndexModel : PageModel
    {
        private readonly IToDoService _toDoService;

        public IndexModel(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public IList<Models.ToDo> ToDo { get; set; }

        public async Task OnGetAsync()
        {
            ToDo = await _toDoService.ListAsync();
        }
    }
}
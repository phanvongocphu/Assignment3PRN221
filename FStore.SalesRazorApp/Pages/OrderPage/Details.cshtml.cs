using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FStore.DataAccess.IRepository;
using FStore.BusinessObject;

namespace FStore.SalesRazorApp.Pages.OrderPage
{
    public class DetailsModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;

        public DetailsModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order Order { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Order = await _orderRepository.GetOrderByIdAsync(id);
            if (Order == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FStore.BusinessObject;

namespace FStore.SalesRazorApp.Pages.OrderPage
{
    public class IndexModel : PageModel
    {
        private readonly FStore.BusinessObject.AppDbContext _context;

        public IndexModel(FStore.BusinessObject.AppDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Orders != null)
            {
                Order = await _context.Orders
                .Include(o => o.Member).ToListAsync();
            }
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Remove("Role");
            return RedirectToPage("/Login");
        }
        public IActionResult OnPostEditProfile()
        {
            return Redirect("/MemberPage/Edit");
        }
    }
}

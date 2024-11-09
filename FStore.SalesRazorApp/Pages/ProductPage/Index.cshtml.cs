using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FStore.BusinessObject;
using FStore.DataAccess.IRepository;

namespace FStore.SalesRazorApp.Pages.ProductPage
{
    public class IndexModel : PageModel
    {
        private readonly FStore.BusinessObject.AppDbContext _context;
        private readonly IProductRepository _productRepository;
        public IndexModel(FStore.BusinessObject.AppDbContext context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }

        public IList<Product> Product { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }
        public async Task OnGetAsync()
        {
            if (_context.Products != null)
            {
                Product = string.IsNullOrEmpty(SearchName)
    ? _productRepository.GetProducts()
    : _productRepository.GetProducts()
        .Where(p => p.ProductName.Contains(SearchName, StringComparison.OrdinalIgnoreCase))
        .ToList();
            }
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Remove("Role");
            return RedirectToPage("/Login");
        }
    }
}

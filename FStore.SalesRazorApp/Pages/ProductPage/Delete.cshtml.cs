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
    public class DeleteModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public DeleteModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _productRepository.GetProducts() == null)
            {
                return NotFound();
            }
            var product = _productRepository.GetProductById(id.Value);

            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                Product = product;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (_productRepository.GetProducts() == null)
            {
                return NotFound();
            }
            var product = _productRepository.GetProductById(id);

            if (product != null)
            {
                _productRepository.RemoveProductJson(id);
            }

            return RedirectToPage("./Index");
        }
    }
}

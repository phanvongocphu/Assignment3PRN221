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
    public class DetailsModel : PageModel
    {
        //private readonly FStore.BusinessObject.AppDbContext _context;
        private readonly IProductRepository productRepository;
        //public DetailsModel(FStore.BusinessObject.AppDbContext context)
        //{
        //    _context = context;
        //}
        public DetailsModel(IProductRepository productRepository) {
            this.productRepository = productRepository;
        }
      public Product Product { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || productRepository.GetProducts() == null)
            {
                return NotFound();
            }

            var product = productRepository.GetProductById(id.Value);
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FStore.BusinessObject;
using FStore.DataAccess.IRepository;
using FStore.DataAccess.Repository;

namespace FStore.SalesRazorApp.Pages.ProductPage
{
    public class CreateModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public CreateModel(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult OnGet()
        {
            Categories = new SelectList(_categoryRepository.GetCategories(), "CategoryId", "CategoryName");
            return Page();
        }


        [BindProperty]
        public Product Product { get; set; } = default!;
        public SelectList Categories { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (_productRepository.GetProducts() == null || Product == null)
            {
                Categories = new SelectList(_categoryRepository.GetCategories(), "CategoryId", "CategoryName");
                return Page();
            }

            _productRepository.AddProductJson(Product);

            return RedirectToPage("./Index");
        }
    }
}

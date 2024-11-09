using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FStore.BusinessObject;
using FStore.DataAccess.IRepository;

namespace FStore.SalesRazorApp.Pages.ProductPage
{
    public class EditModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public EditModel(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        public SelectList Categories { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Categories = new SelectList(_categoryRepository.GetCategories(), "CategoryId", "CategoryName");
            if (_productRepository.GetProducts() == null)
            {
                return NotFound();
            }

            var product =  _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            Product = product;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                _productRepository.UpdateProductJson(Product);
            }
            catch (Exception)
            {
                if (!ProductExists(Product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
            return _productRepository.GetProductById(id) != null;
        }
    }
}

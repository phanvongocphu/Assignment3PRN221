using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using FStore.BusinessObject;
using FStore.DataAccess.IRepository;

namespace FStore.SalesRazorApp.Pages.OrderPage
{
    public class CreateModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMemberRepository _memberRepository;

        public CreateModel(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IProductRepository productRepository, IMemberRepository memberRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
            _memberRepository = memberRepository;
        }

        [BindProperty]
        public int SelectedProductId { get; set; }
        [BindProperty]
        public int Quantity { get; set; }
        [BindProperty]
        public float Discount { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public SelectList Products { get; set; }

        public IActionResult OnGet()
        {
            Products = new SelectList(_productRepository.GetProducts(), "ProductId", "ProductName");
            LoadOrderDetailsFromTempData();
            return Page();
        }

        public IActionResult OnPostAddToOrderDetail()
        {
            LoadOrderDetailsFromTempData();

            var product = _productRepository.GetProductById(SelectedProductId);
            var existingDetail = OrderDetails.Find(d => d.ProductId == SelectedProductId);

            if (existingDetail != null)
            {
                existingDetail.Quantity += Quantity;
            }
            else
            {
                OrderDetails.Add(new OrderDetail
                {
                    ProductId = SelectedProductId,
                    Quantity = Quantity,
                    UnitPrice = product.UnitPrice,
                    Discount = Discount,
                    Product = product
                });
            }

            SaveOrderDetailsToTempData();

            Quantity = 1;
            Discount = 0;
            Products = new SelectList(_productRepository.GetProducts(), "ProductId", "ProductName");
            return Page();
        }

        public async Task<IActionResult> OnPostCreateOrderAsync()
        {
            LoadOrderDetailsFromTempData();

            if (OrderDetails.Count == 0)
            {
                return Page();
            }

            var order = new Order
            {
                MemberId = GetCurrentUserId(),
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now.AddDays(7),
                ShippedDate = DateTime.Now.AddDays(14),
                Freight = 10,
                OrderDetails = OrderDetails.Select(od => new OrderDetail
                {
                    ProductId = od.ProductId,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    Discount = od.Discount
                }).ToList()
            };

            _orderRepository.AddOrder(order);

            TempData.Remove("OrderDetails");

            return RedirectToPage("./Index");
        }


        private int GetCurrentUserId()
        {
            var memberIdClaim = User.FindFirst("MemberId")?.Value;
            return memberIdClaim != null ? int.Parse(memberIdClaim) : 0;
        }

        private void SaveOrderDetailsToTempData()
        {
            TempData["OrderDetails"] = JsonConvert.SerializeObject(OrderDetails);
        }

        private void LoadOrderDetailsFromTempData()
        {
            if (TempData.ContainsKey("OrderDetails"))
            {
                OrderDetails = JsonConvert.DeserializeObject<List<OrderDetail>>(TempData["OrderDetails"].ToString());
                TempData.Keep("OrderDetails");
            }
        }
    }
}

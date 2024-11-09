using FStore.BusinessObject;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace FStore.DataAccess.DAO
{
    public class ProductDAO
    {
        private AppDbContext appDbContext;
        private static ProductDAO instance = null;
        public static ProductDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductDAO();
                }
                return instance;
            }
        }
        static string ReadFile(string filename)
        {
            return File.ReadAllText(filename);
        }
        public void writeJson(List<Product> products)
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };
            string jsonData = System.Text.Json.JsonSerializer.Serialize(products, options);

            File.WriteAllText("Data/products.json", jsonData);
        }
        internal static List<Product> ReadData()
        {
            List<Product> products = new();
            var cadJSON = ReadFile("Data/products.json");
            products.AddRange(JsonConvert.DeserializeObject<List<Product>>(cadJSON));
            return products;
        }
        private ProductDAO() {
            appDbContext = new AppDbContext();
        }

        public Product GetProductById(int productId)
        {
            //return appDbContext.Products.SingleOrDefault(p => p.ProductId == productId);
            Product prod = null;
            var productList = ReadData();
            foreach (var product in productList)
            {
                if (product.ProductId == productId)
                {
                    return product;
                }
            }
            return prod;
        }

        public List<Product> GetProducts()
        {
            //using (var appDbContext = new AppDbContext())
            //{
            //    return appDbContext.Products.ToList();
            //}
            return ReadData();
        }

        public bool AddProduct(Product product)
        {
            bool isSuccess = false;
            try
            {
                using (var appDbContext = new AppDbContext())
                {
                    appDbContext.Products.Add(product);
                    appDbContext.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error adding product: " + ex.Message);
            }
            return isSuccess;
        }
        public bool AddProductJson(Product product)
        {
            var productList = ReadData();
            productList.Add(product);
            writeJson(productList);
            return true;
        }
        public bool UpdateProduct(Product product)
        {
            bool isSuccess = false;
            try
            {
                using (var appDbContext = new AppDbContext())
                {
                    var productToUpdate = appDbContext.Products.Find(product.ProductId);
                    if (productToUpdate != null)
                    {
                        appDbContext.Update(product);
                        appDbContext.SaveChanges();
                        appDbContext.Entry(product).State = EntityState.Detached;
                        isSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error updating product: " + ex.Message);
            }
            return isSuccess;
        }
        public bool UpdateProductJson(Product product)
        {
            var products = ReadData();
            Product prod = null;
            foreach (var productToUpdate in products)
            {
                if (productToUpdate.ProductId.Equals(product.ProductId))
                {
                    prod = productToUpdate;
                }
            }
            products.Remove(prod);
            products.Add(product);
            writeJson(products);
            return true;
        }

        public bool RemoveProduct(int productId)
        {
            bool isSuccess = false;
            try
            {
                using (var appDbContext = new AppDbContext())
                {
                    var product = appDbContext.Products.Find(productId);
                    if (product != null)
                    {
                        appDbContext.Products.Remove(product);
                        appDbContext.SaveChanges();
                        isSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error removing product: " + ex.Message);
            }
            return isSuccess;
        }
        public bool RemoveProductJson(int productId)
        {
            var productList = ReadData();
            Product prod = null;
            foreach (var product in productList)
            {
                if (product.ProductId.Equals(productId))
                {
                    prod = product;
                }
            }
            productList.Remove(prod);
            writeJson(productList);
            return true;
        }
    }
}

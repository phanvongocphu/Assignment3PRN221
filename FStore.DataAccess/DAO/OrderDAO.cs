﻿using FStore.BusinessObject;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FStore.DataAccess.DAO
{
    public class OrderDAO
    {
        private AppDbContext appDbContext;
        private static OrderDAO instance = null;
        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDAO();
                }
                return instance;
            }
        }
        public OrderDAO()
        {
            appDbContext = new AppDbContext();
        }
        static string ReadFile(string filename)
        {
            return File.ReadAllText(filename);
        }
        internal static List<Order> ReadData()
        {
            List<Order> orders = new();
            var cadJSON = ReadFile("Data/orders.json");
            orders.AddRange(JsonConvert.DeserializeObject<List<Order>>(cadJSON));
            return orders;
        }
        public Order GetOrderById(int orderId)
        {
            return appDbContext.Orders.SingleOrDefault(o => o.OrderId.Equals(orderId));
        }
        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await appDbContext.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public List<Order> GetOrderByMemberId(int memberId)
        {
            using (var context = new AppDbContext())
            {
                return context.Orders
                    .Where(order => order.MemberId == memberId)
                    .ToList();
            }
        }
        public List<Order> GetOrders()
        {
            //return appDbContext.Orders.ToList();
            return ReadData();
        }
        public bool AddOrder(Order order)
        {
            bool isSuccess = false;
            try
            {
                appDbContext.Orders.Add(order);
                appDbContext.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex) {
                Debug.WriteLine("Error adding order: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Debug.WriteLine("Inner exception: " + ex.InnerException.Message);
                }
            }
            return isSuccess;
        }
        public bool UpdateOrder(Order order)
        {
            bool isSuccess = false;
            try
            {
                Order orderToUpdate = GetOrderById(order.OrderId);
                if (orderToUpdate != null)
                {
                    appDbContext.Update(orderToUpdate);
                    appDbContext.SaveChanges();
                    appDbContext.Entry(order).State = EntityState.Detached;
                    isSuccess = true;
                }
            }
            catch (Exception ex) { }
            return isSuccess;
        }
        public bool RemoveOrder(int orderId)
        {
            bool isSuccess = false;
            try
            {
                Order order = GetOrderById(orderId);
                if (order != null)
                {
                    appDbContext.Entry(order).State = EntityState.Detached;
                    appDbContext.Orders.Remove(order);
                    appDbContext.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex) { }
            return isSuccess;
        }
    }
}

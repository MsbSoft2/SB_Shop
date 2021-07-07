using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SBShop.Data.Context;
using SBShop.Data.DTO.Order;
using SBShop.Data.Models;
using SBShop.Data.Repositories;

namespace SBShop.Data.Servicies
{
    public class OrderRepository : IOrderRepository
    {
        private SBShopContext _context;

        public OrderRepository(SBShopContext context)
        {
            _context = context;
        }

        public async Task<bool> AddToCart(int CurrentUserId, int productId)
        {
            var order = _context.Orders
                .SingleOrDefault(o => o.UserId == CurrentUserId && !o.IsFinaly);

            if (order == null)
            {
                order = new Order()
                {
                    CreateDate = DateTime.Now,
                    IsFinaly = false,
                    UserId = CurrentUserId,
                    Sum = 0
                };
                _context.Orders.Add(order);
                _context.SaveChangesAsync();
                _context.OrderItems.Add(new OrderItem()
                {
                    ProductId = productId,
                    OrderId = order.OrderId,
                    Quantity = 1,
                    Price = _context.Products.Find(productId).Price
                });
                _context.SaveChangesAsync();
                return true;
            }
            else
            {
                var details = _context.OrderItems
                    .SingleOrDefault(o => o.OrderId == order.OrderId && o.ProductId == productId);
                if (details == null)
                {
                    _context.OrderItems.Add(new OrderItem()
                    {
                        ProductId = productId,
                        OrderId = order.OrderId,
                        Quantity = 1,
                        Price = _context.Products.Find(productId).Price
                    });
                }
                else
                {
                    details.Quantity += 1;
                    _context.OrderItems.Update(details);
                }

                _context.SaveChangesAsync();
                return true;
            }

            UpdateSumOrder(order.OrderId);
        }

        public IEnumerable<ShowOrderViewModel> ShowOrder(int CurrentUserId)
        {
            var order = _context.Orders
                .SingleOrDefault(o => o.UserId == CurrentUserId && !o.IsFinaly);

            List<ShowOrderViewModel> _list = new List<ShowOrderViewModel>();

            if (order != null)
            {
                var details = _context.OrderItems
                    .Where(o => o.OrderId == order.OrderId)
                    .Select(od => new ShowOrderViewModel()
                    {
                        OrderDetailId = od.OrderItemId,
                        Count = od.Quantity,
                        Title = od.Product.Name,
                        price = od.Price,
                        Sum = od.Quantity * od.Price,
                        ImageName = od.Product.Image
                    });
                _list.AddRange(details);
            }

            return _list;
        }

        public async Task<bool> DeleteOrder(int orderDetailId)
        {
            try
            {
                var orderDetail = _context.OrderItems.Find(orderDetailId);
                _context.OrderItems.Remove(orderDetail);
                _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CommendOrderDetail(int orderDetailId, string command)
        {
            var orderDetail = _context.OrderItems.Find(orderDetailId);
            switch (command)
            {
                case "up":
                    orderDetail.Quantity += 1;
                    _context.Update(orderDetail);
                    break;
                case "down":
                    if (orderDetail.Quantity == 0)
                    {
                        _context.OrderItems.Remove(orderDetail);
                    }
                    else
                    {
                        orderDetail.Quantity -= 1;
                        _context.Update(orderDetail);
                    }
                    break;
            }

            _context.SaveChanges();
            return true;
        }

        private void UpdateSumOrder(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            order.Sum = _context.OrderItems
                .Where(o => o.OrderId == order.OrderId)
                .Select(d => d.Quantity * d.Price)
                .Sum();
            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }
}

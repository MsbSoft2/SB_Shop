using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SBShop.Data.Context;
using SBShop.Data.DTO.Order;
using SBShop.Data.Models;
using SBShop.Data.Repositories;

namespace SBShop.Web.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IActionResult AddToOrder(int productId)
        {
            var CurrentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
           
            _orderRepository.AddToCart(CurrentUserId,productId);

            return RedirectToAction("ShowOrder");
        }

        public IActionResult ShowOrder()
        {
            var CurrentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            
            return View(_orderRepository.ShowOrder(CurrentUserId));
        }

        public IActionResult Delete(int orderDetailId)
        {
            _orderRepository.DeleteOrder(orderDetailId);
            return RedirectToAction("ShowOrder");
        }

        public IActionResult Commend(int id, string command)
        {
            _orderRepository.CommendOrderDetail(id, command);

            return RedirectToAction("ShowOrder");
        }
    }
}

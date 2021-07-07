using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBShop.Data.DTO.Order;

namespace SBShop.Data.Repositories
{
    public interface IOrderRepository
    {
        Task<bool> AddToCart(int CurrentUserId, int productId);

        IEnumerable<ShowOrderViewModel> ShowOrder(int CurrentUserId);

        Task<bool> DeleteOrder(int orderDetailId);

        Task<bool> CommendOrderDetail(int orderDetailId, string command);
    }
}

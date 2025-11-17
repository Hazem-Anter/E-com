using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.BLL.ModelVM.Order;
using Ecom.BLL.ModelVM.OrderItem;
using Ecom.DAL.Enum;

namespace Ecom.BLL.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo orderRepo;
        private readonly IMapper mapper;

        public OrderService(IOrderRepo orderRepo,IMapper mapper)
        {
            this.orderRepo = orderRepo;
            this.mapper = mapper;
        }
        public async Task<ResponseResult<bool>> AddItemAsync(int orderId, CreateOrderItemVM itemVM)
        {
            try
            {
                //var result = await orderRepo.AddAsync(orderId, itemVM);
                return new ResponseResult<bool>(false, null, false);

            }
            catch (Exception ex) { 
            return new ResponseResult<bool>(false, ex.Message, false);
            }
        }

        public async Task<ResponseResult<GetOrderVM>> CreateOrderAsync(CreateOrderVM model)
        {
            try
            {
                var order = new Order(model.AppUserId, (DateTime)model.DeliveryDate!, model.ShippingAddress,model.ShippingAddress);
               
                await orderRepo.AddAsync(order);
                await orderRepo.SaveChangesAsync();
                return new ResponseResult<GetOrderVM>(mapper.Map<GetOrderVM>(order), null, true);
            }
            catch (Exception ex)
            {
                return new ResponseResult<GetOrderVM>(null, ex.Message, false);
            }
        }

        public async Task<ResponseResult<bool>> DeleteAsync(int id, string userId)
        {
            try
            {
                await orderRepo.DeleteAsync(id,userId);
                await orderRepo.SaveChangesAsync();
                return new ResponseResult<bool>(true, $"Order Deleted Successfuly by {userId}", true);
            }
            catch (Exception ex)
            {
                return new ResponseResult<bool>(false, ex.Message, false);
            }
        }

        public async Task<ResponseResult<List<GetOrderVM>>> GetAllAsync()
        {
            try
            {
                var result = await orderRepo.GetAllAsync();
                if (result == null)
                    return new ResponseResult<List<GetOrderVM>>(null, "Could Not Fetch Order List", false);
                var map = mapper.Map<List<GetOrderVM>>(result);
                return new ResponseResult<List<GetOrderVM>>(map, null, true);
            }
            catch (Exception ex) 
            {
                return new ResponseResult<List<GetOrderVM>>(null, ex.Message, false);
            }
        }

        public async Task<ResponseResult<GetOrderVM>> GetByIdAsync(int id)
        {
            try
            {
                var result = await orderRepo.GetByIdAsync(id);
                if (result == null)
                    return new ResponseResult<GetOrderVM>(null, $"Could Not Fetch Order with the id : {id}", false);
                var map = mapper.Map<GetOrderVM>(result);
                return new ResponseResult<GetOrderVM>(map, null, true);
            }
            catch (Exception ex)
            {
                return new ResponseResult<GetOrderVM>(null, ex.Message, false);
            }
        }

        public Task<ResponseResult<List<GetOrderVM>>> GetByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult<bool>> RemoveItemAsync(int orderId, int itemId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult<bool>> UpdateItemQuantityAsync(int orderId, int itemId, int newQuantity, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult<bool>> UpdateStatusAsync(int id, OrderStatus newStatus, string updatedBy, string? trackingNumber)
        {
            throw new NotImplementedException();
        }
    }
}

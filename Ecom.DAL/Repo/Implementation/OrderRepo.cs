using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DAL.Repo.Implementation
{
    public class OrderRepo : IOrderRepo
    {
        private readonly ApplicationDbContext _context;

        public OrderRepo(ApplicationDbContext dbContext)
        {
            this._context = dbContext;
        }
        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);     
        }

        public async Task DeleteAsync(int Id, string deletedBy)
        {
            var OrderbyId = await _context.Orders.FindAsync(Id);
            if (OrderbyId != null)
            {
                OrderbyId.ToggleDelete(deletedBy);
                _context.Orders.Update(OrderbyId);
            }
        }

        public async Task<IEnumerable<Order>> GetAllAsync(Expression<Func<Order, bool>>? filter = null)
        {
            IQueryable<Order> query = _context.Orders;
            if (filter != null)
                query = query.Where(filter);
            return await query.ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<Order?> GetByOrderNumberAsync(string orderNumber)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.OrderNumber == orderNumber);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await Task.CompletedTask;
        }
    }
}

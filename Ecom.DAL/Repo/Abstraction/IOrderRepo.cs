using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DAL.Repo.Abstraction
{
    public interface IOrderRepo
    {
        Task<Order?> GetByIdAsync(int id);
        Task<Order?> GetByOrderNumberAsync(string orderNumber);
        Task<IEnumerable<Order>> GetAllAsync(Expression<Func<Order, bool>>? filter = null);

        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(int Id, string deletedBy);

        Task<int> SaveChangesAsync();


        // for next Iterations
        /*Task<IEnumerable<Order>> GetByUserIdAsync(string appUserId);
        Task<IEnumerable<Order>> GetByStatusAsync(OrderStatus status);

        // Search & filtering (optional)
        Task<IEnumerable<Order>> FilterAsync(
            OrderStatus? status = null,
            DateTime? fromDate = null,
            DateTime? toDate = null,
            bool includeDeleted = false
        );


        // Includes (navigation loading)
        Task<Order?> GetWithItemsAsync(int id);
        Task<Order?> GetDetailedAsync(int id);  
        // (Items + User + Payment)*/
    }
}

using Magacin.Data;
using Magacin.Models;
using Microsoft.EntityFrameworkCore;

namespace Magacin.Services
{
    public interface IItemService 
    {
        Task<List<Item>> GetAllAsync();
        Task ItemUpdateAsync(Item item);

    }
    public class ItemService : IItemService
    {
        private DB Db { get; init; }
        public ItemService(DB db)
        {
            Db = db;      
        }

        public async Task<List<Item>> GetAllAsync()
            => await Db.Items.ToListAsync();
        public async Task ItemUpdateAsync(Item item)
        {
            Db.Update(item);
            await Db.SaveChangesAsync();
        }
    }
}

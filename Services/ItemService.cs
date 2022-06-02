using Magacin.Data;
using Magacin.Models;
using Microsoft.EntityFrameworkCore;

namespace Magacin.Services
{
    public interface IItemService 
    {
        Task<List<Item>> GetAllAsync();
        Task ItemUpdateAsync(Item item);
        Task UpdateIOAsync(IO io);

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

        public async Task UpdateIOAsync(IO io)
        {
            if (io is Input)
            {
                io.Items.ToList().ForEach(item => item.Key.Amount += item.Value);
            }
            else
            {
                io.Items.ToList().ForEach(item => item.Key.Amount -= item.Value);
            }
            io.GenerateJson();
            Db.Update(io);
            await Db.SaveChangesAsync();
        }
    }
}

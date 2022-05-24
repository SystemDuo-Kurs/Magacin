using Magacin.Data;
using Magacin.Models;

namespace Magacin.Services
{
    public interface IItemService 
    {
        Task UpdateInputAsync(Input input);
    }
    public class ItemService : IItemService
    {
        private DB Db { get; init; }
        public ItemService(DB db)
        {
            Db = db;      
        }

        public async Task UpdateInputAsync (Input input)
        {
            Db.Update(input);
            await Db.SaveChangesAsync();
        }

    }
}

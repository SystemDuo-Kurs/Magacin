using Magacin.Data;
using Magacin.Models;
using Microsoft.EntityFrameworkCore;

namespace Magacin.Services
{
    public interface IItemService 
    {
        Task<List<Item>> GetAllAsync();
        Task ItemUpdateAsync(Item item);
        Task <(bool isOkay, List<string> errors)> UpdateIOAsync(IO io);

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

        public async Task <(bool isOkay, List<string> errors)> UpdateIOAsync(IO io)
        {
            (bool isOkay, List<string> errors) result = (true, new());
                
            if (io is null)
            {
                result.isOkay = false;
                result.errors.Add("IO is null");

                return result;
            }

            if (io is Input)
            {
                io.Items.ToList().ForEach(item => item.Key.Amount += item.Value);
            }
            else
            {
                io.Items.ToList().ForEach(item => item.Key.Amount -= item.Value);
            }

            io.GenerateJson();

            try
            {
                Db.Update(io);
                await Db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                result.isOkay = false;
                result.errors.Add(e.Message);
                return result;
            }

            return result;
        }
    }
}

using Magacin.Data;
using Magacin.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Magacin.Services
{
    public interface IIOService
    {
        Task<(bool isOkay, List<string> errors)> UpdateIOAsync(IO io);
        Task<List<IO>> GetAllAsync(Type type);
    }
    public class IOService : IIOService
    {
        private DB Db { get; init; }

        public IOService(DB db)
        {
            Db = db;
        }
        public async Task<(bool isOkay, List<string> errors)> UpdateIOAsync(IO io)
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

        //Isto radi ka ovo dole da znamo :)
        /*public async Task <List<IO>> GetAllAsync(Type type)
        {
            if(type == typeof(Input))
            {
                return await Db.IOs.Where(io => io is Input).ToListAsync();
            }
            else
            {
                return await Db.IOs.Where(io => io is Output).ToListAsync();
            }
        }*/

        public async Task<List<IO>> GetAllAsync(Type type)
        {
            var list = await Db.IOs.Where(io => io.GetType() == type).ToListAsync();
            foreach(var io in list)
            {
                var items = JsonSerializer.Deserialize<Dictionary<int, double>>(io.ItemsForDb);
                items.ToList().ForEach(async item => io.Items.Add(await Db.Items.FindAsync(item.Key), item.Value));
            } 
            return list;
        }
            
    }
}

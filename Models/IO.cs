using System.Text.Json;

namespace Magacin.Models
{
    public abstract class IO
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }

        public Dictionary<Item, double> Items { get; set; } = new();

        public void AddItem(Item item, double amount)
        {
            Items.Add(item, amount);
            GenerateJson();
        }

        public void GenerateJson()
            => ItemsForDb = JsonSerializer.
            Serialize(Items.Select(pair => new KeyValuePair<int, double>(pair.Key.Id, pair.Value)));

        public string ItemsForDb { get; set; } = string.Empty;


       
    }

    public class Input : IO { }
    public class Output : IO { }
}

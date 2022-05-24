using System.Text.Json;

namespace Magacin.Models
{
    public abstract class IO
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }

        public Dictionary<Item, int> Items { get; set; } = new();

        public void AddItem(Item item, int amount)
        {
            Items.Add(item, amount);
            var asd = Items.Select(pair => new KeyValuePair<int, int>(pair.Key.Id, pair.Value));
            ItemsForDb = JsonSerializer.Serialize(asd);
        }

        public string ItemsForDb { get; set; } = string.Empty;


       
    }

    public class Input : IO { }
    public class Output : IO { }
}

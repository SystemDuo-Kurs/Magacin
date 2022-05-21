using System.Text.Json;

namespace Magacin.Models
{
    public class IO
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }

        public Dictionary<Item, int> Items = new();

        public string ItemsForDb
        {
            get
            {
                var asd = Items.Select(pair => new KeyValuePair<int, int>(pair.Key.Id, pair.Value));
                return JsonSerializer.Serialize(asd);
            }
        }
    }
}

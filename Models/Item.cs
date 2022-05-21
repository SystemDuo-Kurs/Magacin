namespace Magacin.Models
{
    public class Item
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Unit Unit { get; set; }
    }
    public enum Unit
    {
        Kg,
        m,
        ps,
        l
    }
}

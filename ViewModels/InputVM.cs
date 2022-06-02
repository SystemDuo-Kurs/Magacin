using Magacin.Models;
using Magacin.Services;

namespace Magacin.ViewModels
{
    public interface IInputVM
    {
        List<Item> Items { get; set; }
        Item? SelectedItem { get; set; }
        Input Input { get; set; }
        double Amount { get; set; }
        Task GetAllAsync();
        void AddItem();
        Task UpdateInputAsync();
    }
    public class InputVM : IInputVM
    {
        private IItemService ItemService { get; init; }
        public List<Item> Items { get; set; } = new();
        public Item? SelectedItem { get; set; }
        public Input Input { get; set; } = new();
        public double Amount { get; set; } = 1;
        public InputVM(IItemService itemService)
        {
            ItemService = itemService;
        }
        public async Task GetAllAsync() 
            => Items = await ItemService.GetAllAsync();
        public void AddItem()
        {
            if (Input.Items.ContainsKey(SelectedItem))
            {
                Input.Items[SelectedItem] = Amount;
            }
            else
            {
                Input.Items.Add(SelectedItem, Amount);
            }
            SelectedItem = null;
            Amount = 1;
        }

        public async Task UpdateInputAsync()
        {
            await ItemService.UpdateIOAsync(Input);
            Input = new();
        }

    }
}

using Magacin.Models;
using Magacin.Services;

namespace Magacin.ViewModels
{
    public interface IItemEdit
    {
        Item Item { get; set; }
        Task ItemUpdateAsync();
    }
    public class ItemEdit : IItemEdit
    {
        public Item Item { get; set; } = new();
        private IItemService ItemService { get; init; }

        public ItemEdit(IItemService itemService)
        {
            ItemService = itemService;
        }
        public async Task ItemUpdateAsync()
        {
            await ItemService.ItemUpdateAsync(Item);
            Item = new();
        }
    }
}

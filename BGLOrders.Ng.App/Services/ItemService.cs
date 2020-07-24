using BGLOrderApp.Data.Repositories;
using BGLOrderApp.Models;
using BGLOrderApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGLOrderApp.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public ItemDto GetById(int id)
        {
            var dbItem = _itemRepository.Get(id);

            return dbItem == null ? null : ItemDto.FromDbItem(dbItem);
        }

        public IEnumerable<ItemDto> GetAll()
        {
            return _itemRepository.GetAll()
                .Select(i => ItemDto.FromDbItem(i))
                .OrderBy(i => i.Name);
        }

        public void Add(Item item)
        {
            _itemRepository.Create(item);
        }

        public void Update(Item item)
        {
            _itemRepository.Update(item);
        }

        public void Add(ItemDto itemDto)
        {
            var item = new Item()
            {
                Name = itemDto.Name,
                Description = itemDto.Description,
                Price = itemDto.Price,
                Status = (int)itemDto.Status
            };

            _itemRepository.Create(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

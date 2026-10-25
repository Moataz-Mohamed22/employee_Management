using CQRS_lib.Data;
using CQRS_lib.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_lib.Repos
{
    public class ItemsRepo : IItemsRepo
    {
        private readonly AppDbContext _context;

        public ItemsRepo(AppDbContext context)
        {
            _context = context;
        }

        public Item GetItemById(int id)
        {
            var item = _context.Items.Where(x => x.Id == id).FirstOrDefault();
            return item ??new();
        }

        public List<Item> GetItems()
        {
            var items = _context.Items.ToList();
            return items;
        }
        public int AddItem(Item item)
        {
           _context.Items.Add(item);
            return _context.SaveChanges();
        }

        public int UpdateItem(Item item)
        {
            try
            {
                _context.Items.Attach(item);
                 _context.Entry(item).State =EntityState.Modified;
                return 1;
            }
            catch (Exception ex) {
                return 0;
            }
        }
        public int DeleteItem(int id)
        {
            var item = _context.Items.FirstOrDefault(x =>x.Id == id);
            if(item != null)_context.Items.Remove(item ?? new());
            return _context.SaveChanges();
        }
    }
}

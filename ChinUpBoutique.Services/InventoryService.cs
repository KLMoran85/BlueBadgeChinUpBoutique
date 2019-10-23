using ChinUpBoutique.Data;
using ChinUpBoutique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinUpBoutique.Services
{
    
    public class InventoryService
    {
        private readonly Guid _userId; 

        public InventoryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateInventory(InventoryCreate model)
        {
            var entity =
                new Inventory()
                {
                    
                    ItemName = model.ItemName,
                    SkuNumber = model.SkuNumber,
                    ItemDescription = model.ItemDescription,
                    ItemPrice = model.ItemPrice,
                    TypeOfItem = model.TypeOfItem
                };

                using (var ctx = new ApplicationDbContext())
            {
                ctx.Inventory.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<InventoryListItem> GetInventory()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx

                        .Inventory
                        .Select(
                            e =>
                                new InventoryListItem
                                {
                                    ItemID = e.ItemID,
                                    ItemName = e.ItemName,
                                    SkuNumber = Convert.ToInt32(e.SkuNumber),
                                    ItemDescription = e.ItemDescription,
                                    ItemPrice = e.ItemPrice,
                                    TypeOfItem = e.TypeOfItem
                                }

                         );
                return query.ToArray();
            }

        }
    }
}

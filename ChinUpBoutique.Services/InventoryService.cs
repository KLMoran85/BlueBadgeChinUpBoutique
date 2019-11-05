using ChinUpBoutique.Data;
using ChinUpBoutique.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
                                    SkuNumber = e.SkuNumber,
                                    ItemDescription = e.ItemDescription,
                                    ItemPrice = e.ItemPrice,
                                    TypeOfItem = e.TypeOfItem
                                }

                         );
                return query.ToArray();
            }

        }

        public InventoryDetail GetInventoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Inventory.Single(e => e.ItemID == id);

                return
                    new InventoryDetail
                    {
                        ItemID = entity.ItemID,
                        ItemName = entity.ItemName,
                        SkuNumber = entity.SkuNumber,
                        ItemDescription = entity.ItemDescription,
                        ItemPrice = entity.ItemPrice,
                        TypeOfItem = entity.TypeOfItem
                    };

            }

        }

        public bool UpdateInventory(InventoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                      .Inventory
                      .Single(e => e.ItemID == model.ItemID);

                entity.ItemID = model.ItemID;
                entity.ItemName = model.ItemName;
                entity.SkuNumber = model.SkuNumber;
                entity.ItemDescription = model.ItemDescription;
                entity.ItemPrice = model.ItemPrice;
                entity.TypeOfItem = model.TypeOfItem;

                if(model.Photo != null)
                {

                MemoryStream target = new MemoryStream();
                model.Photo.InputStream.CopyTo(target);
                byte[] data = target.ToArray();

                entity.Photo = data;
                }

                return ctx.SaveChanges() == 1;
            }

        }

        public bool DeleteInventory(int ItemID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Inventory
                        .Single(e => e.ItemID == ItemID);

                ctx.Inventory.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}


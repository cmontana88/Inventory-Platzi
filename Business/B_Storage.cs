using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class B_Storage
    {
        public static List<StorageEntity> StorageList()
        {
            using (var db = new InventoryContext())
            {
                return db.Storages
                    .Include(s => s.Product)
                    .Include(s => s.Warehouse)
                    .ToList();
            }
        }

        public static StorageEntity CreateStorage(StorageEntity oStorage)
        {
            using (var db = new InventoryContext())
            {
                db.Storages.Add(oStorage);
                db.SaveChanges();

                return GetStorageById(oStorage.StorageId);
            }
        }

        public static StorageEntity GetStorageById(string idWarehouse)
        {
            using (var db = new InventoryContext())
            {
                return db.Storages
                    .Include(s => s.Product)
                    .Include(s => s.Warehouse)
                    .ToList()
                    .LastOrDefault(s => s.StorageId.Equals(idWarehouse));
            }
        }

        public static bool IsProductInWarehouse(string idStorage)
        {
            using (var db = new InventoryContext())
            {
                var product = db.Storages.ToList()
                    .Where(s => s.StorageId.Equals(idStorage));

                return product.Any();
            }
        }

        public static List<StorageEntity> StorageListByWarehouse(string idWarehouse)
        {
            using (var db = new InventoryContext())
            {
                return db.Storages
                    .Include(s => s.Product)
                    .Include(s => s.Warehouse)
                    .Where(s => s.WarehouseId.Equals(idWarehouse))
                    .ToList();
            }
        }


        public static void UpdateStorage(StorageEntity oStorage)
        {
            using (var db = new InventoryContext())
            {
                db.Storages.Update(oStorage);
                db.SaveChanges();
            }
        }
    }
}

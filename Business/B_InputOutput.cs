using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class B_InputOutput
    {
        public static List<InputOutputEntity> InOutList()
        {
            using (var db = new InventoryContext())
            {
                return db.InOuts.ToList();
            }
        }

        public static void CreateInOut(InputOutputEntity oInOut)
        {
            using (var db = new InventoryContext())
            {
                db.InOuts.Add(oInOut);
                db.SaveChanges();
            }
        }

        public static void UpdateInOut(InputOutputEntity oInOut)
        {
            using (var db = new InventoryContext())
            {
                db.InOuts.Update(oInOut);
                db.SaveChanges();
            }
        }
    }
}

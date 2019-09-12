using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF2SQLLibrary {

    public class RequestLineRepository {

        private static PrsDBContext context = new PrsDBContext();

        public static List<RequestLines> GetAll() {
            return context.RequestLines.ToList();
        }

        public static RequestLines GetByPk(int id) {
            return context.RequestLines.Find(id);
        }

        public static bool Insert(RequestLines rline) {
            if (rline == null) { throw new Exception("Request Line instant must not be null"); }
            rline.Id = 0;
            context.RequestLines.Add(rline);
            return context.SaveChanges() == 1;
        }

        public static bool Update(RequestLines rline) {
            if (rline == null) { throw new Exception("Request Line instant must not be null"); }
            var dbrline = context.RequestLines.Find(rline.Id);
            if (dbrline == null) { throw new Exception("No requestline with that ID"); }
            dbrline.Id = rline.Id;
            dbrline.RequestId = rline.RequestId;
            dbrline.ProductId = rline.ProductId;
            dbrline.Quantity = rline.Quantity;
            return context.SaveChanges() == 1;
        }

        public static bool Delete(Vendors vendor) {
            if (vendor == null) { throw new Exception("Vendor instant must not be null"); }
            var dbvendor = context.Vendors.Find(vendor.Id);
            if (dbvendor == null) { throw new Exception("No vendor with that ID"); }
            context.Vendors.Remove(dbvendor);
            return context.SaveChanges() == 1;
        }
        public static bool Delete(int id) {
            var vendor = context.Vendors.Find(id);
            if (vendor == null) { return false; }
            var rc = Delete(vendor);
            return context.SaveChanges() == 1;
        }
    }
}

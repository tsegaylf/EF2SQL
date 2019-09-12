using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF2SQLLibrary {
    public class VendorRepository {

        private static PrsDBContext context = new PrsDBContext();

        public static List<Vendors> GetAll() {
            return context.Vendors.ToList();
        }

        public static Vendors GetByPk(int id) {
            return context.Vendors.Find(id);
        }

        public static bool Insert(Vendors vendor) {
            if (vendor == null) { throw new Exception("Vendor instant must not be null"); }
            vendor.Id = 0;
            context.Vendors.Add(vendor);
            return context.SaveChanges() == 1;
        }

        public static bool Update(Vendors vendor) {
            if (vendor == null) { throw new Exception("Vendor instant must not be null"); }
            var dbvendor = context.Vendors.Find(vendor.Id);
            if (dbvendor == null) { throw new Exception("No vendor with that ID"); }
            dbvendor.Id = vendor.Id;
            dbvendor.Code = vendor.Code;
            dbvendor.Address = vendor.Address;
            dbvendor.City = vendor.City;
            dbvendor.State = vendor.State;
            dbvendor.Zip = vendor.Zip;
            dbvendor.Phone = vendor.Phone;
            dbvendor.Email = vendor.Email;
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

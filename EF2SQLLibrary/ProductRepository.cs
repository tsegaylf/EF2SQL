using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF2SQLLibrary {

    public class ProductRepository {

        private static PrsDBContext context = new PrsDBContext();

        public static List<Products> GetAll() {
            return context.Products.ToList();
        }

        public static Products GetByPk(int id) {
            return context.Products.Find(id);
        }

        public static bool Insert(Products product) {
            if (product == null) { throw new Exception("Product instant must not be null"); }
            product.Id = 0;
            context.Products.Add(product);
            return context.SaveChanges() == 1;
        }

        public static bool Update(Products product) {
            if (product == null) { throw new Exception("Product instant must not be null"); }
            var dbproduct = context.Products.Find(product.Id);
            if (dbproduct == null) { throw new Exception("No product with that ID"); }
            dbproduct.Id = product.Id;
            dbproduct.PartNbr = product.PartNbr;
            dbproduct.Name = product.Name;
            dbproduct.Price = product.Price;
            dbproduct.Unit = product.Unit;
            dbproduct.PhotoPath = product.PhotoPath;
            dbproduct.VendorId = product.VendorId;
            return context.SaveChanges() == 1;
        }

        public static bool Delete(Products product) {
            if (product == null) { throw new Exception("Product instant must not be null"); }
            var dbproduct = context.Products.Find(product.Id);
            if (dbproduct == null) { throw new Exception("No product with that ID"); }
            context.Products.Remove(dbproduct);
            return context.SaveChanges() == 1;
        }
        public static bool Delete(int id) {
            var product = context.Products.Find(id);
            if (product == null) { return false; }
            var rc = Delete(product);
            return context.SaveChanges() == 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF2SQLLibrary {

    public class RequestLineRepository {

        private static PrsDBContext context = new PrsDBContext();

        //private static void ReCalRequestTotal(int requestId) {
        //    var request = RequestRepository.GetByPk(requestId);
        //    request.Total = request.RequestLines.Sum(1 => 1.Product.Price * 1.Quantity);
        //    //SaveChange is after this code is Insert, Update, Delete
        //}

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
            //ReCalRequestTotal(rline.RequestId);
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
            //ReCalRequestTotal(dbrline.RequestId);
            return context.SaveChanges() == 1;
        }

        public static bool Delete(RequestLines rline) {
            if (rline == null) { throw new Exception("RequestLine instant must not be null"); }
            var dbrline = context.RequestLines.Find(rline.Id);
            if (dbrline == null) { throw new Exception("No requestline with that ID"); }
            context.RequestLines.Remove(dbrline);
            //ReCalRequestTotal(dbrline.RequestId);
            return context.SaveChanges() == 1;
        }
        public static bool Delete(int id) {
            var rline = context.RequestLines.Find(id);
            if (rline == null) { return false; }
            var rc = Delete(rline);
            return context.SaveChanges() == 1;
        }
    }
}

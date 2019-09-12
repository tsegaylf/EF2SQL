using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF2SQLLibrary {

    public class RequestRepository {

        private static PrsDBContext context = new PrsDBContext();

        public static List<Requests> GetAll() {
            return context.Requests.ToList();
        }

        public static Requests GetByPk(int id) {
            return context.Requests.Find(id);
        }

        public static bool Insert(Requests request) {
            if(request == null) { throw new Exception("Request instance must not be null"); }
            request.Id = 0;
            context.Requests.Add(request);
            return context.SaveChanges() == 1;
        }

        public static bool Update(Requests request) {
            if (request == null) { throw new Exception("Request instance must not be null"); }
            var dbrequest = context.Requests.Find(request.Id);
            if (dbrequest == null) { throw new Exception("No product with that ID"); }
            dbrequest.Id = request.Id;
            dbrequest.Description = request.Description;
            dbrequest.Justification = request.Justification;
            dbrequest.RejectionReason = request.RejectionReason;
            dbrequest.DiliveryMode = request.DiliveryMode;
            dbrequest.Status = request.Status;
            dbrequest.Total = request.Total;
            dbrequest.UserId = request.UserId;
            return context.SaveChanges() == 1;
        }

        public static bool Delete(Requests request) {
            if (request == null) { throw new Exception("Request instance must not be null"); }
            var dbrequest = context.Requests.Find(request.Id);
            if (dbrequest == null) { throw new Exception("No product with that ID"); }
            context.Requests.Remove(dbrequest);
            return context.SaveChanges() == 1;
        }
        public static bool Delete(int id) {
            var request = context.Requests.Find(id);
            if (request == null) { return false; }
            var rc = Delete(request);
            return context.SaveChanges() == 1;
        }
    }
}

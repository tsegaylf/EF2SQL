using EF2SQLLibrary;
using System;
using System.Linq;

namespace EF2SQL {
    class Program {
        static void Main(string[] args) {

            //Create instance of the context
            using (var context = new PrsDBContext()) {

                #region Examples
                //update a request into SQL table
                //var request = new Requests() {
                //    Id = 0,
                //    Description = "One More Time",
                //    Justification = "Just for fun!",
                //    RejectionReason = null,
                //    DiliveryMode = "Pickup",
                //    Status = "New",
                //    Total = 23,
                //    UserId = context.Users.SingleOrDefault(u => u.Username.Equals("ABC789")).Id
                //};
                //context.Requests.Add(request); // this does not update the database, it updates the collection
                //context.SaveChanges(); // this saves it into the database

                //update a column for a request
                //var request = context.Requests.Find(2); // read the record
                //request.Total = 200; //make the change
                //context.SaveChanges();


                //updating info: changes made by a user to update the database
                //var request = new Requests() { Id = 3, Description = "New New Request" };
                //var dbRequest = context.Requests.Find(request.Id);
                //dbRequest.Description = request.Description;
                //context.SaveChanges();


                //Delete a record in sql using EF
                //var request = new Requests() { Id = 3, Description = "New New Request" };
                //var dbRequest = context.Requests.Find(request.Id);
                //dbRequest.Description = request.Description;
                //context.Requests.Remove(dbRequest);
                //context.SaveChanges();


                //first thing you reference is the "context" instance 
                //var bruetta = context.Vendors.Find(5);
                //Console.WriteLine($"{bruetta.Code} {bruetta.Name}") ;

                //var users = context.Users.ToList();
                //users.ForEach(u => Console.WriteLine($"{u.Username} {u.Firstname } {user.LastName}")); better way to do the foreach below

                //Read for a request /use the ID/ that has lines in it/print of rquest and 
                //all lines in request (description status total) and line item 

                //var request3 = context.Requests.Find(2);
                //Console.WriteLine($"{request3.Description} {request3.Status} {request3.Total.ToString("C")}");

                //Multiple line on a request line
                //request3.Total = request3.RequestLines.Sum(1 => 1.Product.Price * 1.Quantity);

                //request3.RequestLines.ToList().ForEach(request1 => {
                //    Console.WriteLine($"{request1.Product.Name,-10} {request1.Quantity,5} " +
                //        $"{request1.Product.Price.ToString("C"),10} " +
                //        $"{(request1.Product.Price * request1.Quantity).ToString("C"),11}");
                //});
                #endregion

                //Tally up grand total of all request
                //var reqs = (from r in context.Requests
                //            select r).ToList();
                //reqs.ForEach(r => {
                //    r.Total = r.RequestLines.Sum();
                //    ToConsole(r)});

                //context.SaveChanges();

                var total = context.Requests.Sum(r => r.Total);
                    Console.WriteLine($"Total of all request is {total}");


                    #region ToList Example
                    //var users = from u in context.Users.ToList()
                    //            where u.Username.Contains("5") || u.Username.Contains("8")
                    //            select u;

                    //foreach (var user in users) {
                    //    Console.WriteLine($"{user.Username} {user.FirstName} {user.LastName}");
                    //}
                    #endregion

                }

        }
    }
}

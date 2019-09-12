using EF2SQLLibrary;
using System;
using System.Linq;

namespace EF2SQL {
    class Program {
        static void Main(string[] args) {

            //Create instance of the context
            using (var context = new PrsDBContext()) {

                #region Insert/Delete/Update Examples
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

                //Tally up grand total of all request
                //var reqs = (from r in context.Requests
                //            select r).ToList();
                //reqs.ForEach(r => {
                //    r.Total = r.RequestLines.Sum();
                //    ToConsole(r)});

                //context.SaveChanges();

                //var total = context.Requests.Sum(r => r.Total);
                //    Console.WriteLine($"Total of all request is {total}");
                #endregion

                #region ToList Example
                //var users = from u in context.Users.ToList()
                //            where u.Username.Contains("5") || u.Username.Contains("8")
                //            select u;

                //foreach (var user in users) {
                //    Console.WriteLine($"{user.Username} {user.FirstName} {user.LastName}");
                //}
                #endregion

                Console.WriteLine("LIST USERS");
                var users = context.Users.ToList();
                users.ForEach(user => Console.WriteLine($"UserID = {user.Id} Name = {user.FirstName} {user.LastName} " +
                    $"Phone = {user.Phone} Email = {user.Email} IsAdmin = {user.IsAdmin} IsReviewer = {user.IsReviewer}"));

                Console.WriteLine("FIND VENDORS");
                var vendor = context.Vendors.Find(5);
                Console.WriteLine($"VendorID = {vendor.Id} Code = {vendor.Code} Name = {vendor.Name}" +
                    $"Address = {vendor.Address}, {vendor.City}, {vendor.State} {vendor.Zip}" +
                    $"Phone = {vendor.Phone} Email = {vendor.Email}");

                Console.WriteLine("PRODUCT INSERT");
                var product = new Products() {
                    PartNbr = "KSD33",
                    Name = "Notepads",
                    Price = 64,
                    Unit = "Each",
                    PhotoPath = null,
                    VendorId = 5,
                };
                context.Products.Add(product);
                context.SaveChanges();

                product = context.Products.Find(14);
                Console.WriteLine($"{product.Id} {product.PartNbr} {product.Name} {product.Price}");

                Console.WriteLine("REQUEST UPDATE");
                var request = context.Requests.Find(5);
                request.Description = "New New Request";
                context.Requests.Update(request);
                context.SaveChanges();
                Console.WriteLine($"{request.Id} {request.Description} {request.Total}");

                //Console.WriteLine("PRODUCT DELETE");
                //var dpro = context.Products.Find(3);
                //context.Products.Remove(dpro);
                //context.SaveChanges();

                /////////////////////////////////////////////////////////////////

                //Console.WriteLine("REQUESTLINE INSERT");
                //var rline = new RequestLines() {
                //    Quantity = 2,
                //};
                //context.RequestLines.Add(rline);
                //context.SaveChanges();

                //rline = context.RequestLines.Find();
                //Console.WriteLine($"{rline.ProductId} {rline.Product} {rline.Quantity}");


                //Console.WriteLine("REQUESTLINE DELETE");
                //var users = context.Users.ToList();
                //users.ForEach(user => Console.WriteLine($"UserID = {user.Id} Name = {user.FirstName} {user.LastName} " +
                //    $"Phone = {user.Phone} Email = {user.Email} IsAdmin = {user.IsAdmin} IsReviewer = {user.IsReviewer}"));

            }

        }
    }
}

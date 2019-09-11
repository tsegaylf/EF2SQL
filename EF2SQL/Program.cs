using EF2SQLLibrary;
using System;
using System.Linq;

namespace EF2SQL {
    class Program {
        static void Main(string[] args) {

            //Create instance of the context
            using (var context = new PrsDBContext()) {

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
                //var request = context.Requests.Find(3); // read the record
                //request.Total = 71; //make the change
                //context.SaveChanges();


                //updating info: changes made by a user to update the database
                var request = new Requests() { Id = 3, Description = "New New Request" };
                var dbRequest = context.Requests.Find(request.Id);
                dbRequest.Description = request.Description;
                context.SaveChanges();


                //first thing you reference is the "context" instance 
                var bruetta = context.Vendors.Find(5);
                Console.WriteLine($"{bruetta.Code} {bruetta.Name}") ;

                //var users = context.Users.ToList();
                //users.ForEach(u => Console.WriteLine($"{u.Username} {u.Firstname } {user.LastName}")); better way to do the foreach below

                var users = from u in context.Users.ToList()
                            where u.Username.Contains("5") || u.Username.Contains("8")
                            select u;

                foreach (var user in users) {
                    Console.WriteLine($"{user.Username} {user.FirstName} {user.LastName}");
                }


            } 

        }
    }
}

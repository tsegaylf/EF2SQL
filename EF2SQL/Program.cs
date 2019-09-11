using EF2SQLLibrary;
using System;
using System.Linq;

namespace EF2SQL {
    class Program {
        static void Main(string[] args) {

            //Create instance of the context
            using (var context = new PrsDBContext()) {

                //first thing you reference is the "context" instance 
                var users = context.Users.ToList();
                foreach (var user in users) {
                    Console.WriteLine($"{user.Username} {user.FirstName} {user.LastName}");
                }

            }

        }
    }
}

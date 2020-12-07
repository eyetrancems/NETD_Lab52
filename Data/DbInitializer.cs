// Intialize database
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NETD_Lab52.Models;

namespace NETD_Lab52.Data
{
    public class DbInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            context.Database.EnsureCreated();

            // Look for any client.
            if (context.Clients.Any())
            {
                return;   // DB has been seeded
            }

            var clients = new Client[]
            {
            new Client{FirstName="David",LastName="Nguyen"},
            new Client{FirstName="Winnie",LastName="Pooh"},
            new Client{FirstName="Peter",LastName="Pan"}
            
            };
            foreach (Client c in clients)
            {
                context.Clients.Add(c);
            }
            context.SaveChanges();

            var books = new Book[]
            {
            new Book{BookID=1000,Title="Ripley's Believe it or not",Author="David Jack"},
            new Book{BookID=1001,Title="Toronto Blue Jays History",Author="Jin Mack"},
            new Book{BookID=1002,Title="History of Oshawa, Ontario, Canada",Author="GM Plant"}
            };
            foreach (Book b in books)
            {
                context.Books.Add(b);
            }
            context.SaveChanges();

            var holds = new Hold[]
            {
            new Hold{ClientID=1,BookID=1000},
            new Hold{ClientID=2,BookID=1001},
            new Hold{ClientID=3,BookID=1002}
            };
            foreach (Hold h in holds)
            {
                context.Holds.Add(h);
            }
            context.SaveChanges();
        }
    }
}
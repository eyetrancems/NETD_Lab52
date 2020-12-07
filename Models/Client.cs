// Client class table
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETD_Lab52.Models
{
    public class Client
    {
        // Setter and getter
        public int ClientID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        // list 'joining table'
        public ICollection<Hold> Holds { get; set; }
    }
}

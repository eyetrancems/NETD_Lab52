// Hold class table 'joins' book and client
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETD_Lab52.Models
{
    public class Hold
    {
        // Setter and getter
        public int HoldID { get; set; }
        public int BookID { get; set; }
        public int ClientID { get; set; }

        // linking tables
        public Book Book { get; set; }
        public Client Client { get; set; }
    }
}

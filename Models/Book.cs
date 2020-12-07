// Book class table
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETD_Lab52.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        // Set and getters
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        // list 'joining table'
        public ICollection<Hold> Holds { get; set; }
    }
}

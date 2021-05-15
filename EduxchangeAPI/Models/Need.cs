using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxchangeAPI.Models
{
    public class Need : Publication
    {
        public int AmountNeeded { get; set; }

        public int AmountProduct { get; set; }

        public int AmountCash { get; set; }

        public int ValuePerProduct { get; set; }

        public School Author { get; set; }

        public ICollection<Helps> Helps { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EduxchangeApp.Models
{
    public class Need
    {
        public int AmountNeeded { get; set; }

        public int AmountProduct { get; set; }

        public int AmountCash { get; set; }

        public int ValuePerProduct { get; set; }

        public School Author { get; set; }

        public ICollection<Helps> Helps { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxchangeAPI.Models
{
    public class Give : Publication
    {
        public int Amount { get; set; }

        public User Author { get; set; }

        public School Beneficiary { get; set; }
    }
}

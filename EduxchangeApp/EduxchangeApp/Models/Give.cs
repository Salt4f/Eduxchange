using System;
using System.Collections.Generic;
using System.Text;

namespace EduxchangeApp.Models
{
    public class Give : Publication
    {
        public int Amount { get; set; }

        public User Author { get; set; }

        public School Beneficiary { get; set; }
    }
}

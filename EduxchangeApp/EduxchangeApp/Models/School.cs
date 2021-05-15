using System;
using System.Collections.Generic;
using System.Text;

namespace EduxchangeApp.Models
{
    public class School : User
    {
        public string Address { get; set; }

        public ICollection<Need> Needs { get; set; }

        public ICollection<Give> GivesTaken { get; set; }
    }
}

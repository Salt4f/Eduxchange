using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxchangeAPI.Models
{
    public class School : User
    {

        public string Address { get; set; }

        public ICollection<Need> Needs { get; set; }

        public ICollection<Give> GivesTaken { get; set; }

    }
}

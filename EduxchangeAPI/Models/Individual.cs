using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxchangeAPI.Models
{
    public class Individual : User
    {

        public ICollection<Helps> Helps { get; set; }

    }
}

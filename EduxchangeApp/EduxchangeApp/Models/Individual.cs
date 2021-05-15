using System;
using System.Collections.Generic;
using System.Text;

namespace EduxchangeApp.Models
{
    public class Individual : User
    {
        public ICollection<Helps> Helps { get; set; }
    }
}

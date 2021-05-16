using System;
using System.Collections.Generic;
using System.Text;

namespace EduxchangeApp.Models
{
    public class User
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string About { get; set; }


        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public ICollection<Give> Gives { get; set; }
    }
}

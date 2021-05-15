using System;
using System.Collections.Generic;
using System.Text;

namespace EduxchangeApp.Models
{
    public enum Tags
    {

    }
    public class Publication
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public DateTime Deadline { get; set; }

        public byte[] Photo { get; set; }

        public Tags[] Tags { get; set; }

        public bool Fulfilled { get; set; }
    }
}

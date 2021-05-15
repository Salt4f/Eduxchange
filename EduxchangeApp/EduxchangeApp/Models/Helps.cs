using System;
using System.Collections.Generic;
using System.Text;

namespace EduxchangeApp.Models
{

    public enum HelpType
    {
        Cash,
        Product
    }

    public class Helps
    {
        public string IndividualID { get; set; }
        public Individual Individual { get; set; }

        public long NeedID { get; set; }
        public Need Need { get; set; }

        public HelpType Type { get; set; }

        public int Amount { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    }
}

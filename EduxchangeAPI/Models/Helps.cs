using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduxchangeAPI.Models
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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }

    }
}

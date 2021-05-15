using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduxchangeAPI.Models
{
    public enum Tags
    {
        Elementary,
        HighSchool,
        Books,
        Material,
        Clothes,
        Hardware
    }

    public class Publication
    {
        [Key]
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public DateTime Deadline { get; set; }

        public byte[] Photo { get; set; }

        public Tags[] Tags { get; set; }

        public bool Fulfilled { get; set; }
    }
}

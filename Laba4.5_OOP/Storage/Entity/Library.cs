using Laba_OOP.Storage;
using Laba_OOP.Storage.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Laba4._5_OOP.Storage.Entity
{
    [Table("tblLibrary")]
    public class Library : IUniqueEntity
    {
        [Key]
        [Required]
        [Column("gId")]
        public Guid Id { get; set; }

        [Required]
        [Column("szName")]
        public string Name { get; set; }

        public List<Worker> Workers { get; set; }
        public List<Category> Categories { get; set; }
        public List<Reader> Readers { get; set; }
    }
}

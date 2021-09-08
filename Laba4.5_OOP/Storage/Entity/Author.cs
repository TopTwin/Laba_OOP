using Laba_OOP.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Laba4._5_OOP.Storage.Entity
{
    [Table("tblAuthor")]
    public class Author: IUniqueEntity
    {
        [Key]
        [Required]
        [Column("gId")]
        public Guid Id { get; set; }

        [Required]
        [Column("szName")]
        public string Name { get; set; }


        [Required]
        [Column("szDateLife")]
        public string DateLife { get; set; }

        [Required]
        [Column("szBiograp")]
        public string Biography { get; set; }


        public List<Book> Books { get; set; }
    }
}

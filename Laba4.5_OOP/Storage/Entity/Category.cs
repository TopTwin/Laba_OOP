using Laba_OOP.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Laba4._5_OOP.Storage.Entity
{
    [Table("tblCategory")]
    public class Category : IUniqueEntity
    {
        [Key]
        [Required]
        [Column("gId")]
        public Guid Id { get; set; }

        [Required]
        [Column("szName")]
        public string Name { get; set; }

        [Required]
        [Column("intQuantity")]
        public int Quantity { get; set; }

        [Column("gLibrary")]
        [ForeignKey("Library")]
        public Guid LibraryId { get; set; }
        public Library Library { get; set; }

        public List<Book> Books { get; set; }
    }
}

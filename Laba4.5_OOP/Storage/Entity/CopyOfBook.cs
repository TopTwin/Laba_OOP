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
    [Table("tblCopyOfBook")]
    public class CopyOfBook : IUniqueEntity
    {
        [Key]
        [Required]
        [Column("gId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }
        public Book Book { get; set; }


        [ForeignKey(nameof(Reader))]
        public Guid ReaderId { get; set; }
        public Reader Reader { get; set; }
    }
}

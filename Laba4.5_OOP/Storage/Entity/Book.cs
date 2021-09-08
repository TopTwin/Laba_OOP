using Laba_OOP.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Laba4._5_OOP.Storage.Entity
{
    [Table("tblBook")]
    public class Book: IUniqueEntity
    {
        [Key]
        [Required]
        [Column("gId")]
        public Guid Id { get; set; }

        [Required]
        [Column("szName")]
        public string Name { get; set; }

        
        
        [ForeignKey("author")]
        public Guid AuthorId { get; set; }
        public Author author { get; set; }
        
        
        [ForeignKey("category")]
        public Guid CategoryId { get; set; }
        public Category category { get; set; }
    }
}

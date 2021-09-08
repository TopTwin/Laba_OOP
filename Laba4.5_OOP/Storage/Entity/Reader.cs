using Laba4._5_OOP.Storage.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Laba_OOP.Storage.Entity
{
    [Table("tblReader")]
    public class Reader : IUniqueEntity
    {
        [Key]
        [Required]
        [Column("gId")]
        public Guid Id { get; set; }

        [Required]
        [Column("szName")]
        public string Name { get; set; }

        [Required]
        [Column("szSName")]
        public string LastName { get; set; }

        [Required]
        [Column("tmRegistration")]
        public DateTime Registration { get; set; }

        [Column("gLibrary")]
        [ForeignKey("Library")]
        public Guid LibraryId { get; set; }
        public Library Library { get; set; }

    }
}

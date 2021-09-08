using Laba_OOP.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Laba4._5_OOP.Storage.Entity
{
    [Table("tblWorker")]
    public class Worker : IUniqueEntity
    {
        [Key]
        [Required]
        [Column("gWorkerId")]

        public Guid Id { get; set; }

        [Required]
        [Column("szName")]
        public string Name { get; set; }

        [Required]
        [Column("szPosition")]
        public string Position { get; set; }

        [Required]
        [Column("intSalary")]
        public int Salary { get; set; }

        [ForeignKey("Library")]
        public Guid LibraryId { get; set; }
        public Library Library { get; set; }
    }
}

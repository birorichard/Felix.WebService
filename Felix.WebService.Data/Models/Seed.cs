using Felix.WebService.Common.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Felix.WebService.Data.Models
{
    [Table(nameof(Seed), Schema = DataConstants.BusinessSchemaName)]
    public class Seed
    {
        [Key]
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

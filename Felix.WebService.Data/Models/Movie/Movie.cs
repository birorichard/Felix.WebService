using Felix.WebService.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Felix.WebService.Data.Models.Movie
{
    [Table(nameof(Movie), Schema = DataConstants.MovieSchemaName)]
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string CodeName { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [InverseProperty(nameof(Cut.Movie))]
        public virtual ICollection<Cut> Cuts { get; set; }
    }
}

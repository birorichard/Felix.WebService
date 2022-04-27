using Felix.WebService.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Felix.WebService.Data.Models.Movie
{
    [Table(nameof(Cut), Schema = DataConstants.MovieSchemaName)]
    public class Cut
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int MovieId { get; set; }
        
        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; }

        [InverseProperty(nameof(ShotCutRel.Cut))]
        public virtual ICollection<ShotCutRel> ShotCutRels { get; set; }


    }
}
